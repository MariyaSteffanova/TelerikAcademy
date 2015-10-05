USE TelerikAcademy

SELECT 
	Employee = e.FirstName + ' ' + e.LastName,
	Department = d.Name,
	FORMAT(e.HireDate,'yyyy-MM-dd') AS D
FROM Employees e, Departments d
WHERE d.Name IN ('Sales','Finance')
AND e.HireDate BETWEEN '1995-01-01' AND '2005/01/01'

-- Note that you can use different connecting symbols in the date. 
-- Note also that date should be always written as string. 1995-01-01 is not recognizable, but '1995-01-01' is.
