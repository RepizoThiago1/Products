--select * from [dbo].Products
--where Quantity > 0 
--and IsActive = 1

--update [dbo].Products
--set Quantity = (select Quantity from [dbo].Products where id = 2) + 270
--where Id = 2

--update [dbo].Products
--set IsActive = 
--where Id = 2

select * from [dbo].Products