USE GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE SP_create_MTM_sport
	@AnnID int,
	@SportID int
AS
BEGIN
	INSERT INTO MTM_Announces_ListSport
	( Announces_AnnID, ListSport_SportID )
	VALUES ( @AnnID, @SportID )
END
GO
