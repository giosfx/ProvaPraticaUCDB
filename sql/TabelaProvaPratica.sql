IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Pedidos] (
    [Id] uniqueidentifier NOT NULL,
    [NomeProduto] varchar(200) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [DataVencimento] datetime2 NOT NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210626144511_TabelaIncial', N'5.0.7');
GO

COMMIT;
GO

