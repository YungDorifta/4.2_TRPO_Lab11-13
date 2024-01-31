CREATE PROCEDURE [dbo].[Insert_User]
        @email NVARCHAR(100),
		@phone int,
		@password NVARCHAR(20),
		@FIO NVARCHAR(100)

AS
BEGIN
       SET NOCOUNT ON;
       IF EXISTS(SELECT email FROM Users WHERE email = @email)
       BEGIN
              SELECT -1 AS UserId -- Username exists.
       END
      
       ELSE
       BEGIN
              INSERT INTO [Users]
                        ([FIO],
						 [email],
                         [phone],
                         [password],
						 [role])
              VALUES
                        (@FIO,
						 @email,
						 @phone,
						 @password,
						 'Клиент')
             select 1
              --SELECT SCOPE_IDENTITY() AS UserId -- UserId                     
     END
END
