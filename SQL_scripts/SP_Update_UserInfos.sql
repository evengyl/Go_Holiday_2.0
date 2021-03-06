USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_Update_UserInfos]    Script Date: 22-05-20 15:58:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_Update_UserInfos]
	@UserID int,
	@LastName nvarchar(255) = null,
	@FirstName nvarchar(255) = null,
	@Email nvarchar(150) = null,
	@Rue nvarchar(100) = null,
	@Numero nvarchar(10) = null,
	@CodePostal int = null,
	@Ville nvarchar(100) = null,
	@Pays nvarchar(50) = null,
	@Gsm nvarchar(50) = null,
	@Phone nvarchar(50) = null
AS
BEGIN
	UPDATE Users
	SET LastName = @LastName, @FirstName = @FirstName, Email = @Email
	WHERE UserID = @UserID


	UPDATE AddressUser
	SET Rue = @Rue, Numero = @Numero, CodePostal = @CodePostal, Ville = @Ville, Pays = @Pays
	WHERE UserID = @UserID


	UPDATE ComplementUser
	SET Gsm = @Gsm, Phone = @Phone
	WHERE UserID = @UserID

END
