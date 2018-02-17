--процедура 1
	USE DocumentLgoty
	GO

	CREATE PROC dbo.Zapros01
	@var varchar(256)
	AS
	SELECT doc_name FROM Document WHERE Document.doc_name IN (SELECT doc_name FROM VidLgoty WHERE lgota_name=@var)
	GO

	CREATE PROC dbo.Zapros1
	@var varchar(256)
	AS
	CREATE TABLE dbo.Table1 ([name] sysname NOT NULL)
	INSERT INTO dbo.Table1 ([name])
	EXEC dbo.Zapros01 @var
	SELECT * FROM dbo.Table1
	DROP TABLE dbo.Table1
	GO
	--вызов
	USE DocumentLgoty
	GO
	EXECUTE dbo.Zapros1 'ЖКХ'
	GO

--процедура 2

	USE DocumentLgoty
	GO

	CREATE PROC dbo.Zapros02
	@var varchar(256)
	AS
	SELECT Grajdanin.category AS cotegory,Lgota.lgota_name AS lgota,
	COUNT(Lgota.lgota_name) AS LgotaCount,COUNT(Grajdanin.category) CategoryCount
	FROM Grajdanin,Lgota WHERE Lgota.lgota_name IN (SELECT lgota_name FROM VidLgoty AS V WHERE  
	V.doc_name IN (SELECT doc_name FROM Document WHERE doc_name=@var)) GROUP BY 
	Grajdanin.category,Lgota.lgota_name
	GO

	CREATE PROC dbo.Zapros2
	@var varchar(256)
	AS
	CREATE TABLE dbo.Table2 ([name] sysname NOT NULL,
	[name2] sysname NOT NULL,
	[name3] sysname NOT NULL,
	[name4] sysname NOT NULL
	)
	INSERT INTO dbo.Table2 ([name],[name2],[name3],[name4])
	EXEC dbo.Zapros02 @var
	SELECT * FROM dbo.Table2
	DROP TABLE dbo.Table2
	GO

	--вызов процедуры
	USE DocumentLgoty
	GO
	EXECUTE dbo.Zapros2 'Документ 825'
	GO
	
--процедура 3
	USE DocumentLgoty
	GO

	CREATE PROC dbo.Zapros03
	@cat int,
	@docname varchar(256),
	@d_before datetime,
	@d_end datetime
	AS
	SELECT lgota_name FROM VidLgoty AS Vlgota WHERE Vlgota.lgota_name 
	IN (SELECT Lgota.lgota_name FROM Lgota AS lgota WHERE lgota.passport 
	IN (SELECT Grajdanin.passport FROM Grajdanin WHERE category=@cat)) AND Vlgota.doc_name IN 
	(SELECT doc_name FROM Document AS D WHERE  D.doc_name=@docname 
		AND D.doc_data_begin BETWEEN @d_before AND @d_end)
	GO

	CREATE PROC dbo.Zapros3
	@cat int,
	@docname varchar(256),
	@d_before datetime,
	@d_end datetime
	AS
	CREATE TABLE dbo.Table3 ([name] sysname NOT NULL)
	INSERT INTO dbo.Table3 ([name])
	EXEC dbo.Zapros03 @cat,@docname,@d_before,@d_end
	SELECT * FROM dbo.Table3
	DROP TABLE dbo.Table3
	GO

	--вызов процедуры
	USE DocumentLgoty
	GO
	DECLARE  @cat int,
	@docname varchar(256),
	@d_before datetime,
	@d_end datetime
	SET @cat=1
	SET @docname='Документ 824'
	SET @d_before='03/04/1993'
	SET @d_end='07/05/2018'
	EXECUTE dbo.Zapros3 @cat,@docname,@d_before,@d_end
	GO
	
--тригер на событие INSERT на таблицу Lgota, он будет автоматически добавлять записи в таблицу Grajdanin 
	USE  DocumentLgoty

	IF OBJECT_ID ('auto_fill_grajdanin') IS NOT NULL DROP TRIGGER auto_fill_grajdanin
	GO
	CREATE TRIGGER auto_fill_grajdanin ON Lgota 
	FOR INSERT AS DECLARE 
		 @passport Varchar(256),
		 @lgota_name int
	BEGIN
		SELECT @passport = (SELECT passport FROM inserted)

		INSERT INTO Grajdanin VALUES (@passport, NULL, NULL, NULL)
	END
	GO

	--проверка работы тригера
	USE DocumentLgoty
	INSERT INTO Lgota VALUES(789490670,'ЖКХ')
	GO
	SELECT * FROM Grajdanin
	GO
