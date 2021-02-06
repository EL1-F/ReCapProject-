CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT           NOT NULL,
    [ColorName] NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_ColorId] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [ColorId]
    ON [dbo].[Colors]([ColorId] ASC);

