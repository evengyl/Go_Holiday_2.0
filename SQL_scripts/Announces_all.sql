use GoHoliday
GO  

drop table Announces
go
create TABLE Announces (
    AnnID int identity,
    [Name] nvarchar(255),
    SubName nvarchar(255),
	[Desc] nvarchar(255),
	TypeHabitatID int,
	UserID int,
	StartDate date,
	EndDate date,
	Vues int,
	UserValid bit DEFAULT 'False',
	AdminValid bit DEFAULT 'False',
	CreateDate date,
	AddressPays nvarchar(255),
	AddressVille nvarchar(255),
	AddressRue nvarchar(255),
	AddressNumero nvarchar(255),
	
	PRIMARY KEY(AnnID)
);
go




CREATE TABLE MTM_Announces_TypeHoliday (
    Announces_AnnID int not null,
    TypeHoliday_TypeID int not null,

);


CREATE TABLE TypeHoliday (
    TypeID int identity,
	[Name] nvarchar(20),
	IconDiv nvarchar(255),
	[Image] nvarchar(50),
	[Text] text,
	
	PRIMARY KEY(TypeID)
);







CREATE TABLE TypeHabitat (
    TypeID int identity,
	[Name] nvarchar(20),
	[Image] nvarchar(50),
	[Text] text,
	
	PRIMARY KEY(TypeID)
);

CREATE TABLE MTM_Announces_TypeHabitat (
    Announces_AnnID int not null,
    TypeHabitat_TypeID int not null,

);






CREATE TABLE Commoditer (
    ComID int identity,
	[Name] nvarchar(20),
	[Text] text,
	Icon nvarchar(255),
	
	PRIMARY KEY(ComID)
);
CREATE TABLE MTM_Announces_Commoditer (
    Announces_AnnID int not null,
    Commoditer_ComID int not null,

);



CREATE TABLE ListSport (
    SportID int identity,
	[Name] nvarchar(30),
	[Desc] text,
	
	PRIMARY KEY(SportID)
);
CREATE TABLE MTM_Announces_ListSport (
    Announces_AnnID int not null,
    ListSport_SportID int not null,

);





CREATE TABLE ListActivity (
    ActivityID int identity,
	[Name] nvarchar(30),
	[Desc] text,
	
	PRIMARY KEY(ActivityID)
);
CREATE TABLE MTM_Announces_ListActivity (
    Announces_AnnID int not null,
    ListActivity_ActivityID int not null,

);






CREATE TABLE ReserveHoliday (
    ReserveID int identity,
	DateEntree date,
	DateSortie date,
	Caution int,
	NbPersonnes int,
	UserID int,
	[State] bit DEFAULT 'False',
	AnnID int,
	
	PRIMARY KEY(ReserveID)
);



CREATE TABLE AvisHoliday (
    AvisID int identity,
	AnnID int,
	UserID int,
	Avis text,
	Note int,
	CreateDate date,
	
	PRIMARY KEY(AvisID)
);
