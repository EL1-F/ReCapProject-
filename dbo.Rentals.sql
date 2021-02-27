CREATE TABLE [dbo].[Rentals] (
    [RentalId]   INT           IDENTITY (1, 1) NOT NULL,
    [CarId]      INT           NOT NULL,
    [CustomerId] INT           NOT NULL, 
    [RentDate]   DATETIME2 (7) NOT NULL,
    [ReturnDate] DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([RentalId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]),
    FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId])
);

