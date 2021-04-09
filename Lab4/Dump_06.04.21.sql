-- 1. ������� ������� 

CREATE TABLE [dbo].[Customer] (
	[CustomerId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Author PRIMARY KEY,
	[Name] [nvarchar](256) NULL,
	[City] [nvarchar](256) NOT NULL  )

CREATE TABLE [dbo].[Order] (
	[OrderId] [int] IDENTITY(1,1) NOT NULL CONSTRAINT PK_Order PRIMARY KEY,
	[ProductName] [nvarchar](256) NULL,
	[Price] [decimal] NOT NULL, 
	[CustomerId] [int] NOT NULL )

-- 2. ��������� ���� � Management Studio.

INSERT INTO [Customer]([Name], [City])
VALUES( N'������� ���� �������', '������' ),
( N'����� ������ ����������', '������-���' ),
( N'������ ������ �������������', '������' )

INSERT INTO [Order]([ProductName], [Price], [CustomerId])
VALUES ('��������', 100, 1), ('������', 50, 1), ('������', 30, 1)

INSERT INTO [Order]([ProductName], [Price], [CustomerId])
VALUES ('������', 300, 2), ('�����', 50, 2)

INSERT INTO [Order]([ProductName], [Price], [CustomerId])
VALUES ('�����', 70, 3), ('�����', 500, 3)

-- 3 � ������� ������� ����� �� ������ ���

UPDATE [Customer] 
SET [City] = '������-���'
WHERE CustomerID = 3

-- 4. � ������� ������� ����� �� ����� 

DELETE FROM [Order] 
WHERE [OrderId] = 8 AND [CustomerId] = 3

DELETE FROM [Order] 
WHERE [OrderId] = 8 AND [CustomerId] = 3