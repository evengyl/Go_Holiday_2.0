USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_get_ListActivity_by_AnnID]    Script Date: 25-05-20 13:38:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter PROCEDURE [dbo].[SP_get_ListCommoditer_by_AnnID]
	@AnnID int
AS
BEGIN
	SELECT Com.[Name], Com.[Text], Com.Icon, Com.ComID

	FROM Commoditer AS Com, 
		MTM_Announces_Commoditer AS MTM

	WHERE MTM.Commoditer_ComID = Com.ComID AND
			MTM.Announces_AnnID = @AnnID
END
