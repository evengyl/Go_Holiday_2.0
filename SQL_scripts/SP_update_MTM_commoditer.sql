USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_update_MTM_commoditer]    Script Date: 27-05-20 12:32:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_update_MTM_commoditer]
	@AnnID int,
	@CommoditerID int
AS
BEGIN
	EXEC [dbo].[SP_create_MTM_commoditer] @AnnID, @CommoditerID
END
