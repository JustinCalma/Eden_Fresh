﻿CREATE TABLE [dbo].[USERS]
(
	[UserId] INT NOT NULL PRIMARY KEY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[UserName] VARCHAR(50) NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Email] VARCHAR(50) NOT NULL
)