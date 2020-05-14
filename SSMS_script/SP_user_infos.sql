USE [GoHoliday]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_user_infos]
	@UserID int
AS
BEGIN
	SELECT U.UserID, U.LastName, U.FirstName, U.Email,
			A.Rue, A.Ville, A.Pays, A.Numero, A.CodePostal,
			C.Gsm, C.Phone, C.Benefice, C.TotalPrice_InLocate, C.TotalPrice_InAttemps

	FROM [UsersInfos] AS U
		FULL OUTER JOIN AddressUser AS A ON U.UserID = A.UserID
		FULL OUTER JOIN ComplementUser AS C ON U.UserID = C.UserID
		

	WHERE U.UserID = @UserID
END