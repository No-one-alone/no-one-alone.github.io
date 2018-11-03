-- Renters table
CREATE TABLE [dbo].[Users]
(
	[ID]		          INT IDENTITY (1,1)	NOT NULL,
	[FirstName]	          NVARCHAR(64)		NOT NULL,
	[LastName]	          NVARCHAR(128)		NOT NULL,
	[PhoneNumber]         NVARCHAR(128)		NOT NULL,
	[ApartmentName]       NVARCHAR(128)		NOT NULL,
	[UnitNumber]          NVARCHAR(128)		NOT NULL,
	[RequestExplanation]  NVARCHAR(128)		NOT NULL,
	[Permission]          NVARCHAR(128)		NOT NULL,

	[DateTimeOfRequest]   DateTime			NOT NULL,
	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Users] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, RequestExplanation, Permission, DateTimeOfRequest) VALUES
	('Khorben','Boyer','503-522-8328','Ridge','123', 'Water everywhere. FIX IT!', 'Given','2000-08-22 00:00:00'),
	('Revan','DarkSider','503-540-2382','Korriban','666', 'The Darkside is everywhere!', 'NotGiven','2004-12-01 02:30:20'),
	('Obiwan','Kenobi','503-451-7729','Coruscant','248', 'Trust in the Force!', 'Given','2001-09-20 00:00:00'),
	('Mace','Windu','503-630-5841','Genosis','000', 'This party is over!', 'NotGiven','2008-08-13 01:01:03'),
	('Yoda','...','503-342-6874','Jedi Temple','999', 'Long night, this, will be!', 'Given','1999-12-22 01:20:13')
	
GO

--SELECT * FROM dbo.Users