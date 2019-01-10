CREATE TABLE [dbo].[Users]
(
	[UserId] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(25) NOT NULL, 
    [LastName] NVARCHAR(20) NOT NULL, 
    [UserName] NVARCHAR(256) NOT NULL, 
    [Email] NVARCHAR(256) NULL, 
    [ProfilePicture] VARCHAR(150) NULL
)
