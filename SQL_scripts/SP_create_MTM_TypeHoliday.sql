USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_create_MTM_TypeHoliday]    Script Date: 27-05-20 12:32:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_create_MTM_TypeHoliday]
	@AnnID int,
	@TypeHolidayID int
AS
BEGIN
	INSERT INTO MTM_Announces_TypeHoliday
	( Announces_AnnID, TypeHoliday_TypeID )
	VALUES ( @AnnID, @TypeHolidayID )
END
