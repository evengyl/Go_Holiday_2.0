if (SELECT count(name) FROM sys.databases WHERE name LIKE '%GoHoliday%') = 0 
BEGIN
	CREATE DATABASE TEST
END
GO


USE GoHoliday
GO 




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'FK_ADDRESS_USER') AND type in (N'U'))
BEGIN 
	ALTER TABLE dbo.AddressUser DROP CONSTRAINT FK_ADDRESS_USER
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'FK_COMPLEMENT_USER') AND type in (N'U'))
BEGIN 
	ALTER TABLE dbo.AddressUser DROP CONSTRAINT FK_COMPLEMENT_USER
END
GO

DROP TABLE dbo.Users, dbo.AddressUser, dbo.ComplementUser;  
GO  
use GoHoliday
GO  

CREATE TABLE Users (
    UserID int identity,
    LastName nvarchar(255),
    FirstName nvarchar(255),
	[Password] varbinary(64),
	Email nvarchar(150) unique,
	Active bit DEFAULT 'False',
	ComplementID int,
	AddressID int,
	
	PRIMARY KEY(UserID),
);


go


CREATE TABLE AddressUser (
	UserID int,
	Rue nvarchar(100),
	Ville nvarchar(100),
	Pays nvarchar(50),
	Numero nvarchar(10),
	CodePostal int,

	PRIMARY KEY(UserID),
	CONSTRAINT FK_ADDRESS_USER FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


Go



CREATE TABLE ComplementUser(
	UserID int,
	Gsm nvarchar(50) unique,
	Phone nvarchar(50) unique,
	Benefice int not null,
	TotalPrice_InLocate int not null,
	TotalPrice_InAttemps int not null,
	
	PRIMARY KEY(UserID),
	CONSTRAINT FK_COMPELMENT_USER FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

Go


