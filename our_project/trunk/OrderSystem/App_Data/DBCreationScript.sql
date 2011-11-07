/****** DataBase OrderSystem ******/
/****** Create folder C:\DATABASE and then execute Script *****/

CREATE DATABASE [OrderSystem] ON PRIMARY
( NAME = N'OrderSystem_mdf', FILENAME = N'C:\DATABASE\OrderSystem.MDF' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OrderSystem_log', FILENAME = N'C:\DATABASE\OrderSystem.LDF' , SIZE = 512KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [OrderSystem]
GO

/****** Object:  ForeignKey [FK_ItemsOrder_Items]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemsOrder_Items]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemsOrder]'))
ALTER TABLE [dbo].[ItemsOrder] DROP CONSTRAINT [FK_ItemsOrder_Items]
GO
/****** Object:  ForeignKey [FK_ItemsOrder_Orders]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemsOrder_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemsOrder]'))
ALTER TABLE [dbo].[ItemsOrder] DROP CONSTRAINT [FK_ItemsOrder_Orders]
GO
/****** Object:  ForeignKey [FK_Orders_Card]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Card]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Card]
GO
/****** Object:  ForeignKey [FK_Orders_Users]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Users]
GO
/****** Object:  ForeignKey [FK_Users_Rank]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Rank]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Rank]
GO
/****** Object:  Table [dbo].[ItemsOrder]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemsOrder]') AND type in (N'U'))
DROP TABLE [dbo].[ItemsOrder]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
DROP TABLE [dbo].[Orders]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rank]') AND type in (N'U'))
DROP TABLE [dbo].[Rank]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Card]') AND type in (N'U'))
DROP TABLE [dbo].[Card]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 11/07/2011 23:08:55 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Items]') AND type in (N'U'))
DROP TABLE [dbo].[Items]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 11/07/2011 23:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Items]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[ItemDiscription] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Card]    Script Date: 11/07/2011 23:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Card]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Card](
	[CardID] [int] NOT NULL,
	[CardNumber] [char](16) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[CardType] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[CVV2Code] [char](3) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[MakeDate] [date] NULL,
	[ExpiredDate] [date] NOT NULL,
	[IssueNumber] [int] NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 11/07/2011 23:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rank]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rank](
	[RankTreshold] [numeric](18, 0) NOT NULL,
	[RankName] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[IconName] [varchar](60) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Percents] [float] NOT NULL,
 CONSTRAINT [PK_Rank] PRIMARY KEY CLUSTERED 
(
	[RankTreshold] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/07/2011 23:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Password] [varchar](32) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[UserFName] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[UserLName] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Mail] [varchar](30) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Region] [varchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Role] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[Rank] [numeric](18, 0) NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/07/2011 23:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CardID] [int] NOT NULL,
	[OrderingDate] [date] NOT NULL,
	[DeliveryDate] [date] NOT NULL,
	[PreferableDeliveryDate] [date] NOT NULL,
	[Assignee] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[TotalPrice] [float] NOT NULL,
	[Discount] [float] NOT NULL,
	[IsGift] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[ItemsOrder]    Script Date: 11/07/2011 23:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemsOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ItemsOrder](
	[ItemID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Dimension] [varchar](15) COLLATE Cyrillic_General_CI_AS NOT NULL,
 CONSTRAINT [PK_ItemsOrder_1] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  ForeignKey [FK_ItemsOrder_Items]    Script Date: 11/07/2011 23:08:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemsOrder_Items]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemsOrder]'))
ALTER TABLE [dbo].[ItemsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrder_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([ItemID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemsOrder_Items]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemsOrder]'))
ALTER TABLE [dbo].[ItemsOrder] CHECK CONSTRAINT [FK_ItemsOrder_Items]
GO
/****** Object:  ForeignKey [FK_ItemsOrder_Orders]    Script Date: 11/07/2011 23:08:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemsOrder_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemsOrder]'))
ALTER TABLE [dbo].[ItemsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrder_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ItemsOrder_Orders]') AND parent_object_id = OBJECT_ID(N'[dbo].[ItemsOrder]'))
ALTER TABLE [dbo].[ItemsOrder] CHECK CONSTRAINT [FK_ItemsOrder_Orders]
GO
/****** Object:  ForeignKey [FK_Orders_Card]    Script Date: 11/07/2011 23:08:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Card]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Card] FOREIGN KEY([CardID])
REFERENCES [dbo].[Card] ([CardID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Card]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Card]
GO
/****** Object:  ForeignKey [FK_Orders_Users]    Script Date: 11/07/2011 23:08:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Orders_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Orders]'))
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
/****** Object:  ForeignKey [FK_Users_Rank]    Script Date: 11/07/2011 23:08:55 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Rank]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Rank] FOREIGN KEY([Rank])
REFERENCES [dbo].[Rank] ([RankTreshold])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Rank]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Rank]
GO
