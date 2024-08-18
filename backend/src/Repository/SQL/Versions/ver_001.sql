IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'AutoServiceTrackingDb')
BEGIN
    CREATE DATABASE [AutoServiceTrackingDb];
END;
GO

USE [AutoServiceTrackingDb];
GO

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

CREATE TABLE [ServiceEntries] (
    [Id] int NOT NULL IDENTITY,
    [LicensePlate] nvarchar(8) NOT NULL,
    [BrandName] nvarchar(100) NOT NULL,
    [ModelName] nvarchar(100) NOT NULL,
    [Kilometers] int NOT NULL,
    [ModelYear] int NULL,
    [ServiceDate] datetime2 NOT NULL,
    [HasWarranty] bit NULL,
    [ServiceCity] nvarchar(max) NULL,
    [ServiceNotes] nvarchar(max) NULL,
    [CreatedBy] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedBy] int NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_ServiceEntries] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(450) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Status] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CreatedBy] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedBy] int NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [RefreshToken] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Code] nvarchar(200) NOT NULL,
    [Expiration] datetime2 NOT NULL,
    CONSTRAINT [PK_RefreshToken] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RefreshToken_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'Password', N'Status', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [CreatedBy], [CreatedDate], [Email], [FirstName], [LastName], [Password], [Status], [UpdatedBy], [UpdatedDate])
VALUES (1, NULL, '2024-08-18T23:40:51.3447332+03:00', N'admin@admin.com', N'Admin', N'Admin Kaçmaz', N'7110eda4d09e062aa5e4a390b0a572ac0d2c0220', CAST(1 AS bit), NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'Password', N'Status', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_RefreshToken_UserId] ON [RefreshToken] ([UserId]);
GO

CREATE INDEX [IX_ServiceEntry_LicensePlate] ON [ServiceEntries] ([LicensePlate]);
GO

CREATE UNIQUE INDEX [IX_Users_Email] ON [Users] ([Email]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240818204051_ver_001', N'7.0.5');
GO

COMMIT;
GO
