IF OBJECT_ID('Users', 'U') IS NOT NULL
    DROP TABLE Users;

CREATE TABLE Users (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) 
        CONSTRAINT CK_Users_Username CHECK (LEN(Username) > 0) NOT NULL,
    [Password] NVARCHAR(255) 
        CONSTRAINT CK_Users_Password CHECK (LEN([Password]) > 0) NOT NULL,
    Email NVARCHAR(255) NOT NULL
        CONSTRAINT CK_Users_Email_Format CHECK (Email LIKE '%@%.%'),
    CONSTRAINT UQ_Users_Email UNIQUE (Email)
);