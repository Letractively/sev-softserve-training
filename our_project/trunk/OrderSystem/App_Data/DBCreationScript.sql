/****** DataBase OrderSystem ******/
/****** Create folder C:\DATABASE and then execute Script *****/

CREATE DATABASE [OrderSystem] ON PRIMARY
( NAME = N'OrderSystem_mdf', FILENAME = N'C:\DATABASE\OrderSystem.MDF' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OrderSystem_log', FILENAME = N'C:\DATABASE\OrderSystem.LDF' , SIZE = 512KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE [OrderSystem]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 11/16/2011 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ban](
	[ip] [varchar](16) COLLATE Cyrillic_General_CI_AS NOT NULL,
	[attempt] [int] NOT NULL,
	[bantime] [datetime] NULL,
 CONSTRAINT [PK_Ban] PRIMARY KEY CLUSTERED 
(
	[ip] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 11/16/2011 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](30) NOT NULL,
	[ItemDescriprion] [varchar](100) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Image] [varchar] (100) NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Card]    Script Date: 11/16/2011 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Card](
	[CardID] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [char](16) NOT NULL,
	[CardType] [varchar](30) NOT NULL,
	[CVV2Code] [char](3) NOT NULL,
	[MakeDate] [date] NULL,
	[ExpiredDate] [date] NOT NULL,
	[IssueNumber] [char](1) NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[CardID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rank]    Script Date: 11/16/2011 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rank](
	[RankID] [int] IDENTITY(1,1) NOT NULL,
	[RankTreshold] [smallmoney] NOT NULL,
	[RankName] [varchar](50) NOT NULL,
	[IconName] [varchar](50) NOT NULL,
	[Percents] [float] NOT NULL,
 CONSTRAINT [PK_Rank] PRIMARY KEY CLUSTERED 
(
	[RankID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/16/2011 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](20) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[UserFName] [varchar](50) NOT NULL,
	[UserLName] [varchar](50) NOT NULL,
	[Mail] [varchar](50) NOT NULL,
	[Region] [varchar](10) NOT NULL,
	[Role] [varchar](20) NOT NULL,
	[Rank] [numeric] NULL,
	[RankType] [int] NULL,
	[Balance] [smallmoney] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/16/2011 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CardID] [int] NULL,
	[OrderNumber] [varchar](50) NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[OrderingDate] [date] NOT NULL,
	[DeliveryDate] [date] NULL,
	[PreferableDeliveryDate] [date] NULL,
	[Assignee] [varchar](20) NOT NULL,
	[TotalPrice] [smallmoney] NOT NULL,
	[Discount] [float] NOT NULL,
	[IsGift] [bit] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemsOrder]    Script Date: 11/16/2011 22:17:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemsOrder](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[ItemInfoID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Dimension] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ItemsOrder] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_ItemsOrder_Items]    Script Date: 11/16/2011 22:17:09 ******/
ALTER TABLE [dbo].[ItemsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrder_Items] FOREIGN KEY([ItemInfoID])
REFERENCES [dbo].[Items] ([ItemID])
GO
ALTER TABLE [dbo].[ItemsOrder] CHECK CONSTRAINT [FK_ItemsOrder_Items]
GO
/****** Object:  ForeignKey [FK_ItemsOrder_Order]    Script Date: 11/16/2011 22:17:09 ******/
ALTER TABLE [dbo].[ItemsOrder]  WITH CHECK ADD  CONSTRAINT [FK_ItemsOrder_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[ItemsOrder] CHECK CONSTRAINT [FK_ItemsOrder_Order]
GO
/****** Object:  ForeignKey [FK_Orders_Card]    Script Date: 11/16/2011 22:17:09 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Card] FOREIGN KEY([CardID])
REFERENCES [dbo].[Card] ([CardID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Card]
GO
/****** Object:  ForeignKey [FK_Orders_Users]    Script Date: 11/16/2011 22:17:09 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
/****** Object:  ForeignKey [FK_Users_Rank]    Script Date: 11/16/2011 22:17:09 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Rank] FOREIGN KEY([RankType])
REFERENCES [dbo].[Rank] ([RankID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Rank]
GO
