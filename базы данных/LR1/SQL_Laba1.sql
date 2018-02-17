USE master --использовать БД master
GO
--создание БД с параметрами БД и лог-файла
IF DB_ID('MyDB') IS NULL CREATE DATABASE MyDB
ON
(
	NAME='MyDB_dat',
	FILENAME='c:\Users\USER\Desktop\Четвертый семестр\Базы данных\LR1\MyDB_dat.mdf',
	SIZE=4MB,
	MAXSIZE=10MB,
	FILEGROWTH=1MB
)
LOG ON 
(
	NAME='MyDB_log',
    FILENAME ='c:\Users\USER\Desktop\Четвертый семестр\Базы данных\LR1\MyDB_log.ldf',
    SIZE=2MB,
    MAXSIZE=5MB,
    FILEGROWTH=1MB
)
GO -- выполнить
--Сообщает информацию об указанной базе данных
EXEC sp_helpdb MyDB 
--проверятся наличие файла MyDB_dat в БД MyDB, если такой файл есть - то меняем размер файла БД на 15MB
IF (SELECT name FROM sys.master_files WHERE database_id = DB_ID('MyDB') AND name='MyDB_dat') IS NOT NULL ALTER DATABASE MyDB MODIFY FILE(
NAME='MyDB_dat',
SIZE=15MB
)
GO
--удаляются снапшот и БД если есть
IF DB_ID('MyDB_snapshot') IS NOT NULL DROP DATABASE MyDB_snapshot
IF DB_ID('MyDB') IS NOT NULL DROP DATABASE MyDB
GO
--создается БД MyDB если её нет
IF DB_ID('MyDB') IS NULL CREATE DATABASE MyDB
GO
--подклюяаемся к БД MyDB
USE MyDB
GO
-- если в БД MyDB нет таблицы table1, то создается таблица table1
IF OBJECT_ID('dbo.table1') IS NULL CREATE TABLE table1 (
	id int NOT NULL IDENTITY(1,1), 
	fio varchar(20) NULL, 
	datar datetime,
	PRIMARY KEY(id)
)
GO
--ставим файлу БД MyDB атрибут только для чтения 
ALTER DATABASE MyDB SET READ_ONLY
--пытаемся добавить запись в таблицу - ошибка
--INSERT INTO dbo.table1 VALUES('family name',GETDATE())
--ставим файлу БД MyDB атрибут для чтения и записи
ALTER DATABASE MyDB SET READ_WRITE
--добавляем запись в таблицу
INSERT INTO dbo.table1 VALUES('family name',GETDATE())
GO
--выборка всего из таблицы table1
SELECT * FROM dbo.table1
GO
--Файлы базы данных объединены в группы (filegroups).
--добавляем новую группу файлов к БД MyDB под названием new_filegroup с параметрами по умолчанию
ALTER DATABASE MyDB ADD FILEGROUP new_filegroup
GO
--меняем параметры new_filegroup
ALTER DATABASE MyDB ADD FILE (
	NAME='MyDB_new_dat',
	FILENAME='c:\Users\USER\Desktop\Четвертый семестр\Базы данных\LR1\MyDB_new_dat.mdf',
	SIZE=4MB,
	MAXSIZE=10MB,
	FILEGROWTH=1MB
) TO FILEGROUP new_filegroup
GO
--делаем новую группу дефолтной
ALTER DATABASE MyDB MODIFY FILEGROUP new_filegroup DEFAULT
GO
--создание снапшота (т.к. в БД 2 файловые группы - 1 дефолтная (название файла = названию БД, т.к. параметры 
--при создании не прописывались), а вторая new_filegroup, которую добавили выше) - то указываем все 2 
--имени файлов (NAME=...) БД и расположения (FILENAME=...) куда будут скопированы снапшоты
CREATE DATABASE MyDB_snapshot ON
(
	NAME='MyDB_new_dat',
	FILENAME='c:\Users\USER\Desktop\Четвертый семестр\Базы данных\LR1\SNAPSHOT\Snapshot_MyDB_new_dat.mdf'
),(
NAME='MyDB',
FILENAME='c:\Users\USER\Desktop\Четвертый семестр\Базы данных\LR1\SNAPSHOT\Snapshot_MyDB.mdf'
) AS SNAPSHOT OF MyDB
GO
--выборка первых записей из table1 БД MyDB и MyDB_snapshot
SELECT TOP 1 * FROM MyDB.dbo.table1 TEST
SELECT TOP 1 * FROM MyDB_snapshot.dbo.table1 TEST
--сравнение 2-х таблиц
IF(SELECT COUNT(*) FROM MyDB.dbo.table1 AS A ,MyDB_snapshot.dbo.table1 AS B WHERE A.id=B.id AND A.fio=B.fio AND A.datar=B.datar)>0
	BEGIN
		print N'snapshot=original'
	END
ELSE
	BEGIN
		print N'snapshot!=original'
	END
--апдейтим 1-ую запись таблицы table1 БД MyDB
UPDATE MyDB.dbo.table1 SET fio='new FIO' WHERE MyDB.dbo.table1.id=(SELECT top 1 id FROM MyDB.dbo.table1)
--сравнение 2-х таблиц
IF(SELECT COUNT(*) FROM MyDB.dbo.table1 AS A ,MyDB_snapshot.dbo.table1 AS B WHERE A.id=B.id AND A.fio=B.fio AND A.datar=B.datar)>0
	BEGIN
		print N'snapshot=original'
	END
ELSE
	BEGIN
		print N'snapshot!=original'
	END
--делетим снапшот и БД
USE master
GO
IF DB_ID('MyDB_snapshot') IS NOT NULL DROP DATABASE MyDB_snapshot
IF DB_ID('MyDB') IS NOT NULL DROP DATABASE MyDB