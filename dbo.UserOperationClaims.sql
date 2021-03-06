CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NULL, 
    [OperationClaimId] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

