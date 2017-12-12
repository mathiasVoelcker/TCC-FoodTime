USE [FoodTime]
GO
/****** Object:  Schema [schema]    Script Date: 12/12/2017 13:57:53 ******/
CREATE SCHEMA [schema]
GO
/****** Object:  Schema [schemaFoodTime]    Script Date: 12/12/2017 13:57:53 ******/
CREATE SCHEMA [schemaFoodTime]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Avaliacao]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Avaliacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nota] [int] NOT NULL,
	[PrecoMedio] [decimal](7, 2) NOT NULL,
	[Comentario] [nvarchar](500) NOT NULL,
	[FotoAvaliacao] [nvarchar](500) NOT NULL,
	[Recomendado] [bit] NOT NULL,
	[DataAvaliacao] [datetime] NOT NULL,
	[Id_Estabelecimento] [int] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Avaliacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Categoria]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Endereco]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rua] [nvarchar](50) NOT NULL,
	[Numero] [nvarchar](20) NOT NULL,
	[Apto] [nvarchar](20) NULL,
	[Complemento] [nvarchar](50) NULL,
	[Bairro] [nvarchar](50) NOT NULL,
	[Cidade] [nvarchar](50) NOT NULL,
	[Estado] [nvarchar](50) NOT NULL,
	[CEP] [nvarchar](8) NOT NULL,
	[Latitude] [decimal](10, 7) NOT NULL,
	[Longitude] [decimal](10, 7) NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Endereco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Estabelecimento]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Estabelecimento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](100) NOT NULL,
	[Telefone] [nvarchar](12) NOT NULL,
	[HorarioAbertura] [datetime] NOT NULL,
	[HorarioFechamento] [datetime] NOT NULL,
	[PrecoMedio] [decimal](7, 2) NOT NULL,
	[Id_Endereco] [int] NOT NULL,
	[Aprovado] [bit] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Estabelecimento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Estabelecimento_Categoria]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Estabelecimento_Categoria](
	[Id_Estabelecimento] [int] NOT NULL,
	[Id_Categoria] [int] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Estabelecimento_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id_Estabelecimento] ASC,
	[Id_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Estabelecimento_Preferencia]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Estabelecimento_Preferencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Aprovado] [bit] NOT NULL,
	[Id_Estabelecimento] [int] NOT NULL,
	[Id_Preferencia] [int] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Estabelecimento_Preferencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Estabelecimento_Recusado]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Estabelecimento_Recusado](
	[Id_Usuario] [int] NOT NULL,
	[Id_Estabelecimento] [int] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Estabelecimento_Recusado] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC,
	[Id_Estabelecimento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Foto]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Foto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Caminho] [nvarchar](500) NOT NULL,
	[Id_Estabelecimento] [int] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Foto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Grupo]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Grupo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Foto] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Grupo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Grupo_Usuario]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Grupo_Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Aprovado] [bit] NOT NULL,
	[Id_Grupo] [int] NOT NULL,
	[Id_Usuario] [int] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.GrupoUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Preferencia]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Preferencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
	[Aprovado] [bit] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Preferencia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Usuario]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Senha] [nvarchar](150) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[Sobrenome] [nvarchar](50) NOT NULL,
	[FotoPerfil] [nvarchar](500) NOT NULL,
	[Admin] [bit] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [schemaFoodTime].[Usuario_Preferencia]    Script Date: 12/12/2017 13:57:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [schemaFoodTime].[Usuario_Preferencia](
	[Id_Usuario] [int] NOT NULL,
	[Id_Preferencia] [int] NOT NULL,
 CONSTRAINT [PK_schemaFoodTime.Usuario_Preferencia] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC,
	[Id_Preferencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [schemaFoodTime].[Estabelecimento] ADD  DEFAULT ((0)) FOR [Aprovado]
GO
ALTER TABLE [schemaFoodTime].[Grupo] ADD  DEFAULT ('') FOR [Foto]
GO
ALTER TABLE [schemaFoodTime].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Avaliacao_schemaFoodTime.Estabelecimento_IdEstabelecimento] FOREIGN KEY([Id_Estabelecimento])
REFERENCES [schemaFoodTime].[Estabelecimento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Avaliacao] CHECK CONSTRAINT [FK_schemaFoodTime.Avaliacao_schemaFoodTime.Estabelecimento_IdEstabelecimento]
GO
ALTER TABLE [schemaFoodTime].[Avaliacao]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Avaliacao_schemaFoodTime.Usuario_IdUsuario] FOREIGN KEY([Id_Usuario])
REFERENCES [schemaFoodTime].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Avaliacao] CHECK CONSTRAINT [FK_schemaFoodTime.Avaliacao_schemaFoodTime.Usuario_IdUsuario]
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Estabelecimento_schemaFoodTime.Endereco_Id_Endereco] FOREIGN KEY([Id_Endereco])
REFERENCES [schemaFoodTime].[Endereco] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento] CHECK CONSTRAINT [FK_schemaFoodTime.Estabelecimento_schemaFoodTime.Endereco_Id_Endereco]
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Categoria]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Categoria_schemaFoodTime.Categoria_Id_Categoria] FOREIGN KEY([Id_Categoria])
REFERENCES [schemaFoodTime].[Categoria] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Categoria] CHECK CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Categoria_schemaFoodTime.Categoria_Id_Categoria]
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Categoria]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Categoria_schemaFoodTime.Estabelecimento_Id_Estabelecimento] FOREIGN KEY([Id_Estabelecimento])
REFERENCES [schemaFoodTime].[Estabelecimento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Categoria] CHECK CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Categoria_schemaFoodTime.Estabelecimento_Id_Estabelecimento]
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Preferencia]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Preferencia_schemaFoodTime.Estabelecimento_Id_Estabelecimento] FOREIGN KEY([Id_Estabelecimento])
REFERENCES [schemaFoodTime].[Estabelecimento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Preferencia] CHECK CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Preferencia_schemaFoodTime.Estabelecimento_Id_Estabelecimento]
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Preferencia]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Preferencia_schemaFoodTime.Preferencia_Id_Preferencia] FOREIGN KEY([Id_Preferencia])
REFERENCES [schemaFoodTime].[Preferencia] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Preferencia] CHECK CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Preferencia_schemaFoodTime.Preferencia_Id_Preferencia]
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Recusado]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Recusado_schemaFoodTime.Estabelecimento_Id_Estabelecimento] FOREIGN KEY([Id_Estabelecimento])
REFERENCES [schemaFoodTime].[Estabelecimento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Recusado] CHECK CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Recusado_schemaFoodTime.Estabelecimento_Id_Estabelecimento]
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Recusado]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Recusado_schemaFoodTime.Usuario_Id_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [schemaFoodTime].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Estabelecimento_Recusado] CHECK CONSTRAINT [FK_schemaFoodTime.Estabelecimento_Recusado_schemaFoodTime.Usuario_Id_Usuario]
GO
ALTER TABLE [schemaFoodTime].[Foto]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Foto_schemaFoodTime.Estabelecimento_Id_Estabelecimzento] FOREIGN KEY([Id_Estabelecimento])
REFERENCES [schemaFoodTime].[Estabelecimento] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Foto] CHECK CONSTRAINT [FK_schemaFoodTime.Foto_schemaFoodTime.Estabelecimento_Id_Estabelecimzento]
GO
ALTER TABLE [schemaFoodTime].[Grupo_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.GrupoUsuario_schemaFoodTime.Grupo_Id_Grupo] FOREIGN KEY([Id_Grupo])
REFERENCES [schemaFoodTime].[Grupo] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Grupo_Usuario] CHECK CONSTRAINT [FK_schemaFoodTime.GrupoUsuario_schemaFoodTime.Grupo_Id_Grupo]
GO
ALTER TABLE [schemaFoodTime].[Grupo_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.GrupoUsuario_schemaFoodTime.Usuario_Id_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [schemaFoodTime].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Grupo_Usuario] CHECK CONSTRAINT [FK_schemaFoodTime.GrupoUsuario_schemaFoodTime.Usuario_Id_Usuario]
GO
ALTER TABLE [schemaFoodTime].[Usuario_Preferencia]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Usuario_Preferencia_schemaFoodTime.Preferencia_Id_Preferencia] FOREIGN KEY([Id_Preferencia])
REFERENCES [schemaFoodTime].[Preferencia] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Usuario_Preferencia] CHECK CONSTRAINT [FK_schemaFoodTime.Usuario_Preferencia_schemaFoodTime.Preferencia_Id_Preferencia]
GO
ALTER TABLE [schemaFoodTime].[Usuario_Preferencia]  WITH CHECK ADD  CONSTRAINT [FK_schemaFoodTime.Usuario_Preferencia_schemaFoodTime.Usuario_Id_Usuario] FOREIGN KEY([Id_Usuario])
REFERENCES [schemaFoodTime].[Usuario] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [schemaFoodTime].[Usuario_Preferencia] CHECK CONSTRAINT [FK_schemaFoodTime.Usuario_Preferencia_schemaFoodTime.Usuario_Id_Usuario]
GO
