RESTORE FILELISTONLY  
FROM DISK = 'C:\96-DotNet\Northwind.bak\northwind.bak'  
GO  



RESTORE DATABASE Northwind  
FROM DISK = 'C:\96-DotNet\Northwind.bak\northwind.bak'  
WITH MOVE 'Northwind' TO 'c:\96-DotNet\nw\northwind.mdf',  
MOVE 'Northwind_log' TO 'c:\96-DotNet\nw\northwind.ldf'  
