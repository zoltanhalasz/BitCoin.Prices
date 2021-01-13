/*  
Create BitCoinPrices table
*/

CREATE TABLE [dbo].[BitCoinPrices](
	[PricesId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_BitCoinPrices] PRIMARY KEY CLUSTERED 
  (
	[PricesId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[BitCoinPrices] WITH CHECK ADD CONSTRAINT [FK_BitCoinPrices_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO

INSERT INTO [dbo].[Job] ([Name],[JobType],[Frequency],[Interval],[StartDate],[EndDate],[IsEnabled],[IsStarted],[IsExecuting],[NextExecution],[RetentionHistory],[CreatedBy],[CreatedOn],[ModifiedBy],[ModifiedOn])
VALUES ('BTC Price', 'BitCoin.Prices.Jobs.BTCJob, BitCoin.Prices.Server.Oqtane', 'd', 1, null, null, 0, 0, 0, null, 10, '', getdate(), '', getdate())
GO