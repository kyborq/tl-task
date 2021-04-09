-- 1. Задание создать 

CREATE TABLE [dbo].[Customer] (
	[CustomerId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Author PRIMARY KEY,
	[Name] [nvarchar](256) NULL,
	[City] [nvarchar](256) NOT NULL  )

CREATE TABLE [dbo].[Order] (
	[OrderId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Order PRIMARY KEY,
	[ProductName] [nvarchar](256) NULL,
	[Price] [decimal] NOT NULL, 
	[CustomerId] [int] NOT NULL )

-- 2. Наполнить базу в Management Studio.

INSERT INTO [Customer]([Name], [City])
VALUES( N'Ерёменко Егор Львович', 'Москва' ),
( N'Носов Яромир Викторович', 'Йошкар-Ола' ),
( N'Бобылёв Цезарь Станиславович', 'Москва' )

INSERT INTO [Order]([ProductName], [Price], [CustomerId])
VALUES ('Апельсин', 100, 1), ('Яблоко', 50, 1), ('Огурец', 30, 1)

INSERT INTO [Order]([ProductName], [Price], [CustomerId])
VALUES ('Ананас', 300, 2), ('Лимон', 50, 2)

INSERT INTO [Order]([ProductName], [Price], [CustomerId])
VALUES ('Банан', 70, 3), ('Тыква', 500, 3)

-- 3 У Бобылёва сменить город на Йошкар Ола

UPDATE [Customer] 
SET [City] = 'Йошкар-Ола'
WHERE CustomerID = 3

-- 4. У Бобылёва удалить заказ на Тыкву 

DELETE FROM [Order] 
WHERE [OrderId] = 8 AND [CustomerId] = 3

DELETE FROM [Order] 
WHERE [OrderId] = 8 AND [CustomerId] = 3