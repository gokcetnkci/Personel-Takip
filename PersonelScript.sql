USE [PersonelDb]
GO
/****** Object:  Table [dbo].[Departman]    Script Date: 10/20/2019 11:36:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departman](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departman] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 10/20/2019 11:36:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmanId] [int] NULL,
	[Ad] [nvarchar](50) NULL,
	[Soyad] [nvarchar](50) NULL,
	[Maas] [nvarchar](50) NULL,
	[DogumTarih] [datetime] NULL,
	[Cinsiyet] [bit] NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departman] ON 

INSERT [dbo].[Departman] ([Id], [Ad]) VALUES (1, N'Bilgi İşlem')
INSERT [dbo].[Departman] ([Id], [Ad]) VALUES (2, N'Pazarlama')
INSERT [dbo].[Departman] ([Id], [Ad]) VALUES (3, N'AR-GE')
SET IDENTITY_INSERT [dbo].[Departman] OFF
SET IDENTITY_INSERT [dbo].[Personel] ON 

INSERT [dbo].[Personel] ([Id], [DepartmanId], [Ad], [Soyad], [Maas], [DogumTarih], [Cinsiyet]) VALUES (1, 1, N'Ece', N'Yıldırım', N'3000', CAST(N'1993-06-15T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Personel] ([Id], [DepartmanId], [Ad], [Soyad], [Maas], [DogumTarih], [Cinsiyet]) VALUES (2, 3, N'Ali', N'Acar', N'4500', CAST(N'1988-03-09T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Personel] OFF
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Personel_Departman] FOREIGN KEY([DepartmanId])
REFERENCES [dbo].[Departman] ([Id])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Personel_Departman]
GO
