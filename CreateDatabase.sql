USE [Trackin]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 07/29/2012 20:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [bigint] NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Amount] [money] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Tags] [varchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[SaveTransaction]    Script Date: 07/29/2012 20:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveTransaction]
	 @TransactionID bigint
	,@Description varchar(250)
	,@Amount money
	,@Date datetime
	,@Tags varchar(100)
AS
BEGIN
	IF NOT EXISTS (select 1 from Transactions where ID = @TransactionID) BEGIN
		INSERT INTO Transactions(ID, [Description], Amount, [Date], Tags)
		VALUES (@TransactionID, @Description, @Amount, @Date, @Tags)
	END
	ELSE BEGIN
		UPDATE Transactions 
		SET [Description] = @Description
			,Amount  = @Amount
			,[Date]  = @Date
			,Tags    = @Tags
			,ModifiedOn = GETDATE() 
		WHERE ID = @TransactionID
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllTransactions]    Script Date: 07/29/2012 20:35:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllTransactions]
as
begin
	select * from Transactions with(nolock)
end
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO

ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
