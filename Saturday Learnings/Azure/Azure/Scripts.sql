CREATE DATABASE AZURE

USE AZURE 

CREATE TABLE [dbo].[Todoes](
	[ID] [int] IDENTITY(1,1) NOT NULL  PRIMARY KEY ,
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
 )

SET IDENTITY_INSERT [dbo].[Todoes] ON 
 
