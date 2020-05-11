GO
Use [GoHoliday]
Go
DROP PROCEDURE dbo.SP_login_user;  
GO  

CREATE PROCEDURE [dbo].SP_login_user
	@Password nvarchar(50),
	@Email nvarchar(150)
AS
BEGIN
	SELECT U.UserID, U.LastName, U.FirstName, U.Email,
			A.Rue, A.Ville, A.Pays, A.Numero, A.CodePostal,
			C.Gsm, C.Phone, C.Benefice, C.TotalPrice_InLocate, C.TotalPrice_InAttemps

	FROM [Users] AS U
		FULL OUTER JOIN AddressUser AS A ON U.UserID = A.UserID
		FULL OUTER JOIN ComplementUser AS C ON U.UserID = C.UserID
		

	WHERE [Password] = HASHBYTES('SHA2_512' , dbo.Salt() + @Password + dbo.Salt()) AND Email = @Email AND Active = 'True'
END