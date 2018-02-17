USE master
GO
--создаем БД BookshopDB
IF DB_ID('BookshopDB') IS NULL CREATE DATABASE BookshopDB
GO
EXEC sp_helpdb BookshopDB
USE BookshopDB
GO
--создаем таблицы в БД с первичными/внешними ключами
IF OBJECT_ID('dbo.Authors')IS NULL CREATE TABLE Authors(
	AuthorID int not null IDENTITY,
	FirstName varchar(30) not null DEFAULT 'unknown',
	LastName varchar(30) null,
	YearBorn char(4) null,
	YearDied char(4) not null DEFAULT 'no',
	PRIMARY KEY(AuthorID)
)
GO
EXEC sp_help Authors
IF COL_LENGTH('dbo.Authors', 'Descr') IS NULL
BEGIN
    ALTER TABLE Authors ADD Descr varchar(200) NOT NULL DEFAULT 'empty'
END
IF OBJECT_ID('dbo.Books')IS NULL CREATE TABLE Books(
	BookID int not null IDENTITY, 
	Title varchar(100) not null,
	Janr varchar(50) null,
	Primary key(BookID)
)
GO
IF OBJECT_ID('dbo.BookAuthor')IS NULL
--создаем таблицу BookAuthor,редактируем таблицу, добавляем первичный и внешний ключи, а также ограничения
BEGIN
	CREATE TABLE BookAuthor(
		BookID int not null,
		AuthorID int not null
	)
	ALTER TABLE BookAuthor ADD PRIMARY KEY (BookID,AuthorID)
	ALTER TABLE BookAuthor ADD CONSTRAINT BookAuthor_BookID_const FOREIGN KEY (BookID) REFERENCES Books(BookID)
	ALTER TABLE BookAuthor ADD CONSTRAINT BookAuthor_Authors_const FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
	ALTER TABLE Authors ADD CONSTRAINT CK_Authors_YearBorn CHECK (YearBorn LIKE '[1-2][0,6-9][0-9][0-9]')
	ALTER TABLE Authors ADD CONSTRAINT CK_Authors_YearDied CHECK ((YearDied LIKE '[1-2][0,6-9][0-9][0-9]' OR 
		YearDied='no') AND YearDied>YearBorn)
END
GO
--заполняем таблицы
INSERT INTO dbo.Authors VALUES('Mihail','Bulgakov','1891','1940','some description'),
	('Lev','Tolstoy','1828','1910','some description'),
	('Zahar','Prilepin','1975','no','some description')
INSERT INTO dbo.Books VALUES('Master and Margarita','Roman'),
	('The war and the peace','Roman'),
	('Черная обезьяна','роман')
GO
INSERT INTO dbo.BookAuthor VALUES(1,1),(2,2),(3,3)
GO