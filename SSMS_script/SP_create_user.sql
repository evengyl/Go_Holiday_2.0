GO
Use [GoHoliday]
Go
DROP PROCEDURE dbo.[SP_create_user];  
GO  

CREATE PROCEDURE [dbo].[SP_create_user]
    @LastName varchar(255),
    @FirstName varchar(255),
	@Password nvarchar(50),
	@Email nvarchar(150),
	@UserID int output
AS
BEGIN
	Insert into [Users] (LastName, FirstName, [Password], Email)
	values (@LastName, @FirstName, HASHBYTES('SHA2_512',dbo.Salt() + @Password + dbo.Salt()), @Email)
	SET @UserID=SCOPE_IDENTITY()
    RETURN  @UserID

END