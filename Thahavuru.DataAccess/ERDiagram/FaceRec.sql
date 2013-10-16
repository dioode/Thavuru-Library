USE [FaceRec]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 10/14/2013 11:58:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [int] IDENTITY(1,1) NOT NULL,
	[Class_Attrubute_Id] [int] NOT NULL,
	[ClassNumber] [int] NULL,
	[ValueRangeUpperBound] [float] NULL,
	[ValueRangeLowerBound] [float] NULL,
	[Name] [nchar](10) NULL,
	[HasClassElements] [bit] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Class_Attrubute]    Script Date: 10/14/2013 11:58:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Attrubute](
	[CAttributeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[NumberOfClasses] [int] NULL,
 CONSTRAINT [PK_Class_Attrubute] PRIMARY KEY CLUSTERED 
(
	[CAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClassElementImages]    Script Date: 10/14/2013 11:58:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassElementImages](
	[ClassElementId] [int] IDENTITY(1,1) NOT NULL,
	[Class_ClassId] [int] NOT NULL,
	[Feature_img_uri] [nchar](100) NOT NULL,
 CONSTRAINT [PK_ClassElementImages] PRIMARY KEY CLUSTERED 
(
	[ClassElementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 10/14/2013 11:58:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Image_Id] [int] IDENTITY(1,1) NOT NULL,
	[Person_Id] [int] NULL,
	[Image_uri] [nvarchar](50) NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Image_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 10/14/2013 11:58:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UserID] [nvarchar](20) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Attribute_Id] FOREIGN KEY([Class_Attrubute_Id])
REFERENCES [dbo].[Class_Attrubute] ([CAttributeId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Attribute_Id]
GO
ALTER TABLE [dbo].[ClassElementImages]  WITH CHECK ADD  CONSTRAINT [FK_Class_Id] FOREIGN KEY([Class_ClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[ClassElementImages] CHECK CONSTRAINT [FK_Class_Id]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Person_Id] FOREIGN KEY([Person_Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Person_Id]
GO
