SELECT        dbo.ComplementUser.Gsm, dbo.ComplementUser.Phone, dbo.ComplementUser.Benefice, dbo.ComplementUser.TotalPrice_InLocate, dbo.ComplementUser.TotalPrice_InAttemps, dbo.AddressUser.Rue, dbo.AddressUser.Ville, 
                         dbo.AddressUser.Pays, dbo.AddressUser.Numero, dbo.AddressUser.CodePostal, dbo.Users.Active, dbo.Users.Email, dbo.Users.FirstName, dbo.Users.LastName, dbo.Users.UserID
FROM            dbo.Users INNER JOIN
                         dbo.ComplementUser ON dbo.Users.UserID = dbo.ComplementUser.UserID INNER JOIN
                         dbo.AddressUser ON dbo.Users.UserID = dbo.AddressUser.UserID