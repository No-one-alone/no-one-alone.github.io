-- Creates the tables for Auction House database.

CREATE TABLE [dbo].[Buyers]
(
	[ID]		      INT IDENTITY (1,1)	NOT NULL, -- Integer primary key for indexing.	
	[BuyerName]	      NVARCHAR(80)		    NOT NULL, -- Holds first name of requester.

	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED ([ID] ASC)-- Prevents table from being dropped if relations with foreign keys are present.
);

CREATE TABLE [dbo].[Sellers]
(
	[ID]		      INT IDENTITY (1,1)	NOT NULL, -- Integer primary key for indexing.
	[SellerName]	  NVARCHAR(80)		    NOT NULL, -- Holds first name of requester.

	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED ([ID] ASC) -- Prevents table from being dropped if relations with foreign keys are present.
);

CREATE TABLE [dbo].[Items]
(
	[ID]		      INT IDENTITY (1001,1)	NOT NULL, -- Integer primary key for indexing.
	[ItemName]	      NVARCHAR(100)		    NOT NULL, -- 
	[Description]	  NVARCHAR(200)		    NOT NULL, --
	[SellerID]	      INT					NOT NULL, -- 

	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED ([ID] ASC), -- Prevents table from being dropped if relations with foreign keys are present.
	CONSTRAINT [FK_dbo.Items] FOREIGN KEY (SellerID) REFERENCES [dbo].[Sellers]([ID])
);


CREATE TABLE [dbo].[Bids]
(
	[ID]		             INT IDENTITY (1,1)	NOT NULL, -- Integer primary key for indexing.
	[ItemID]				 INT				NOT NULL, 
	[BuyerID]			     INT				NOT NULL, -- 
	[Price]					 DECIMAL			NOT NULL, 
	[TimeStamp]				 DateTime		    NOT NULL -- Holds time stamp of when request was made and submitted.

	CONSTRAINT [PK_dbo.Bids] PRIMARY KEY CLUSTERED ([ID] ASC), -- Prevents table from being dropped if relations with foreign keys are present.
	CONSTRAINT [FK_dbo.Bids] FOREIGN KEY (ItemID) REFERENCES [dbo].[Items](ID),
	CONSTRAINT [FK2_dbo.Bids] FOREIGN KEY (BuyerID) REFERENCES [dbo].[Buyers]([ID])
	

);


-- Inserts seed Request entries to populate table.
INSERT INTO [dbo].[Buyers] (BuyerName) VALUES 
						('Jane Stone'),
						('Tom McMasters'),
						('Otto Vanderwall');

INSERT INTO [dbo].[Sellers] (SellerName) VALUES 
						('Gayle Hardy'),
						('Lyle Banks'),
						('Pearl Greene');

INSERT INTO [dbo].[Items] (ItemName, Description, SellerID) VALUES 
						('Abraham Lincoln Hammer', 'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln', 3),
						('Albert Einsteins Telescope', 'A brass telescope owned by Albert Einstein in Germany, circa 1927', 1),
						('Bob Dylan Love Poems', 'Five versions of an original unpublished, handwritten, love poem by Bob Dylan', 2);

INSERT INTO [dbo].[Bids] (ItemID, BuyerID, Price, TimeStamp) VALUES 
						(1001, 3, 250000,'12/04/2017 09:04:22'),
						(1003, 1, 95000,'12/04/2017 08:44:03');

	
GO -- This is an SQL command batch terminator.

--SELECT * FROM dbo.Bids

--SELECT *
--FROM dbo.Bids, dbo.Buyers
--WHERE dbo.Bids.BuyerID = dbo.Buyers.ID
    
--GO