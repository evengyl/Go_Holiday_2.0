USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_user_infos]    Script Date: 22-05-20 15:42:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_user_infos]
	@UserID int
AS
BEGIN
	SELECT *

	FROM [UserInfos]
		

	WHERE UserID = @UserID
END