USE TelerikAcademy

SELECT 
	Employee = e.FirstName + ' ' + e.LastName,
	'Manager' = m.FirstName + ' ' + m.LastName,
	[Address] = a.AddressText
FROM Employees e, Employees m, Addresses a
WHERE e.ManagerID = m.EmployeeID 
	AND e.AddressID = a.AddressID