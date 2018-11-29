-- Takes the tables down
--DROP TABLE [dbo].[Requests];

ALTER TABLE Items DROP CONSTRAINT [FK_dbo.Items]; -- change name
ALTER TABLE Bids DROP CONSTRAINT [FK_dbo.Bids]; -- change name
ALTER TABLE Bids DROP CONSTRAINT [FK2_dbo.Bids]; -- change name

DROP TABLE Buyers;
DROP TABLE Sellers;
DROP TABLE Items;
DROP TABLE Bids;