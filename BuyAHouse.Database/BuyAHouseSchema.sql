USE [BuyAHouse]
GO
/****** Object:  Table [dbo].[Properties]    Script Date: 01/05/2011 14:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Properties](
	[PropertyId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Properties] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offers]    Script Date: 01/05/2011 14:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offers](
	[OfferId] [int] IDENTITY(1,1) NOT NULL,
	[BuyerName] [nvarchar](100) NOT NULL,
	[RequestId] [uniqueidentifier] NOT NULL,
	[EmailAddress] [nvarchar](255) NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[Accepted] [bit] NOT NULL,
	[PropertyId] [int] NOT NULL,
 CONSTRAINT [PK_Offers] PRIMARY KEY CLUSTERED 
(
	[OfferId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_PropertyOffer]    Script Date: 01/05/2011 14:58:08 ******/
ALTER TABLE [dbo].[Offers]  WITH CHECK ADD  CONSTRAINT [FK_PropertyOffer] FOREIGN KEY([PropertyId])
REFERENCES [dbo].[Properties] ([PropertyId])
GO
ALTER TABLE [dbo].[Offers] CHECK CONSTRAINT [FK_PropertyOffer]
GO
