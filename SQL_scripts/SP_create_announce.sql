Use GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Alter PROCEDURE SP_create_announce
	@Name nvarchar(50),
	@SubName nvarchar(50),
	@Desc text,
	@UserID int,
	@StartDate datetime2,
	@EndDate datetime2,
	@Vues int,
	@UserValid binary,
	@AdminValid binary,
	@CreateDate datetime2,
	@AddressPays nvarchar(50),
	@AddressVille nvarchar(50),
	@AddressRue nvarchar(50),
	@AddressCodePostal nvarchar(50),
	@AddressNumero nvarchar(50)

AS
BEGIN
	
	Insert into Announces
	([Name], SubName, [Desc], UserID,
	StartDate, EndDate, Vues, UserValid,
	AdminValid, CreateDate, AddressPays,
	AddressVille, AddressRue, AddressCodePostal, AddressNumero)

	


	Values( @Name, @SubName, @Desc,
			@UserID, @StartDate, @EndDate,
			@Vues, @UserValid, @AdminValid,
			@CreateDate, @AddressPays, @AddressVille,
			@AddressRue, @AddressCodePostal, @AddressNumero)

	Select CAST(SCOPE_IDENTITY() as int)


END
GO
