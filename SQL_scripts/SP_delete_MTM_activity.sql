USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_update_MTM_activity]    Script Date: 27-05-20 11:54:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


alter PROCEDURE [dbo].[SP_delete_MTM_activity]
	@AnnID int
AS
BEGIN
	DELETE FROM MTM_Announces_ListActivity WHERE Announces_AnnID = @AnnID
END
