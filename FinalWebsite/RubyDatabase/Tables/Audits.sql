CREATE TABLE [dbo].[Audits]
(
	[AuditId] UNIQUEIDENTIFIER NOT NULL, 
    [Log] VARCHAR(250) NOT NULL, 
    [ServerId] UNIQUEIDENTIFIER NOT NULL

	PRIMARY KEY ([AuditId]),
	FOREIGN KEY ([ServerId]) REFERENCES [dbo].[Server] ([ServerId])
)
