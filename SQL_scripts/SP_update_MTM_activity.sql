USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_update_MTM_activity]    Script Date: 27-05-20 12:32:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_update_MTM_activity]
	@AnnID int,
	@ActivityID int
AS
BEGIN
	EXEC [dbo].[SP_create_MTM_activity] @AnnID, @ActivityID
END
