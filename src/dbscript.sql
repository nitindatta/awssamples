﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Transactions] (
    [TransactionId] int NOT NULL IDENTITY,
    [CreatedBy] nvarchar(max) NULL,
    [LastUpdatedBy] nvarchar(max) NULL,
    [CreatedDate] datetime2 NOT NULL,
    [LastUpdateDate] datetime2 NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([TransactionId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201002093730_InitialCreate', N'3.1.8');

GO

