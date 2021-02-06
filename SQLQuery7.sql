CREATE TABLE [dbo].[Cars] (
    [CarId]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NOT NULL,
    [ColorId]      INT           NOT NULL,
    [ModelYear]    SMALLINT      NOT NULL,
    [DailyPrice]   DECIMAL (18)  NOT NULL,
    [Descriptions] NVARCHAR (40) NULL,
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId])
);