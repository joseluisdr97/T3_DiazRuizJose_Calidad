USE [SimuladorExamenUPN]
GO
/****** Object:  Table [dbo].[Alternativa]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alternativa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](2000) NOT NULL,
	[EsCorrecto] [bit] NOT NULL,
	[PreguntaId] [int] NOT NULL,
 CONSTRAINT [PK_Alternativa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Examen]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TemaId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[EstaActivo] [bit] NOT NULL CONSTRAINT [DF_Examen_EstaActivo]  DEFAULT ((1)),
 CONSTRAINT [PK_Examen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamenPregunta]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamenPregunta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamenId] [int] NOT NULL,
	[PreguntaId] [int] NOT NULL,
 CONSTRAINT [PK_ExamenPregunta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pregunta]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pregunta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [text] NULL,
	[TemaId] [int] NOT NULL,
 CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tema]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tema](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](500) NULL,
	[Descripcion] [text] NULL,
 CONSTRAINT [PK_Tema] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TemaCategoria]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemaCategoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaId] [int] NULL,
	[TemaId] [int] NULL,
 CONSTRAINT [PK_TemaCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioExamen]    Script Date: 3/12/2019 07:50:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioExamen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamenId] [int] NULL,
	[UsuarioId] [int] NULL,
	[Fecha] [date] NULL,
	[Puntaje] [float] NULL,
 CONSTRAINT [PK_UsuarioExamen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Alternativa] ON 

INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (1, N'Tras el ataque a Pearl Harbor', 0, 1)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (2, N'
Tras el asesinato del archiduque Francisco Fernando', 1, 1)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (4, N'Tras la invasión a Polonia', 0, 1)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (5, N'La batalla del Somme', 0, 5)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (6, N'La batalla de Gallipoli', 0, 5)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (7, N'La batalla de Marne', 1, 5)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (8, N'Alternativa 2', 0, 12)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (9, N'Alternatuva 1', 0, 12)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (10, N'Alt 6', 1, 12)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (11, N'Alt 8', 0, 12)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (12, N'fgdfg', 0, 13)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (13, N'rtertert', 1, 13)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (14, N'sdfsdf', 0, 14)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (15, N'cvvxcvxcv', 0, 14)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (16, N'sdfdfsfsdf', 0, 14)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (17, N'sdfxcvxcvxcv', 0, 15)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (18, N'sfsdfsdf', 0, 16)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (19, N'xcvxcvxcv', 0, 16)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (20, N'werwer', 0, 16)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (21, N'xvxcvxcv', 0, 16)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (22, N'abc', 0, 17)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (23, N'vxcvcxv', 0, 17)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (24, N'sdfsdfsdf', 1, 17)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (25, N'xcvxvxcv', 0, 17)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (26, N'asdasdasd', 1, 18)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (27, N'asdasdasda', 0, 18)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (28, N'vxcvxcxcvxcv', 0, 18)
INSERT [dbo].[Alternativa] ([Id], [Descripcion], [EsCorrecto], [PreguntaId]) VALUES (29, N'sdfsdfsdf', 0, 18)
SET IDENTITY_INSERT [dbo].[Alternativa] OFF
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (1, N'Historia')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'Cultura General')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (3, N'Historia Universal')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Examen] ON 

INSERT [dbo].[Examen] ([Id], [TemaId], [UsuarioId], [FechaCreacion], [EstaActivo]) VALUES (1, 1, 3, CAST(N'2019-11-19 22:03:38.497' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Examen] OFF
SET IDENTITY_INSERT [dbo].[ExamenPregunta] ON 

INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (1, 7, 13)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (2, 7, 18)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (3, 7, 9)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (4, 7, 12)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (5, 7, 15)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (6, 7, 17)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (7, 7, 1)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (8, 8, 3)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (9, 8, 10)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (10, 1, 7)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (11, 1, 14)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (12, 1, 13)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (13, 1, 15)
INSERT [dbo].[ExamenPregunta] ([Id], [ExamenId], [PreguntaId]) VALUES (14, 1, 12)
SET IDENTITY_INSERT [dbo].[ExamenPregunta] OFF
SET IDENTITY_INSERT [dbo].[Pregunta] ON 

INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (1, N'¿Cómo comenzó la I Guerra Mundial?', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (3, N'cccc', 2)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (4, N'eeee', 1002)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (5, N'¿Qué batalla provocó el mayor número de fallecimientos en ambos bandos del conflicto?', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (6, NULL, 5)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (7, N'El escritor español Miguel de Unamuno apoyó durante la contienda al bando alemán', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (8, N'asdasdasd', 1003)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (9, N'¿Qué países entraron en guerra con el bando de los aliados?', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (10, N'kasdkadasd', 2)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (11, N'asdasdasd', 1003)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (12, N'Pregunta 10', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (13, N'bvcbcvb', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (14, N'srwrwerwerwer', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (15, N'sdfsdf', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (16, N'dfsdfs', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (17, N'adsasdsad', 1)
INSERT [dbo].[Pregunta] ([Id], [Descripcion], [TemaId]) VALUES (18, N'sdasdasdasdasdasdasdasdasda', 1)
SET IDENTITY_INSERT [dbo].[Pregunta] OFF
SET IDENTITY_INSERT [dbo].[Tema] ON 

INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Primera Guerra Mundial 1', N'...')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Hola Mundo x2', N'...')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Java Avanzado', N'...')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1002, N'Programación Level 2', N'xD')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1003, N'JEJEJE', N'XD')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1004, N'Hola Mundo', N'...')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1015, N'Nuevo Tema', N'Lorem ipsum')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1016, N'Nombre1', N'aaaaaaaaaaa')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1017, N'Nombre1', N'aaaaaaaaaaa')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1018, N'Nombre1', N'aaaaaaaaaaa')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1019, N'Nombre1', N'aaaaaaaaaaa')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1020, N'Nombre1', N'aaaaaaaaaaa')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1021, N'Nombre1', N'aaaaaaaaaaa')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1022, N'Nombre1', N'aaaaaaaaaaa')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1023, N'Revolución Francesa', N'Esta ajja nlkaasjfs ')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1024, N'Tema Random', N'asdasd')
INSERT [dbo].[Tema] ([Id], [Nombre], [Descripcion]) VALUES (1025, N'Tema Random 2', N'asdasd')
SET IDENTITY_INSERT [dbo].[Tema] OFF
SET IDENTITY_INSERT [dbo].[TemaCategoria] ON 

INSERT [dbo].[TemaCategoria] ([Id], [CategoriaId], [TemaId]) VALUES (1, 1, 1023)
INSERT [dbo].[TemaCategoria] ([Id], [CategoriaId], [TemaId]) VALUES (2, 3, 1023)
INSERT [dbo].[TemaCategoria] ([Id], [CategoriaId], [TemaId]) VALUES (3, 2, 1024)
INSERT [dbo].[TemaCategoria] ([Id], [CategoriaId], [TemaId]) VALUES (4, 1, 1025)
INSERT [dbo].[TemaCategoria] ([Id], [CategoriaId], [TemaId]) VALUES (5, 2, 1025)
INSERT [dbo].[TemaCategoria] ([Id], [CategoriaId], [TemaId]) VALUES (6, 1, 1)
INSERT [dbo].[TemaCategoria] ([Id], [CategoriaId], [TemaId]) VALUES (7, 3, 1)
SET IDENTITY_INSERT [dbo].[TemaCategoria] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Username], [Password], [Nombres]) VALUES (3, N'Admin', N'Admin', N'Administrador')
INSERT [dbo].[Usuario] ([Id], [Username], [Password], [Nombres]) VALUES (4, N'Juan', N'Juan', N'Edison')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
