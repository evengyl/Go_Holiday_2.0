USE [GoHoliday]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_change_password]
	@UserID int,
	@Password nvarchar(64)
AS
BEGIN
	UPDATE Users
	SET [Password] = HASHBYTES('SHA2_512' , dbo.Salt() + @Password + dbo.Salt())
	WHERE UserID = @UserID
END