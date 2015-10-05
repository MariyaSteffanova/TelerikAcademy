SELECT FirstName + ' ' + LastName AS Name, a.AddressText
FROM Employees e
INNER JOIN Addresses a
ON e.AddressID = a.AddressID