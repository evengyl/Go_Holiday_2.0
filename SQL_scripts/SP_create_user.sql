USE [GoHoliday]
GO
/****** Object:  StoredProcedure [dbo].[SP_create_user]    Script Date: 14-05-20 13:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[SP_create_user]
    @LastName varchar(255),
    @FirstName varchar(255),
	@Password nvarchar(50),
	@Email nvarchar(150)
AS
BEGIN
	Insert into [Users] (LastName, FirstName, [Password], Email)
	values (@LastName, @FirstName, HASHBYTES('SHA2_512',dbo.Salt() + @Password + dbo.Salt()), @Email)
END