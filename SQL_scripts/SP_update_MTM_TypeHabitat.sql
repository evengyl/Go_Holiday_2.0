USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_update_MTM_TypeHabitat]    Script Date: 27-05-20 12:33:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_update_MTM_TypeHabitat]
	@AnnID int,
	@TypeHabitatID int
AS
BEGIN
	EXEC [dbo].[SP_create_MTM_TypeHabitat] @AnnID, @TypeHabitatID
END
