USE GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


alter PROCEDURE SP_delete_MTM_TypeHabitat
	@AnnID int
AS
BEGIN
	DELETE FROM MTM_Announces_TypeHabitat WHERE Announces_AnnID = @AnnID
END
GO
