CREATE TABLE [dbo].[UserRoles]
(
	[RoleId] UNIQUEIDENTIFIER NOT NULL,
	[UserId] NVARCHAR (128) NOT NULL,
	[ServerId] UNIQUEIDENTIFIER NOT NULL,

	PRIMARY KEY ([RoleId], [UserId], [ServerId]),
	FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId]),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
	FOREIGN KEY ([ServerId]) REFERENCES [dbo].[Server] ([ServerId]) ON DELETE CASCADE
)
