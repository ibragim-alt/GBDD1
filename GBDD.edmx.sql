
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/08/2021 10:14:25
-- Generated from EDMX file: C:\Users\3 Курс\Desktop\0101 0102\WpfApp2\GBDD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GBDD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SubjectsSetSet'
CREATE TABLE [dbo].[SubjectsSetSet] (
    [IdSubject] int IDENTITY(1,1) NOT NULL,
    [RegionNameRU] nvarchar(max)  NOT NULL,
    [RegionNameEN] nvarchar(max)  NOT NULL,
    [ISO] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CodeSetSet'
CREATE TABLE [dbo].[CodeSetSet] (
    [IdCode] int IDENTITY(1,1) NOT NULL,
    [IdSubject] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdSubject] in table 'SubjectsSetSet'
ALTER TABLE [dbo].[SubjectsSetSet]
ADD CONSTRAINT [PK_SubjectsSetSet]
    PRIMARY KEY CLUSTERED ([IdSubject] ASC);
GO

-- Creating primary key on [IdCode] in table 'CodeSetSet'
ALTER TABLE [dbo].[CodeSetSet]
ADD CONSTRAINT [PK_CodeSetSet]
    PRIMARY KEY CLUSTERED ([IdCode] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------