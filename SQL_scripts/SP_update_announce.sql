Use GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


alter PROCEDURE SP_update_announce
	@Name nvarchar(50),
	@SubName nvarchar(50),
	@Desc text,
	@StartDate datetime2,
	@EndDate datetime2,
	@AddressPays nvarchar(50),
	@AddressVille nvarchar(50),
	@AddressRue nvarchar(50),
	@AddressCodePostal nvarchar(50),
	@AddressNumero nvarchar(50),
	@AnnID int

AS
BEGIN
	UPDATE Announces 
	SET 
		[Name] = @Name,
		SubName = @SubName,
		[Desc] = @Desc,
		StartDate = @StartDate,
		EndDate = @EndDate,
		AddressPays = @AddressPays,
		AddressVille = @AddressVille,
		AddressRue = @AddressRue,
		AddressCodePostal = @AddressCodePostal,
		AddressNumero = @AddressNumero
		
	WHERE AnnID = @AnnID
END
GO
