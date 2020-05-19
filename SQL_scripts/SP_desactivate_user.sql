USE [GoHoliday]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_desactivate_user]
	@UserID int
AS
BEGIN
	UPDATE Users
	SET Active = 'False'
	WHERE UserID = @UserID
END