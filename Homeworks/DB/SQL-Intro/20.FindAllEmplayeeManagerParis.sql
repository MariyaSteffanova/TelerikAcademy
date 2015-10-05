USE TelerikAcademy

SELECT [Employee] = e.FirstName + ' ' + e.LastName ,
		Manager = m.FirstName + ' ' + m.LastName
FROM Employees e, Employees m
WHERE e.ManagerID = m.EmployeeID