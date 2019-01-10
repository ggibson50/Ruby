CREATE TABLE [dbo].[Roles]
(
	[RoleId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [RoleName] VARCHAR(25) NOT NULL, 
	[ServerId] UNIQUEIDENTIFIER NOT NULL,
    [IsAdmin] BIT NOT NULL, 
    [IsMod] BIT NOT NULL, 
    [IsRegular] BIT NOT NULL,

	FOREIGN KEY ([ServerId]) REFERENCES [dbo].[Server] ([ServerId])
)
