CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT           NOT NULL,
    [BrandName] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_BrandId] PRIMARY KEY CLUSTERED ([BrandId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [BrandId]
    ON [dbo].[Brands]([BrandId] ASC);

