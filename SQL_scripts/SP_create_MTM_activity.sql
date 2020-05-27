USE GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


alter PROCEDURE SP_create_MTM_activity
	@AnnID int,
	@ActivityID int
AS
BEGIN
	INSERT INTO MTM_Announces_ListActivity
	( Announces_AnnID, ListActivity_ActivityID )
	VALUES ( @AnnID, @ActivityID )
END
GO
