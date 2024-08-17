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
    [LicensePlate] nvarchar(10) NOT NULL,
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
    [Email] nvarchar(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    [PasswordHash] varbinary(max) NOT NULL,
    [Status] bit NOT NULL DEFAULT CAST(1 AS bit),
    [CreatedBy] int NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedBy] int NULL,
    [UpdatedDate] datetime2 NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'PasswordHash', N'PasswordSalt', N'Status', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] ON;
INSERT INTO [Users] ([Id], [CreatedBy], [CreatedDate], [Email], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [UpdatedBy], [UpdatedDate])
VALUES (1, NULL, '0001-01-01T00:00:00.0000000', N'admin@admin.com', N'Admin', N'Admin Kaçmaz', 0xB240956BD2D993CA30565394033811EC1E88C81D957F2374F41B152471BBE45BC9B8F255D0AF3324E3319E89AC4FD8D643980BB0A7FC98FA6FE284DF426A10D3, 0x0ECD43C22D5AEFC5C5146CDAEAA7AE677061B50494AF23479F4FB5CC0FE14926AF310DFE66B5B7C6A5A84433B2E667608C617160B0673CF8CB57EA6A79FF587631177B0F9BBFF049F7D271356D27E9ED8348BD7EFD267DCD9A48687FC2CE4F4FE27A6AF805A0F2DA36316D8088844481998FCA3D80CD1EDD2E30631C8068B6F9, CAST(1 AS bit), NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedBy', N'CreatedDate', N'Email', N'FirstName', N'LastName', N'PasswordHash', N'PasswordSalt', N'Status', N'UpdatedBy', N'UpdatedDate') AND [object_id] = OBJECT_ID(N'[Users]'))
    SET IDENTITY_INSERT [Users] OFF;
GO

CREATE INDEX [IX_ServiceEntry_LicensePlate] ON [ServiceEntries] ([LicensePlate]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240817134647_ver_001', N'8.0.8');
GO

COMMIT;
GO


