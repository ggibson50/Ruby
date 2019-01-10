CREATE TABLE [dbo].[UserServers]
(
	[ServerId] UNIQUEIDENTIFIER NOT NULL,
	[UserId] NVARCHAR (128) NOT NULL,

	PRIMARY KEY ([ServerId], [UserId]),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
	FOREIGN KEY ([ServerId]) REFERENCES [dbo].[Server] ([ServerId]) ON DELETE CASCADE
)
