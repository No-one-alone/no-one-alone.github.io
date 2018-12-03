-- Takes the tables down
--DROP TABLE [dbo].[Requests];
ALTER TABLE Items DROP CONSTRAINT [FK_dbo.Items]; -- change name

ALTER TABLE Bids DROP CONSTRAINT [FK_dbo.Bids]; -- change name

ALTER TABLE Bids DROP CONSTRAINT [FK2_dbo.Bids]; -- change name


DROP TABLE [dbo].[Bids];
DROP TABLE [dbo].[Items];

DROP TABLE [dbo].[Buyers];
DROP TABLE [dbo].[Sellers];

