Use GoHoliday
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE SP_get_TypeHoliday_by_AnnID
	@AnnID int
AS
BEGIN
	SELECT TypeHoliday.[Name], TypeHoliday.IconDiv, TypeHoliday.[Image], TypeHoliday.[Text], TypeHoliday.TypeID
	FROM TypeHoliday, MTM_Announces_TypeHoliday
	WHERE MTM_Announces_TypeHoliday.TypeHoliday_TypeID = TypeHoliday.TypeID AND
			MTM_Announces_TypeHoliday.Announces_AnnID = @AnnID
END
GO
