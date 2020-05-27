USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_create_MTM_TypeHabitat]    Script Date: 27-05-20 12:31:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_create_MTM_TypeHabitat]
	@AnnID int,
	@TypeHabitatID int
AS
BEGIN
	INSERT INTO MTM_Announces_TypeHabitat
	( Announces_AnnID, TypeHabitat_TypeID )
	VALUES ( @AnnID, @TypeHabitatID )
END
