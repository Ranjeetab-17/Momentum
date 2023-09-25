USE [master]
GO
/****** Object:  Table [dbo].[LengthConversion]    Script Date: 9/25/2023 8:04:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LengthConversion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](10) NULL,
	[Target] [varchar](10) NULL,
	[ImperialUnit] [decimal](18, 4) NULL,
	[Description] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LengthConversion] ON 
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (1, N'in', N'mm', CAST(25.4000 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (2, N'm', N'mm', CAST(1000.0000 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (3, N'm', N'cm', CAST(100.0000 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (4, N'm', N'ft', CAST(3.2810 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (5, N'm', N'y', CAST(1.0940 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (6, N'm', N'in', CAST(39.3700 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (7, N'mm', N'cm', CAST(10.0000 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (8, N'km', N'm', CAST(1000.0000 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (9, N'km', N'cm', CAST(100000.0000 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (10, N'km', N'mm', CAST(100000.0000 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (11, N'km', N'mi', CAST(1.2427 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (12, N'in', N'cm', CAST(2.5400 AS Decimal(18, 4)), N'')
GO
INSERT [dbo].[LengthConversion] ([Id], [Source], [Target], [ImperialUnit], [Description]) VALUES (13, N'ft', N'in', CAST(12.0000 AS Decimal(18, 4)), N'')
GO
SET IDENTITY_INSERT [dbo].[LengthConversion] OFF
GO
