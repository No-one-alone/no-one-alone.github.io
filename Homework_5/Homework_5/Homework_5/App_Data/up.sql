-- Creates the Requests table for users.
CREATE TABLE [dbo].[Requests]
(
	[ID]		          INT IDENTITY (1,1)	NOT NULL, -- Integer primary key for indexing.
	[FirstName]	          NVARCHAR(48)		    NOT NULL, -- Holds first name of requester.
	[LastName]	          NVARCHAR(48)		    NOT NULL, -- Holds last name of requester.
	[PhoneNumber]         NVARCHAR(12)		    NOT NULL, -- Holds phone number of requester.
	[ApartmentName]       NVARCHAR(48)		    NOT NULL, -- Holds apartment name of requester.
	[UnitNumber]          INT		            NOT NULL, -- Holds unit i.e. apartment number of requester.
	[RequestExplanation]  NVARCHAR(MAX)		    NOT NULL, -- Holds explanation given by requester.
	[Permission]          BIT					NOT NULL, -- 1 for Yes and 0 for No.

	[DateTimeOfRequest]   DateTime			    NOT NULL, -- Holds time stamp of when request was made and submitted.

	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC) -- Prevents table from being dropped if relations with foreign keys are present.
);

-- Inserts seed Request entries to populate table.
INSERT INTO [dbo].[Requests] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, RequestExplanation, Permission, DateTimeOfRequest) VALUES
	('Khorben','Boyer','503-522-8328','Ridge',123, 'Water everywhere. FIX IT!', 1,'2000-08-22 00:00:00'),
	('Revan','DarkSider','503-540-2382','Korriban',666, 'The Darkside is everywhere!', 0,'2004-12-01 02:30:20'),
	('Obiwan','Kenobi','503-451-7729','Coruscant',248, 'Trust in the Force!', 1,'2001-09-20 00:00:00'),
	('Mace','Windu','503-630-5841','Genosis',000, 'This party is over!', 0,'2008-08-13 01:01:03'),
	('Yoda','...','503-342-6874','Jedi Temple',999, 'Long night, this, will be!', 1,'1999-12-22 01:20:13')
	
GO -- This is an SQL command batch terminator.

-- The commented out SQL statement below was used to examine the resultant Requests table and ensure it matched specification.
--SELECT * FROM dbo.Requests