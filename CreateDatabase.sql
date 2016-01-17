USE master
GO

CREATE DATABASE Trackin
ON ( 
	NAME = Trackin_dat,
	FILENAME = 'C:\Projects\Trackin.mdf'
)
LOG ON (
	NAME = Trackin_log,
	FILENAME = 'C:\Projects\Trackin.ldf'
)
GO

USE [Trackin]
GO

CREATE TABLE [dbo].[Transactions](
	[Id] [bigint] NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Amount] [money] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Tags] [varchar](100) NULL,
	[AccountName] varchar(50) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[SaveTransaction]
	 @TransactionID bigint
	,@Description varchar(250)
	,@Amount money
	,@Date datetime
	,@Tags varchar(100)
	,@AccountName varchar(50)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Transactions WHERE ID = @TransactionID) BEGIN
		INSERT INTO Transactions(ID
			, [Description]
			, Amount
			, [Date]
			, Tags
			, AccountName)
		VALUES (@TransactionID
			, @Description
			, @Amount
			, @Date
			, @Tags
			, @AccountName)
	END
	ELSE BEGIN
		UPDATE Transactions 
		SET [Description] = @Description
			,Amount       = @Amount
			,[Date]       = @Date
			,Tags         = @Tags
			,AccountName  = @AccountName
			,ModifiedOn   = GETDATE() 
		WHERE ID = @TransactionID
	END
END
GO

CREATE PROCEDURE [dbo].[GetAllTransactions]
AS
BEGIN
	SELECT * FROM Transactions WITH(NOLOCK)
END
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_CreatedOn]  DEFAULT (GETDATE()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_ModifiedOn]  DEFAULT (GETDATE()) FOR [ModifiedOn]
GO
