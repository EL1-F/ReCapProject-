CREATE TABLE [dbo].[Customers] (
    [CustomerId]  INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      INT            NOT NULL,
    [CompanyName] NVARCHAR (MAX) NOT NULL, 
    PRIMARY KEY CLUSTERED ([CustomerId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

