CREATE TABLE [dbo].[TodoList] (
	[IDTodo] [int] IDENTITY(1, 1) NOT NULL CONSTRAINT PK_Todo PRIMARY KEY,
	[Name] [nvarchar] (256) NULL,
	[Done] [bit] NULL,
	[Data] [datetime] NULL
)