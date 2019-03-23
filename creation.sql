/************************************************
					REHBER
************************************************/

/************************************************
				DATABASE KALDIRMA
************************************************/
IF DB_ID('REHBER') IS NOT NULL
	BEGIN
		ALTER DATABASE REHBER SET SINGLE_USER WITH ROLLBACK IMMEDIATE
		USE master
		DROP DATABASE REHBER
	END
GO

/************************************************
				DATABASE OLUSTURMA
************************************************/
CREATE DATABASE REHBER
	ON PRIMARY(
		NAME = 'rehber_db',
		FILENAME = 'W:\database\rehber_db.ldf',
		SIZE = 20MB,
		MAXSIZE = 100MB,
		FILEGROWTH = 10MB
	)
	LOG ON(
		NAME = 'rehber_log',
		FILENAME = 'W:\database\rehber_log.ldf',
		SIZE = 10MB,
		MAXSIZE = 60MB,
		FILEGROWTH = 5MB
	)
GO
USE REHBER

/************************************************
					TABLOLAR
************************************************/

/* DEPARTMAN */
CREATE TABLE tblDepartman(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Ad NVARCHAR(50) NOT NULL
)
GO

/* CALISAN */
CREATE TABLE tblCalisan(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	--Telefon VARCHAR(13) CONSTRAINT CHK_Calisan_TelefonNumarasi CHECK(Telefon LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]') NOT NULL,
	Telefon VARCHAR(13) NOT NULL,
	Ad NVARCHAR(50) NOT NULL,
	Soyad NVARCHAR(50) NOT NULL,
	DepartmanID INT CONSTRAINT FK_Calisan_Departman_DepartmanID FOREIGN KEY (DepartmanID) REFERENCES tblDepartman (ID) NULL,
	YoneticiID INT CONSTRAINT FK_Calisan_YoneticiID FOREIGN KEY (YoneticiID) REFERENCES tblCalisan (ID) NULL
)
GO

CREATE TABLE tblAyarlar(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Anahtar NVARCHAR(250) NOT NULL,
	Deger NVARCHAR(250) NOT NULL
)
GO
/************************************************
			ILISKIDEN DOGAN TABLOLAR
************************************************/

/************************************************
					INSERTLER
************************************************/

INSERT INTO tblDepartman VALUES
	('Yazýlým'),
	('Pazarlama'),
	('IT'),
	('Ýnsan Kaynaklarý');

INSERT INTO tblCalisan VALUES
	('05001234567', 'Berat Göktuð', 'Özdemir', 1, NULL),
	('05002345678', 'Eda', 'Budak', 3, 1),
	('05003456789', 'Hande', 'Pamuk', 2, 2),
	('05004567890', 'Selim', 'Serbest', 1, 1),
	('05005678901', 'Kadir', 'Tokgöz', 1, 1),
	('05005678901', 'Ali', 'Baba', NULL, NULL);

INSERT INTO tblAyarlar VALUES
	('AdminPass', 'bgoktugozdemir');