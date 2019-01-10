CREATE TABLE [dbo].[Chat]
(
	[ChatId] UNIQUEIDENTIFIER NOT NULL, 
    --[ChatName] VARCHAR(25) NOT NULL, 
    [Message] NVARCHAR(200) NULL, 
    [TimeSent] DATETIME NOT NULL, 
    [ServerId] UNIQUEIDENTIFIER NULL, 
    [UserId] NVARCHAR (128) NULL,

	PRIMARY KEY ([ChatId]),
	FOREIGN KEY([ServerId]) REFERENCES [dbo].[Server] ([ServerId]) ON DELETE CASCADE,
	FOREIGN KEY([UserId]) REFERENCES [dbo].[Users] ([UserId])
)
