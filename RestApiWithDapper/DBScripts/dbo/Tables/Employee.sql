CREATE TABLE [dbo].[Employee] (
    [EmployeeId]     INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]      NVARCHAR (255) NOT NULL,
    [LastName]       NVARCHAR (255) NULL,
    [Department]     NVARCHAR (255) NULL,
    [JobTitle]       NVARCHAR (150) NOT NULL,
    [PhoneExtension] NVARCHAR (4)   NOT NULL,
    [Salary]         NVARCHAR (20)  NOT NULL,
    [Bonus]          NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);

