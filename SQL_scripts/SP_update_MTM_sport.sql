USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_update_MTM_sport]    Script Date: 27-05-20 12:33:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_update_MTM_sport]
	@AnnID int,
	@SportID int
AS
BEGIN
	EXEC [dbo].[SP_create_MTM_sport] @AnnID, @SportID
END
