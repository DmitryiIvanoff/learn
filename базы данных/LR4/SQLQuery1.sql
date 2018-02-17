USE master
GO
--создаем БД Sport
IF DB_ID('Sport') IS NULL CREATE DATABASE Sport
GO
USE Sport
GO
--создаем таблицы в БД с ограничениями и первичными/внешними ключами
IF OBJECT_ID('dbo.sport') IS NULL CREATE TABLE sport(
	stype 	Varchar(256) Not Null,
	edizm 	Varchar(10)	Null,
	wrecord	Int	Null,
	wrdata	Int	Null,
	PRIMARY KEY(stype),
	CHECK (wrdata<=YEAR(getdate()) AND wrdata>1000 AND wrecord>0)
)
IF OBJECT_ID('dbo.command') IS NULL CREATE TABLE command(
	cname	Varchar(256)	Not Null,
	stype 	Varchar(256)	Null,
	PRIMARY KEY(cname),
	FOREIGN KEY (stype) REFERENCES sport(stype)
)
IF OBJECT_ID('dbo.athlete') IS NULL CREATE TABLE athlete(
	athlete_ID	Int	Not Null IDENTITY,
	FIO 	Varchar(256)	Not Null,
	DOB 	Datetime	Null,
	rang	Int	Null,
	cname	Varchar(256)	Null,
	PRIMARY KEY(athlete_ID),
	FOREIGN KEY (cname) REFERENCES command(cname),
	CHECK (YEAR(DOB)<=YEAR(getdate()) AND FIO LIKE '% % %')
)
IF OBJECT_ID('dbo.competition') IS NULL CREATE TABLE competition(
	sname 	Varchar(256)	Not Null,
	place 	Varchar(256)	Null,
	dbegin	Datetime	Null,
	dend	Datetime	Null,
	PRIMARY KEY(sname),
	CHECK (YEAR(dbegin)<=YEAR(getdate()) AND YEAR(dend)<=YEAR(getdate()) AND dbegin<dend)
)
IF OBJECT_ID('dbo.result') IS NULL CREATE TABLE result(
	athlete_ID	Int	Not Null,
	result	Int	Null,
	sname	Varchar(256)	Not Null,
	PRIMARY KEY(athlete_ID),
	FOREIGN KEY (athlete_ID) REFERENCES athlete(athlete_ID),
	FOREIGN KEY (sname) REFERENCES competition(sname)
)
GO
--Сообщает информацию об указанных БД
EXEC sp_help sport
EXEC sp_help command
EXEC sp_help athlete
EXEC sp_help competition
EXEC sp_help result
--заполняем таблицы
INSERT INTO sport VALUES('Бег на 100 м','сек',9.58,2009),
	('Метание молота','м',79.42,2011),
	('Прыжки с трамплина','м',246.5,2011)
INSERT INTO command VALUES('Ямайка','Бег на 100 м'),
	('Германия','Метание молота'),
	('Россия','Прыжки с трамплина')
INSERT INTO athlete VALUES('Джереми Уотерспун Отчество',convert(datetime, '10/23/1980', 101),1,'Ямайка'),
	('Уве Хон Отчество',convert(datetime, '10/23/1984', 101),2,'Германия'),
	('Иванов Иван Отчество',convert(datetime, '10/23/1990', 101),3,'Россия')
INSERT INTO competition VALUES('Прыжки с трамплина','Рио Де Жанейро',convert(datetime, '10/23/2014', 101),convert(datetime, '11/23/2014', 101)),
	('Метание молота','Мюнхен',convert(datetime, '3/11/2000', 101),convert(datetime, '4/11/2000', 101))
INSERT INTO result VALUES ((SELECT athlete_ID FROM athlete WHERE FIO='Иванов Иван Отчество'),1,'Прыжки с трамплина'),
	((SELECT athlete_ID FROM athlete WHERE FIO='Уве Хон Отчество'),10,'Метание молота'),
	((SELECT athlete_ID FROM athlete WHERE FIO='Джереми Уотерспун Отчество'),1,'Прыжки с трамплина')