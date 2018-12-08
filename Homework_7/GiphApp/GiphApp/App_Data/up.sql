
-- this is our script to create the table for the database.
CREATE TABLE [dbo].[SearchRequests]
(
	[ID]					    INT IDENTITY (1,1)	NOT NULL, -- our ID field
	[RequestWord]				NVARCHAR(120)		NOT NULL, -- our Field for "interesting" word requests
	[IPAddressOfRequestor]		NVARCHAR(50)		NOT NULL, -- our field for the ip address of the client
	[ClientBrowserAgentType] 	NVARCHAR(256)		NOT NULL, -- our field for the browser type used by the client.
	[TimeStamp] 				DATETIME			NOT NULL, -- our filed for storing time stamps of when requests were submitted.

	CONSTRAINT [PK_dbo.SearchRequests] PRIMARY KEY CLUSTERED ([ID] ASC) -- a constraint to ensure the table isn't dropped if key is used a foreign key in another table.
);

GO -- ensures commnad execution.

SELECT * FROM [dbo].[SearchRequests] -- allows us to view the log of requests stored in the database.