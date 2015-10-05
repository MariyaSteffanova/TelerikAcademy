USE TelerikAcademy

SELECT 
	Employee = e.FirstName + ' ' + e.LastName, 
	Manager = m.FirstName + ' ' + m.LastName
FROM Employees e
RIGHT JOIN Employees m
ON e.ManagerID = m.EmployeeID

SELECT 
	Employee = e.FirstName + ' ' + e.LastName, 
	Manager = m.FirstName + ' ' + m.LastName
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID
