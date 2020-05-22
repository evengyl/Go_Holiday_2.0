set identity_insert Announces on;

insert into Announces
 ([Name], SubName, [Desc],
	UserID, StartDate, EndDate,
	Vues, UserValid, AdminValid,
	CreateDate, AddressPays, AddressVille, 
	AddressCodePostal, AddressRue, AddressNumero)
 
 Values ('test 1', 'test sub title', 'petite description',
	'1', sysdatetime(), sysdatetime(),
	'1500', '0', '0',
	SYSDATETIME(), 'Belgique', 'Labuissiere',
	'6567', 'Jean jaurès', '12'
 )
 
 set identity_insert Announces off;






 insert into MTM_Announces_TypeHoliday
 (Announces_AnnID, TypeHoliday_TypeID)
 values
 (1, 1)
 go

 set identity_insert TypeHoliday on;
INSERT INTO TypeHoliday
 (TypeID, [Name], IconDiv, [Image], [Text])
 values
 (1, 'test mtm', 'test icon', 'tata.jpg', 'petit text')
  set identity_insert TypeHoliday off;
  go






 
INSERT INTO MTM_Announces_TypeHabitat
 (Announces_AnnID, TypeHabitat_TypeID)
 values
 (1, 1)
 
 set identity_insert TypeHabitat on;
INSERT INTO TypeHabitat
 (TypeID, [Name], [Image], [Text])
 values
 (1, 'test mtm', 'tata.jpg', 'petit text')
  set identity_insert TypeHabitat off;
  go







INSERT INTO MTM_Announces_Commoditer
 (Announces_AnnID, Commoditer_ComID)
 values
 (1, 1)

  set identity_insert Commoditer on;
  insert into Commoditer
 (ComID, [Name], [Text], [Icon])
 values
 (1, 'test mtm', 'petit text', 'icon test')
  set identity_insert Commoditer off;
  go






  

INSERT INTO MTM_Announces_ListSport
 (Announces_AnnID, ListSport_SportID)
 values
 (1, 1)

 INSERT INTO MTM_Announces_ListActivity
 (Announces_AnnID, ListActivity_ActivityID)
 values
 (1, 1)
 go


  set identity_insert ListSport on;
  insert into ListSport
 (SportID, [Name], [Desc])
 values
 (1, 'test mtm', 'petit text')
  set identity_insert ListSport off;
  go

 set identity_insert ListActivity on;
  insert into ListActivity
 (ActivityID, [Name], [Desc])
 values
 (1, 'test mtm', 'petit text')
  set identity_insert ListActivity off;
  go