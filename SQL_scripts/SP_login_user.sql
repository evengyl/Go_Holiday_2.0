USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_login_user]    Script Date: 19-05-20 12:00:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_login_user]
	@Password nvarchar(50),
	@Email nvarchar(150)
AS
BEGIN
	SELECT U.UserID, U.LastName, U.FirstName, U.Email, C.TypeUser
	FROM [Users] AS U
	FULL JOIN [ComplementUser] AS C ON U.UserID = C.UserID
	WHERE [Password] = HASHBYTES('SHA2_512' , dbo.Salt() + @Password + dbo.Salt()) AND Email = @Email AND Active = 'True'
END 