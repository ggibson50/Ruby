CREATE TABLE [dbo].[Friends]
(
	[SentFromId] NVARCHAR (128) NOT NULL, 
    [SentToId] NVARCHAR (128) NOT NULL, 
    [IsAccepted] BIT NOT NULL

	PRIMARY KEY ([SentFromId], [SentToId]),
	FOREIGN KEY ([SentFromId]) REFERENCES [dbo].[Users] ([UserId]),
	FOREIGN KEY ([SentToId]) REFERENCES [dbo].[Users] ([UserId])
)
