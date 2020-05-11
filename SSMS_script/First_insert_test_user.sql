set identity_insert Users on;

insert into Users
 (UserID, LastName, FirstName, [Password], Email)
 Values (1, 'Baudoux', 'Loic', HASHBYTES('SHA2_512',dbo.Salt() + 'legends' + dbo.Salt()), 'dark.evengyl@gmail.com')
 
 set identity_insert Users off;


 insert into AddressUser
  (UserID, Ville, Rue, Pays, Numero, CodePostal)
  VALUES(1, 'labuissiere', 'jean jaures', 'belgique', '12', 6567)



  insert into ComplementUser
	(UserID, Gsm, Phone, Benefice, TotalPrice_InLocate, TotalPrice_InAttemps)
	Values(1, '0497312523', null, 500, 1500, 2500)



