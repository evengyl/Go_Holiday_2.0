USE GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


alter PROCEDURE SP_delete_MTM_sport
	@AnnID int
AS
BEGIN
	DELETE FROM MTM_Announces_ListSport WHERE Announces_AnnID = @AnnID
END
GO
