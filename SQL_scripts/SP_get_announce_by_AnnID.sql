/****** Object:  StoredProcedure [dbo].[SP_get_announce_by_AnnID]    Script Date: 25-05-20 15:27:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_get_announce_by_AnnID]
	@AnnID int = 0
AS
BEGIN
	
	IF(@AnnID = 0)
		BEGIN
			SELECT * FROM Announces WHERE 1 = 1
		End
	ELSE
		BEGIN
			SELECT * FROM Announces WHERE AnnID = @AnnID
		END
END