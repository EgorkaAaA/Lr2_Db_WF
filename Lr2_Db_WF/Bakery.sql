
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/02/2021 12:19:38
-- Generated from EDMX file: C:\Users\User\source\repos\Lr2_Db_WF\Lr2_Db_WF\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Bakery];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StaffShifts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShiftsSet] DROP CONSTRAINT [FK_StaffShifts];
GO
IF OBJECT_ID(N'[dbo].[FK_BackeryShifts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShiftsSet] DROP CONSTRAINT [FK_BackeryShifts];
GO
IF OBJECT_ID(N'[dbo].[FK_BackeryDeliveries]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DeliveriesSet] DROP CONSTRAINT [FK_BackeryDeliveries];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[StaffSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StaffSet];
GO
IF OBJECT_ID(N'[dbo].[BackerySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BackerySet];
GO
IF OBJECT_ID(N'[dbo].[DeliveriesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeliveriesSet];
GO
IF OBJECT_ID(N'[dbo].[ShiftsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShiftsSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'StaffSet'
CREATE TABLE [dbo].[StaffSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [patronymic] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BackerySet'
CREATE TABLE [dbo].[BackerySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [adres] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DeliveriesSet'
CREATE TABLE [dbo].[DeliveriesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [adres] nvarchar(max)  NOT NULL,
    [numberOfCakes] smallint  NOT NULL,
    [Backery_Id] int  NOT NULL
);
GO

-- Creating table 'ShiftsSet'
CREATE TABLE [dbo].[ShiftsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Plan] nvarchar(max)  NOT NULL,
    [Staff_Id] int  NOT NULL,
    [Backery_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'StaffSet'
ALTER TABLE [dbo].[StaffSet]
ADD CONSTRAINT [PK_StaffSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BackerySet'
ALTER TABLE [dbo].[BackerySet]
ADD CONSTRAINT [PK_BackerySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeliveriesSet'
ALTER TABLE [dbo].[DeliveriesSet]
ADD CONSTRAINT [PK_DeliveriesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShiftsSet'
ALTER TABLE [dbo].[ShiftsSet]
ADD CONSTRAINT [PK_ShiftsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Staff_Id] in table 'ShiftsSet'
ALTER TABLE [dbo].[ShiftsSet]
ADD CONSTRAINT [FK_StaffShifts]
    FOREIGN KEY ([Staff_Id])
    REFERENCES [dbo].[StaffSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StaffShifts'
CREATE INDEX [IX_FK_StaffShifts]
ON [dbo].[ShiftsSet]
    ([Staff_Id]);
GO

-- Creating foreign key on [Backery_Id] in table 'ShiftsSet'
ALTER TABLE [dbo].[ShiftsSet]
ADD CONSTRAINT [FK_BackeryShifts]
    FOREIGN KEY ([Backery_Id])
    REFERENCES [dbo].[BackerySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BackeryShifts'
CREATE INDEX [IX_FK_BackeryShifts]
ON [dbo].[ShiftsSet]
    ([Backery_Id]);
GO

-- Creating foreign key on [Backery_Id] in table 'DeliveriesSet'
ALTER TABLE [dbo].[DeliveriesSet]
ADD CONSTRAINT [FK_BackeryDeliveries]
    FOREIGN KEY ([Backery_Id])
    REFERENCES [dbo].[BackerySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BackeryDeliveries'
CREATE INDEX [IX_FK_BackeryDeliveries]
ON [dbo].[DeliveriesSet]
    ([Backery_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------