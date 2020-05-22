USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_get_ListSport_by_AnnID]    Script Date: 22-05-20 10:21:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter PROCEDURE [dbo].[SP_get_ListActivity_by_AnnID]
	@AnnID int
AS
BEGIN
	SELECT LA.[Name], LA.[Desc], LA.ActivityID

	FROM ListActivity AS LA, 
		MTM_Announces_ListActivity AS MTM

	WHERE MTM.ListActivity_ActivityID = LA.ActivityID AND
			MTM.Announces_AnnID = @AnnID
END
