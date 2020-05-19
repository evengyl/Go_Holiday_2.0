USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_login_user]    Script Date: 13-05-20 15:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_verify_if_exist_user]
	@Email nvarchar(150)
AS
BEGIN
	SELECT U.UserID
	FROM [Users] AS U
	WHERE Email = @Email AND Active = 'True'
END