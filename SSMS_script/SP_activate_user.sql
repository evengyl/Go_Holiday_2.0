USE [GoHoliday]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_activate_user]
	@UserID int
AS
BEGIN
	UPDATE Users
	SET Active = 'True'
	WHERE UserID = @UserID
END