CREATE TABLE [dbo].[SearchRequests]
(
	[ID]						INT IDENTITY (1,1)	NOT NULL,
	[RequestWord]				NVARCHAR(120)		NOT NULL,
	[IPAddressOfRequestor]		NVARCHAR(50)		NOT NULL,
	[ClientBrowserAgentType] 	NVARCHAR(256)		NOT NULL,
	[TimeStamp] 				DATETIME			NOT NULL,

	CONSTRAINT [PK_dbo.SearchRequests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

GO

SELECT * FROM [dbo].[SearchRequests]