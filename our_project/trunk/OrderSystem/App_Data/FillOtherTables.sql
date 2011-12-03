DELETE FROM [OrderSystem].[dbo].[ItemsOrder]
GO
DBCC CHECKIDENT (ItemsOrder, RESEED, 0)

DELETE FROM [OrderSystem].[dbo].[Orders]
GO
DBCC CHECKIDENT (Orders, RESEED, 0)

DELETE FROM [OrderSystem].[dbo].[Card]
GO
DBCC CHECKIDENT (Card, RESEED, 0)

DELETE FROM [OrderSystem].[dbo].[Items]
GO
DBCC CHECKIDENT (Items, RESEED, 0)

--- Fill 'Card' table --- 

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('4010123781779112'
           ,'Visa'
           ,'123'
           ,NULL
           ,CONVERT(DATE, '01.09.2012')
           ,NULL)
GO
INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('4781222341827226'
           ,'Visa'
           ,'391'
           ,NULL
           ,CONVERT(DATE, '01.06.2013')
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('3427480572563003'
           ,'American Express'
           ,'421'
           ,NULL
           ,CONVERT(DATE, '01.05.2012')
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('5791348123907133'
           ,'MasterCard'
           ,'525'
           ,NULL
           ,CONVERT(DATE, '01.02.2012')
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('3411286937834142'
           ,'American Express'
           ,'666'
           ,NULL
           ,CONVERT(DATE, '01.04.2013')
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('4531417212344529'
           ,'Visa'
           ,'782'
           ,NULL
           ,CONVERT(DATE, '01.08.2012')
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('5069242748006848'
           ,'MasterCard'
           ,'715'
           ,NULL
           ,CONVERT(DATE, '01.01.2012')
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('4760634399302781'
           ,'Visa'
           ,'888'
           ,NULL
           ,CONVERT(DATE, '01.05.2013')
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('3334790132751332'
           ,'American Express'
           ,'544'
           ,NULL
           ,CONVERT(DATE, '01.08.2012')
           ,NULL)
GO


INSERT INTO [OrderSystem].[dbo].[Card]
           ([CardNumber]
           ,[CardType]
           ,[CVV2Code]
           ,[MakeDate]
           ,[ExpiredDate]
           ,[IssueNumber])
     VALUES
           ('5158730684815789'
           ,'MasterCard'
           ,'222'
           ,NULL
           ,CONVERT(DATE, '01.02.2013')
           ,NULL)
GO

--- Fill 'Items' table --- 

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('19" TFT Samsung E1920NR'
           ,'/5ìñ/50000:1/4:3/170°/160°/black/D-Sub'
           ,200
           ,10
           ,'../../Content/Images/Items/SamsungE1920NR.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('19" TFT Asus VH197DR'
           ,'/5ìñ/10000000:1/170°/160°/wide/black/D-Sub'
           ,180
           ,7
           ,'../../Content/Images/Items/AsusVH197DR.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('22" TFT LG E2241S'
           ,'/5ìñ/5000000 :1/176°/170°/wide/glossy black/D-Sub/LED'
           ,240
           ,6
           ,'../../Content/Images/Items/LGE2241S.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('23" TFT LG M237WDP'
           ,'/5ìñ/20000:1/170°/160°/TV-tuner/D-Sub/DVI/HDMIx2'
           ,280
           ,3
           ,'../../Content/Images/Items/LGM237WDP.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Intel Pentium G6950'
           ,'/2.8G/3Mb/Tray LGA1156 Clarkdale'
           ,80
           ,15
           ,'../../Content/Images/Items/PentiumG6950.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Intel Core i5-2400'
           ,'/3.1G/DMI/6Mb/Box Sandy Bridge LGA1155'
           ,180
           ,10
           ,'../../Content/Images/Items/IntelCorei5.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Intel Celeron G530'
           ,'/2.4G/1024kb/DMI/Box Sandy Bridge LGA 1155, TDP 35 Watt'
           ,180
           ,10
           ,'../../Content/Images/Items/IntelCeleron.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Western Digital 500 Gb'
           ,'7200 Serial ATA II 16Mb WD5000AAKS'
           ,95
           ,20
           ,'../../Content/Images/Items/WesternDigital500Gb.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Western Digital 1000 Gb'
           ,'5400 Serial ATA III 32Mb WD10EADX'
           ,110
           ,15
           ,'../../Content/Images/Items/WesternDigital1000Gb.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Samsung 2000 Gb'
           ,'7200 Serial ATA II 32Mb  HD204U'
           ,140
           ,8
           ,'../../Content/Images/Items/Samsung2000Gb.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('ATI Radeon HD 5450'
           ,'1024Mb DDR2/64-bit/DVI/VGA/HDMI/Sapphire'
           ,60
           ,11
           ,'../../Content/Images/ATIRadeonHD5450.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('ATI Radeon HD 6770'
           ,'1024Mb DDR5/128-bit/HDMI/DVI/D-Sub/Asus'
           ,160
           ,11
           ,'../../Content/Images/ATIRadeonHD6770.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('ATI Radeon HD 6870'
           ,'1024Mb DDR5//256-bit(920/4480Mhz)/2xDVI/HDMI/2xMiniDP/HiS'
           ,200
           ,8
           ,'../../Content/Images/ATIRadeonHD6870.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('GeForce GTX560'
           ,'1024Mb/256bit(900/4212Mhz)/DDR5/2xDVI/miniHDMI/EVGA'
           ,180
           ,6
           ,'../../Content/Images/Items/GeForceGTX560.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('CANON LBP-6300DN'
           ,'A4/30ppm/600dpi/USB2.0/10BASE-T/100BASE-TX'
           ,200
           ,8
           ,'../../Content/Images/Items/CANONLBP-6300DN.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Xerox Phaser 3140'
           ,'A4/1200x1200dpi/18ppm/8Mb/USB'
           ,85
           ,8
           ,'../../Content/Images/Items/XeroxPhaser3140.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Samsung ML-1661'
           ,'A4/1200x600dpi/16ppm/8Mb/USB2.0'
           ,80
           ,8
           ,'../../Content/Images/SamsungML1661.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('HP DeskJet 2000'
           ,'À4/1200dpi/20ppm/USB2.0'
           ,60
           ,8
           ,'../../Content/Images/HPDeskJet2000.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Viewcon USB 2.0 HUB'
           ,'VE410/4 Ports/active/silver'
           ,30
           ,10
           ,'../../Content/Images/Items/ViewconUSB2.0HUB.jpg')
GO

INSERT INTO [OrderSystem].[dbo].[Items]
           ([ItemName]
           ,[ItemDescriprion]
           ,[Price]
           ,[Quantity]
           ,[Image])
     VALUES
           ('Genius NetScroll 110'
           ,'/black/optical/800dpi/3 but/ps/2'
           ,35
           ,15
           ,'../../Content/Images/Items/GeniusNetScroll110Black.jpg')
GO

--- Fill 'Orders' table --- 

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (7
           ,1
           ,'000001'
           ,'Delivered'
           ,CONVERT(DATE, '20111222')
           ,CONVERT(DATE, '20111229')
           ,CONVERT(DATE, '20111230')
           ,'Merch2'
           ,1570.0000
           ,0
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (7
           ,1
           ,'000002'
           ,'Ordered'
           ,CONVERT(DATE, '20111226')
           ,CONVERT(DATE, '20120106')
           ,CONVERT(DATE, '20120103')
           ,'Merch1'
           ,975.0000
           ,0
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (7
           ,1
           ,'000003'
           ,'Pending'
           ,CONVERT(DATE, '20120104')
           ,NULL
           ,CONVERT(DATE, '20120110')
           ,'Merch2'
           ,720.0000
           ,0
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (7
           ,NULL
           ,'000004'
           ,'Created'
           ,CONVERT(DATE, '20110105')
           ,NULL
           ,NULL
           ,'Merch1'
           ,1640.0000
           ,0
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (8
           ,4
           ,'000005'
           ,'Pending'
           ,CONVERT(DATE, '20111223')
           ,NULL
           ,NULL
           ,'Merch3'
           ,870.0000
           ,0
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (9
           ,6
           ,'000006'
           ,'Delivered'
           ,CONVERT(DATE, '20111218')
           ,CONVERT(DATE, '20111227')
           ,CONVERT(DATE, '20111227')
           ,'Merch2'
           ,400.0000
           ,0
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (10
           ,3
           ,'000007'
           ,'Ordered'
           ,CONVERT(DATE, '20111228')
           ,CONVERT(DATE, '20120108')
           ,CONVERT(DATE, '20120106')
           ,'Merch3'
           ,360.0000
           ,0
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Orders]
           ([UserID]
           ,[CardID]
           ,[OrderNumber]
           ,[Status]
           ,[OrderingDate]
           ,[DeliveryDate]
           ,[PreferableDeliveryDate]
           ,[Assignee]
           ,[TotalPrice]
           ,[Discount]
           ,[IsGift])
     VALUES
           (10
           ,NULL
           ,'000008'
           ,'Created'
           ,CONVERT(DATE, '20111229')
           ,NULL
           ,NULL
           ,'Merch1'
           ,630.0000
           ,0
           ,0)
GO

--- Fill 'ItemsOrder' table --- 

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (1
           ,1
           ,1
           ,'Item')
GO


INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (5
           ,1
           ,1
           ,'Box')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (18
           ,1
           ,1
           ,'Package')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (7
           ,1
           ,2
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (12
           ,2
           ,4
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (19
           ,2
           ,1
           ,'Box')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (14
           ,3
           ,1
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (18
           ,3
           ,1
           ,'Package')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (8
           ,3
           ,2
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (2
           ,4
           ,1
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (9
           ,4
           ,2
           ,'Box')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (16
           ,5
           ,1
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (18
           ,5
           ,2
           ,'Package')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (7
           ,5
           ,2
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (4
           ,6
           ,1
           ,'Box')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (10
           ,7
           ,1
           ,'Item')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (18
           ,7
           ,1
           ,'Package')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (19
           ,8
           ,2
           ,'Box')
GO

INSERT INTO [OrderSystem].[dbo].[ItemsOrder]
           ([ItemInfoID]
           ,[OrderID]
           ,[Quantity]
           ,[Dimension])
     VALUES
           (3
           ,8
           ,1
           ,'Item')
GO