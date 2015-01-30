--Write an SQL query that finds the customer id, first name and total order sum for each
--customer that is registered for the newsletter. 

select c.Id, c.FirstName, sum(ol.Quantity * i.Price) as TotalOrderSum
from Customer c join [Order] o on c.Id = o.CustomerId join OrderLine ol on ol.OrderNumber = o.OrderNumber join Item i on i.Id = ol.ItemId
where RegisteredForNewsLetter = 1
group by c.Id, c.FirstName

--Write an SQL query that finds the first names of all the customers that have ordered
--products from HP but not from LG. Each name should be displayed only once. 

select c.FirstName
from Customer c join [Order] o on c.Id = o.CustomerId join OrderLine ol on ol.OrderNumber = o.OrderNumber join Item i on i.Id = ol.ItemId
where Brand in ('HP') and c.Id not in (select c.Id
									   from Customer c join [Order] o on c.Id = o.CustomerId join OrderLine ol on ol.OrderNumber = o.OrderNumber join Item i on i.Id = ol.ItemId
									   where Brand in ('LG'))