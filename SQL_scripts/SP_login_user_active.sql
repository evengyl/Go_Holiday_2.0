GO
Use [GoHoliday]
Go
DROP PROCEDURE dbo.SP_login_user_active;  
GO  


CREATE PROCEDURE [dbo].SP_login_user_active
	@Email nvarchar(150)
AS
BEGIN
	SELECT UserID
	FROM [Users]
	WHERE Active = 'False'
END