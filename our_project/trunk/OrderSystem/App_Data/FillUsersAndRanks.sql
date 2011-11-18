DELETE FROM [OrderSystem].[dbo].[Users]
GO

DELETE FROM [OrderSystem].[dbo].[Rank]
GO

INSERT INTO [OrderSystem].[dbo].[Rank]
           ([RankTreshold]
           ,[RankName]
           ,[IconName]
           ,[Percents])
     VALUES
           (0
           ,'Standart'
           ,'Icon'
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Rank]
           ([RankTreshold]
           ,[RankName]
           ,[IconName]
           ,[Percents])
     VALUES
           (1000
           ,'Silver'
           ,'Icon'
           ,0)
GO


INSERT INTO [OrderSystem].[dbo].[Rank]
           ([RankTreshold]
           ,[RankName]
           ,[IconName]
           ,[Percents])
     VALUES
           (3000
           ,'Gold'
           ,'Icon'
           ,0)
GO


INSERT INTO [OrderSystem].[dbo].[Rank]
           ([RankTreshold]
           ,[RankName]
           ,[IconName]
           ,[Percents])
     VALUES
           (10000
           ,'Platinum'
           ,'Icon'
           ,0)
GO




INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Merch1'
           ,'Merch1!'
           ,'MerchIFName'
           ,'MerchILName'
           ,'Merch1@mail.com'
           ,'North'
           ,'Merchandiser'
           ,NULL
           ,NULL
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Merch2'
           ,'Merch2!'
           ,'MerchIIFName'
           ,'MerchIILName'
           ,'Merch2@mail.com'
           ,'West'
           ,'Merchandiser'
           ,NULL
           ,NULL
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Merch3'
           ,'Merch3!'
           ,'MerchIIIFName'
           ,'MerchIIILName'
           ,'Merch3@mail.com'
           ,'South'
           ,'Merchandiser'
           ,NULL
           ,NULL
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Superv1'
           ,'Superv1!'
           ,'SupervIFName'
           ,'SupervILName'
           ,'Superv1@mail.com'
           ,'East'
           ,'Supervisor'
           ,NULL
           ,NULL
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Superv2'
           ,'Superv2!'
           ,'SupervIIFName'
           ,'SupervIILName'
           ,'Superv2@mail.com'
           ,'West'
           ,'Supervisor'
           ,NULL
           ,NULL
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Superv3'
           ,'Superv3!'
           ,'SupervIIIFName'
           ,'SupervIIILName'
           ,'Superv3@mail.com'
           ,'West'
           ,'Supervisor'
           ,NULL
           ,NULL
           ,NULL)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Custom1'
           ,'Custom1!'
           ,'CustomIFName'
           ,'CustomILName'
           ,'Custom1@mail.com'
           ,'West'
           ,'Customer'
           ,1
           ,1
           ,0)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Custom2'
           ,'Custom2!'
           ,'CustomIIFName'
           ,'CustomIILName'
           ,'Custom2@mail.com'
           ,'North'
           ,'Customer'
           ,2
           ,2
           ,1500)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Custom3'
           ,'Custom3!'
           ,'CustomIIIFName'
           ,'CustomIIILName'
           ,'Custom3@mail.com'
           ,'West'
           ,'Customer'
           ,3
           ,3
           ,5000)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Custom4'
           ,'Custom4!'
           ,'CustomIVFName'
           ,'CustomIVLName'
           ,'Custom4@mail.com'
           ,'North'
           ,'Customer'
           ,4
           ,4
           ,12000)
GO

INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Admin1'
           ,'Admin1!'
           ,'AdminIFName'
           ,'AdminILName'
           ,'Admin1@mail.com'
           ,'West'
           ,'Administrator'
           ,NULL
           ,NULL
           ,NULL)
GO
      
      
INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Admin2'
           ,'Admin2!'
           ,'AdminIIFName'
           ,'AdminIILName'
           ,'Admin2@mail.com'
           ,'North'
           ,'Administrator'
           ,NULL
           ,NULL
           ,NULL)
GO

     
INSERT INTO [OrderSystem].[dbo].[Users]
           ([Login]
           ,[Password]
           ,[UserFName]
           ,[UserLName]
           ,[Mail]
           ,[Region]
           ,[Role]
           ,[Rank]
           ,[RankType]
           ,[Balance])
     VALUES
           ('Admin3'
           ,'Admin3!'
           ,'AdminIIIFName'
           ,'AdminIIILName'
           ,'Admin3@mail.com'
           ,'North'
           ,'Administrator'
           ,NULL
           ,NULL
           ,NULL)
GO
