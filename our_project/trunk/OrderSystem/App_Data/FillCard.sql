DELETE FROM [OrderSystem].[dbo].[Card]
GO

DBCC CHECKIDENT (Card, RESEED, 0)

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