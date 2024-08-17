IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'AutoServiceTrackingDb')
BEGIN
    CREATE DATABASE [AutoServiceTrackingDb];
END;
GO

USE [AutoServiceTrackingDb];
GO

