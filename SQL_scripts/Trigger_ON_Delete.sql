Create TRIGGER [dbo].[GoHoliday]
On [Users]
Instead of DELETE
as 
begin
	Update [Users] set Active = 0 where UserID in (Select UserID from inserted)
	end