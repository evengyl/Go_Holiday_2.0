USE GoHoliday
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


alter PROCEDURE SP_create_MTM_commoditer
	@AnnID int,
	@CommoditerID int
AS
BEGIN
	INSERT INTO MTM_Announces_Commoditer
	( Announces_AnnID, Commoditer_ComID )
	VALUES ( @AnnID, @CommoditerID )
END
GO
