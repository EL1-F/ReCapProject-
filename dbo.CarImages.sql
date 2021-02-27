CREATE TABLE [dbo].[CarImages] (
    [ImageId]   INT            IDENTITY (1, 1) NOT NULL,
    [CarId]     INT            NOT NULL,
    [ImagePath] NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NULL, 
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId]),
    CONSTRAINT [PK_CarImages] PRIMARY KEY CLUSTERED ([ImageId] ASC)
);

