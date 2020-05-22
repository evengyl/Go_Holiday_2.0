Use GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE SP_get_TypeHabitat_by_AnnID 
	@AnnID int
AS
BEGIN
	SELECT TypeHabitat.[Name], TypeHabitat.[Image], TypeHabitat.[Text], TypeHabitat.TypeID
	FROM TypeHabitat, MTM_Announces_TypeHabitat
	WHERE MTM_Announces_TypeHabitat.TypeHabitat_TypeID = TypeHabitat.TypeID AND
			MTM_Announces_TypeHabitat.Announces_AnnID = @AnnID
END
GO
