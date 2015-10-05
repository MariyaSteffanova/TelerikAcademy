SELECT FirstName + ' ' + LastName AS Name, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = A.AddressID