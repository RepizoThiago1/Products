--where Quantity > 0 
--and IsActive = 1

select * from [dbo].Products
where Id = 2
UPDATE [dbo].Products SET Quantity = (SELECT Quantity FROM [dbo].Products WHERE id = 2) - 9
select * from [dbo].Products
where Id = 2

--update [dbo].Products
--set Quantity = (select Quantity from [dbo].Products where id = 2) + 270

--SELECT SUM(Price * 12) AS TotalPrice FROM [dbo].Products
--WHERE name = 'Pilha' AND Quantity > 0 AND IsActive = 1


--update [dbo].Products
--set IsActive = 0
--where Id = 5