
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2017 11:18:01
-- Generated from EDMX file: E:\经典算法自己总结学习\ModelFirst\ModelFirst\ModelFirst\ModelFirstModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFModelFirst1];
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

-- Creating table 'userSet'
CREATE TABLE [dbo].[userSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreateDate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'cardSet'
CREATE TABLE [dbo].[cardSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cash] nvarchar(max)  NOT NULL,
    [CreateUserId] nvarchar(max)  NOT NULL,
    [userId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'userSet'
ALTER TABLE [dbo].[userSet]
ADD CONSTRAINT [PK_userSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'cardSet'
ALTER TABLE [dbo].[cardSet]
ADD CONSTRAINT [PK_cardSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [userId] in table 'cardSet'
ALTER TABLE [dbo].[cardSet]
ADD CONSTRAINT [FK_usercard]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[userSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_usercard'
CREATE INDEX [IX_FK_usercard]
ON [dbo].[cardSet]
    ([userId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------