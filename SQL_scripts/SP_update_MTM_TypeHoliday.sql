USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_update_MTM_TypeHoliday]    Script Date: 27-05-20 12:33:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_update_MTM_TypeHoliday]
	@AnnID int,
	@TypeHolidayID int
AS
BEGIN
	EXEC [dbo].[SP_create_MTM_TypeHoliday] @AnnID, @TypeHolidayID
END
