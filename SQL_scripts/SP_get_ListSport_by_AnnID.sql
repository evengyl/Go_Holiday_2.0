USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_get_TypeHoliday_by_AnnID]    Script Date: 22-05-20 10:12:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter PROCEDURE [dbo].[SP_get_ListSport_by_AnnID]
	@AnnID int
AS
BEGIN
	SELECT LS.[Name], LS.[Desc], LS.SportID

	FROM ListSport AS LS, 
		MTM_Announces_ListSport AS MTM

	WHERE MTM.ListSport_SportID = LS.SportID AND
			MTM.Announces_AnnID = @AnnID
END
