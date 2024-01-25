CREATE TABLE [dbo].[Users]
(
	[UserID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FIO] NCHAR(100) NOT NULL, 
    [role] NCHAR(25) NOT NULL, 
    [email] NCHAR(100) NOT NULL, 
    [phone] INT NOT NULL, 
    [password] NCHAR(20) NOT NULL
)
