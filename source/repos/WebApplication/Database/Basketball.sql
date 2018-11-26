CREATE TABLE [dbo].[Basketball]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Time] nvarchar(100), 
	[Date] nvarchar(100), 
	[NewDate] DATETIME,
	[Passed] int,
	[Venue] nvarchar(100), 
	[PaidCourtId] nvarchar(100),
	[PaidAmmount] money
)
