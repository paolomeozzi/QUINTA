/*******************************************************************************
 Library Database - Version 1.0
 Descrizione: crea e popola il database Library.
 Linguaggio: NSQL
********************************************************************************/

/*******************************************************************************
 Drop database if it exists
********************************************************************************/


IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'Library')
BEGIN
	ALTER DATABASE Library SET OFFLINE WITH ROLLBACK IMMEDIATE
	ALTER DATABASE Library SET ONLINE
	DROP DATABASE Library
END
GO


/*#EASYQUERY: Drop tables*/


/*******************************************************************************
   Create database
********************************************************************************/
CREATE DATABASE Library
GO

USE Library
GO


/*******************************************************************************
 Create Tables
********************************************************************************/

CREATE TABLE [dbo].[Genres](
	[GenreId] INT IDENTITY,
	[Name] NVARCHAR(120) NOT NULL,
	CONSTRAINT [PK_Genre] PRIMARY KEY ([GenreId])
)

CREATE TABLE [dbo].[Books](
	[BookId] INT IDENTITY,
	[Title] NVARCHAR(160) NOT NULL,
	[PubblicationDate] DATETIME,
	[AvailableCount] INT NOT NULL,
	[GenreId] INT NOT NULL,
	[CoverFileName] NVARCHAR(70),
	CONSTRAINT [PK_Book] PRIMARY KEY ([BookId])
)

CREATE TABLE [dbo].[Authors](
	[AuthorId] INT IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	CONSTRAINT [PK_Author] PRIMARY KEY ([AuthorId])
)

CREATE TABLE [dbo].[AuthorsNote](
	[AuthorId] INT NOT NULL,
	[Biography] NVARCHAR(MAX),
	[Photo] VARBINARY(MAX),
	CONSTRAINT [PK_AuthorNote] PRIMARY KEY ([AuthorId])
)

CREATE TABLE [dbo].[Publications](
	[BookId] INT NOT NULL,
	[AuthorId] INT NOT NULL,
	CONSTRAINT [PK_Publication] PRIMARY KEY ([BookId],[AuthorId])
)

CREATE TABLE [dbo].[Affiliateds](
	[AffiliatedId] INT IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[BirthDate] DATETIME,
	[Address] NVARCHAR(50),
	[City] NVARCHAR(30),
	[Phone] NVARCHAR(14),
	[Email] NVARCHAR(60),
	CONSTRAINT [PK_Affiliated] PRIMARY KEY ([AffiliatedId])
)

CREATE TABLE [dbo].[Loans](
	[LoanId] INT IDENTITY,
	[BookId] INT NOT NULL,
	[AffiliatedId] INT NOT NULL,
	[LoanDate] DATETIME NOT NULL,
	[ReturnDate] DATETIME,
	CONSTRAINT [PK_Loan] PRIMARY KEY ([LoanId])
)

/*******************************************************************************
 Create Primary Key Unique and Indexes
********************************************************************************/

CREATE UNIQUE INDEX [IX_GenreName] ON [dbo].[Genres] ([Name])

/*
CREATE UNIQUE INDEX IPK_Genre ON Genres(GenreId)
GO
CREATE UNIQUE INDEX IPK_Book ON Books(BookId)
GO
CREATE UNIQUE INDEX IPK_Author ON Authors(AuthorId)
GO
CREATE UNIQUE INDEX IPK_Pubblication ON Publications(BookId, AuthorId)
GO
CREATE UNIQUE INDEX IPK_Affiliated ON Affiliateds(AffiliatedId)
GO
CREATE UNIQUE INDEX IPK_Loan ON Loans(LoanId)
GO
*/

/*#EASYQUERY: Create tables*/

/*******************************************************************************
 Create Foreign Keys
********************************************************************************/

ALTER TABLE [dbo].[Books]
 	ADD CONSTRAINT [FK_BookGenre] FOREIGN KEY ([GenreId]) REFERENCES [Genres]([GenreId]) ON DELETE NO ACTION ON UPDATE NO ACTION

ALTER TABLE [dbo].[AuthorsNote]
 	ADD CONSTRAINT [FK_AuthorPhotoAuthor] FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([AuthorId]) ON DELETE NO ACTION ON UPDATE NO ACTION

ALTER TABLE [dbo].[Publications]
 	ADD CONSTRAINT [FK_PubblicationAuthor] FOREIGN KEY ([AuthorId]) REFERENCES [Authors]([AuthorId]) ON DELETE NO ACTION ON UPDATE NO ACTION

ALTER TABLE [dbo].[Publications]
 	ADD CONSTRAINT [FK_PubblicationBook] FOREIGN KEY ([BookId]) REFERENCES [Books]([BookId]) ON DELETE NO ACTION ON UPDATE NO ACTION

ALTER TABLE [dbo].[Loans]
 	ADD CONSTRAINT [FK_LoanBook] FOREIGN KEY ([BookId]) REFERENCES [Books]([BookId]) ON DELETE NO ACTION ON UPDATE NO ACTION

ALTER TABLE [dbo].[Loans]
 	ADD CONSTRAINT [FK_LoanAffiliated] FOREIGN KEY ([AffiliatedId]) REFERENCES [Affiliateds]([AffiliatedId]) ON DELETE NO ACTION ON UPDATE NO ACTION

/*#EASYQUERY: Add foreign keys*/

/*******************************************************************************
 Create Foreign Key Indexes
********************************************************************************/

/* 
CREATE INDEX IFK_BookGenre ON Books (GenreId)
GO
CREATE INDEX IFK_PubblicationAuthor ON Publications (AuthorId)
GO
CREATE INDEX IFK_PubblicationBook ON Publications (BookId)
GO
CREATE INDEX IFK_LoanBook ON Loans (BookId)
GO
CREATE INDEX IFK_LoanAffiliated ON Loans (AffiliatedId)
GO
*/

/*******************************************************************************
 Populate Tables
********************************************************************************/

/* GENRES */

INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Fantascienza')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Fantasy')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Horror')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Giallo')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Saggistica')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Storico')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Letteratura')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Informatica')
INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Matematica')

/*#EASYQUERY: Insert genres*/

/* AUTHORS */

INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Isaac','Asimov')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Orson','Scott Card')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Carl','Sagan')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Alfred','Van Vogt')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Stephen','King')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Robert','Silverberg')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Richard','Dawkins')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Basil','Liddel Hart')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Stephen','Gould')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Steven','Pinker')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Edward','Wilson')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Charles','Darwin')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Dante','Alighieri')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Alessandro','Manzoni')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('John',' Tolkien')
INSERT INTO [dbo].[Authors] ([FirstName],[LastName]) VALUES ('Patricia','Cornwell')

/*#EASYQUERY: Insert authors*/

/* BOOKS */

INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Fondazione','2003/03/01',3,1,'Fondazione.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Il gioco di Ender','2013/10/10',1,1,'Il gioco di Ender.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Fondazione e Terra','1994/01/01',1,1,'Fondazione e Terra.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Il mondo infestato dai demoni','2001/07/10',1,5,'Il mondo infestato dai demoni.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Le armi di Isher',NULL,1,1,'Le armi di Isher.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Il figlio del tempo','1986/01/01',2,1,'Il figlio del tempo.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('La prima guerra mondiale','2001/01/01',2,6,'La prima guerra mondiale.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('L''orologiaio cieco','2006/07/19',1,5,'L''orologiaio cieco.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Alla conquista del monte improbabile','2003/03/01',1,5,'Alla conquista del monte improbabile.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Gli alberi non crescono fino in cielo','1996/01/01',1,5,'Gli alberi non crescono fino in cielo.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Il pollice del panda','2001/01/01',1,5,'Il pollice del panda.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Otto piccoli porcellini','1994/01/01',1,5,'Otto piccoli porcellini.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('L''istinto del linguaggio','1994/01/01',1,5,'L''istinto del linguaggio.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('L''armonia meravigliosa','1998/01/01',1,5,'L''armonia meravigliosa.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('L''origine delle specie','1844/01/01',3,5,'L''origine delle specie.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Storia di una sconfitta','1971/01/01',1,6,'Storia di una sconfitta.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('La Divina Commedia','2001/01/01',3,7,'La Divina Commedia.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('La Divina Commedia - Inferno','1998/01/01',2,7,'La Divina Commedia - Inferno.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('I promessi sposi','1995/01/01',3,7,'I promessi sposi.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Il signore degli anelli - Il ritorno del Re','2005/01/27',2,2,'Il signore degli anelli - Il ritorno del Re.jpg')
INSERT INTO [dbo].[Books] ([Title],[PubblicationDate],[AvailableCount],[GenreId],[CoverFileName]) VALUES ('Letto d''ossa','2012/01/02',1,4,'Letto d''ossa.jpg')

/*#EASYQUERY: Insert books*/

/* Publications */

INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (1,1)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (2,2)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (3,1)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (4,3)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (5,4)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (6,1)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (6,6)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (7,8)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (8,7)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (9,7)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (10,9)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (11,9)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (12,9)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (13,10)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (14,11)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (15,12)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (16,8)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (17,13)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (18,13)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (19,14)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (20,15)
INSERT INTO [dbo].[Publications] ([BookId],[AuthorId]) VALUES (21,16)

/*#EASYQUERY: Insert Publications*/

/* AFFILIATEDS */

INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Chiara','Ponti','1972/08/04','Piazza Garibaldi, 34/c','Arezzo','0575-733431','chiaragaribaldi@gmail.com')
INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Francesco','Foni','1966/11/08','Via A. Marconi, 78','Arezzo','0575-799434','andrea@hotmail.it')
INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Andrea','Rossi','1966/02/06','Via della Liberazione, 5','Arezzo','0575-756438','andrear@yahoo.it')
INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Stefania','Galimberti','1952/03/03','Via G. Monaco, 45','Arezzo','0575-735455','stefaniag@gmail.com')
INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Sandro','Tiffi','1972/06/01','Via P. della Francesca, 4','Sansepolcro','0575-794467','sandrotiffi@alice.it')
INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Filippo','Bardi','1982/01/10','Piazza Garibaldi, 1','Arezzo','0575-783498','filippog@gmail.com')
INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Luisella','Antoni','1997/11/05','Via XX Settembre, 45','Arezzo','0575-7432318','luisellaa@alice.it')
INSERT INTO [dbo].[Affiliateds] ([FirstName],[LastName],[BirthDate],[Address],[City],[Phone],[Email]) VALUES ('Sonia','Alfi','1991/04/15','Via Bardi, 8','Arezzo','0575-7148618','sonia.alfi@alice.it')

/*#EASYQUERY: Insert affiliateds*/

/* LOANS */

INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (3,1,'2012/11/05','2012/12/06')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (2,1,'2012/12/09','2013/01/10')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (1,1,'2012/12/11','2013/01/16')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (7,2,'2012/10/03','2012/12/05')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (8,2,'2012/11/05','2012/12/22')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (6,3,'2013/02/04','2013/03/05')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (2,3,'2013/05/11','2013/06/07')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (4,4,'2013/05/11','2013/06/05')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (12,4,'2013/06/01','2013/06/29')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (15,5,'2013/06/17','2013/07/01')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (15,6,'2013/06/24','2013/07/21')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (14,6,'2013/07/08','2013/07/27')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (14,5,'2013/08/11',NULL)
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (17,4,'2013/08/16','2013/09/08')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (17,5,'2013/09/07','2013/09/23')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (17,1,'2013/09/08','2013/10/17')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (18,2,'2013/09/18',NULL)
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (18,4,'2013/09/19','2013/10/21')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (19,6,'2013/10/22','2013/11/15')
INSERT INTO [dbo].[Loans] ([BookId],[AffiliatedId],[LoanDate],[ReturnDate]) VALUES (18,8,'2013/12/01',NULL)

/*#EASYQUERY: Insert loans*/

/* Author's photo*/

INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 1,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Isaac Asimov.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Isaac Asimov.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 2,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Orson Scott Card.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Orson Scott Card.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 3,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Carl Sagan.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Carl Sagan.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 4,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Alfred Van Vogt.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Alfred Van Vogt.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 5,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Stephen King.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Stephen King.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 6,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Robert Silverberg.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Robert Silverberg.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 7,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Richard Dawkins.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Richard Dawkins.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 8,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Basil Liddel Hart.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Basil Liddel Hart.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 9,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Stephen Gould.png', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Stephen Gould.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 10,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Steven Pinker.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Steven Pinker.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 11,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Edward Wilson.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Edward Wilson.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 12,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Charles Darwin.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Charles Darwin.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 13,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Dante Alighieri.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Dante Alighieri.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 14,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Alessandro Manzoni.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Alessandro Manzoni.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 15,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\John Tolkien.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\John Tolkien.txt', SINGLE_CLOB) AS [Biography]
INSERT INTO [dbo].[AuthorsNote] ([AuthorId],[Photo],[Biography]) 
	SELECT 16,* FROM
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Photo\Patricia Cornwell.jpg', SINGLE_BLOB) AS [Photo],
	OPENROWSET(BULK'E:\_Library\AuthorsNote\Biography\Patricia Cornwell.txt', SINGLE_CLOB) AS [Biography]

/*#EASYQUERY: Insert authors note*/

