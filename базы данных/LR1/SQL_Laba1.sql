USE master --������������ �� master
GO
--�������� �� � ����������� �� � ���-�����
IF DB_ID('MyDB') IS NULL CREATE DATABASE MyDB
ON
(
	NAME='MyDB_dat',
	FILENAME='c:\Users\USER\Desktop\��������� �������\���� ������\LR1\MyDB_dat.mdf',
	SIZE=4MB,
	MAXSIZE=10MB,
	FILEGROWTH=1MB
)
LOG ON 
(
	NAME='MyDB_log',
    FILENAME ='c:\Users\USER\Desktop\��������� �������\���� ������\LR1\MyDB_log.ldf',
    SIZE=2MB,
    MAXSIZE=5MB,
    FILEGROWTH=1MB
)
GO -- ���������
--�������� ���������� �� ��������� ���� ������
EXEC sp_helpdb MyDB 
--���������� ������� ����� MyDB_dat � �� MyDB, ���� ����� ���� ���� - �� ������ ������ ����� �� �� 15MB
IF (SELECT name FROM sys.master_files WHERE database_id = DB_ID('MyDB') AND name='MyDB_dat') IS NOT NULL ALTER DATABASE MyDB MODIFY FILE(
NAME='MyDB_dat',
SIZE=15MB
)
GO
--��������� ������� � �� ���� ����
IF DB_ID('MyDB_snapshot') IS NOT NULL DROP DATABASE MyDB_snapshot
IF DB_ID('MyDB') IS NOT NULL DROP DATABASE MyDB
GO
--��������� �� MyDB ���� � ���
IF DB_ID('MyDB') IS NULL CREATE DATABASE MyDB
GO
--������������ � �� MyDB
USE MyDB
GO
-- ���� � �� MyDB ��� ������� table1, �� ��������� ������� table1
IF OBJECT_ID('dbo.table1') IS NULL CREATE TABLE table1 (
	id int NOT NULL IDENTITY(1,1), 
	fio varchar(20) NULL, 
	datar datetime,
	PRIMARY KEY(id)
)
GO
--������ ����� �� MyDB ������� ������ ��� ������ 
ALTER DATABASE MyDB SET READ_ONLY
--�������� �������� ������ � ������� - ������
--INSERT INTO dbo.table1 VALUES('family name',GETDATE())
--������ ����� �� MyDB ������� ��� ������ � ������
ALTER DATABASE MyDB SET READ_WRITE
--��������� ������ � �������
INSERT INTO dbo.table1 VALUES('family name',GETDATE())
GO
--������� ����� �� ������� table1
SELECT * FROM dbo.table1
GO
--����� ���� ������ ���������� � ������ (filegroups).
--��������� ����� ������ ������ � �� MyDB ��� ��������� new_filegroup � ����������� �� ���������
ALTER DATABASE MyDB ADD FILEGROUP new_filegroup
GO
--������ ��������� new_filegroup
ALTER DATABASE MyDB ADD FILE (
	NAME='MyDB_new_dat',
	FILENAME='c:\Users\USER\Desktop\��������� �������\���� ������\LR1\MyDB_new_dat.mdf',
	SIZE=4MB,
	MAXSIZE=10MB,
	FILEGROWTH=1MB
) TO FILEGROUP new_filegroup
GO
--������ ����� ������ ���������
ALTER DATABASE MyDB MODIFY FILEGROUP new_filegroup DEFAULT
GO
--�������� �������� (�.�. � �� 2 �������� ������ - 1 ��������� (�������� ����� = �������� ��, �.�. ��������� 
--��� �������� �� �������������), � ������ new_filegroup, ������� �������� ����) - �� ��������� ��� 2 
--����� ������ (NAME=...) �� � ������������ (FILENAME=...) ���� ����� ����������� ��������
CREATE DATABASE MyDB_snapshot ON
(
	NAME='MyDB_new_dat',
	FILENAME='c:\Users\USER\Desktop\��������� �������\���� ������\LR1\SNAPSHOT\Snapshot_MyDB_new_dat.mdf'
),(
NAME='MyDB',
FILENAME='c:\Users\USER\Desktop\��������� �������\���� ������\LR1\SNAPSHOT\Snapshot_MyDB.mdf'
) AS SNAPSHOT OF MyDB
GO
--������� ������ ������� �� table1 �� MyDB � MyDB_snapshot
SELECT TOP 1 * FROM MyDB.dbo.table1 TEST
SELECT TOP 1 * FROM MyDB_snapshot.dbo.table1 TEST
--��������� 2-� ������
IF(SELECT COUNT(*) FROM MyDB.dbo.table1 AS A ,MyDB_snapshot.dbo.table1 AS B WHERE A.id=B.id AND A.fio=B.fio AND A.datar=B.datar)>0
	BEGIN
		print N'snapshot=original'
	END
ELSE
	BEGIN
		print N'snapshot!=original'
	END
--�������� 1-�� ������ ������� table1 �� MyDB
UPDATE MyDB.dbo.table1 SET fio='new FIO' WHERE MyDB.dbo.table1.id=(SELECT top 1 id FROM MyDB.dbo.table1)
--��������� 2-� ������
IF(SELECT COUNT(*) FROM MyDB.dbo.table1 AS A ,MyDB_snapshot.dbo.table1 AS B WHERE A.id=B.id AND A.fio=B.fio AND A.datar=B.datar)>0
	BEGIN
		print N'snapshot=original'
	END
ELSE
	BEGIN
		print N'snapshot!=original'
	END
--������� ������� � ��
USE master
GO
IF DB_ID('MyDB_snapshot') IS NOT NULL DROP DATABASE MyDB_snapshot
IF DB_ID('MyDB') IS NOT NULL DROP DATABASE MyDB