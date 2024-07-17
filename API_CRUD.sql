USE [master]
GO
/****** Object:  Database [API_CRUD]    Script Date: 17/07/2024 02:28:51 a. m. ******/
CREATE DATABASE [API_CRUD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'API_CRUD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\API_CRUD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'API_CRUD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\API_CRUD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [API_CRUD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [API_CRUD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [API_CRUD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [API_CRUD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [API_CRUD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [API_CRUD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [API_CRUD] SET ARITHABORT OFF 
GO
ALTER DATABASE [API_CRUD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [API_CRUD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [API_CRUD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [API_CRUD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [API_CRUD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [API_CRUD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [API_CRUD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [API_CRUD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [API_CRUD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [API_CRUD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [API_CRUD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [API_CRUD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [API_CRUD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [API_CRUD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [API_CRUD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [API_CRUD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [API_CRUD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [API_CRUD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [API_CRUD] SET  MULTI_USER 
GO
ALTER DATABASE [API_CRUD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [API_CRUD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [API_CRUD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [API_CRUD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [API_CRUD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [API_CRUD] SET QUERY_STORE = OFF
GO
USE [API_CRUD]
GO
/****** Object:  Table [dbo].[Tb_HccAlmacen]    Script Date: 17/07/2024 02:28:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_HccAlmacen](
	[alm_id] [int] IDENTITY(1,1) NOT NULL,
	[alm_cantidad] [int] NOT NULL,
	[alm_fecha_actualizacion] [date] NOT NULL,
	[alm_estatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Tb_HccAlmacen] PRIMARY KEY CLUSTERED 
(
	[alm_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_HccCatEstatusOrden]    Script Date: 17/07/2024 02:28:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_HccCatEstatusOrden](
	[catord_id] [int] IDENTITY(1,1) NOT NULL,
	[catord_nombre] [varchar](50) NOT NULL,
	[catord_estatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Tb_HccCatEstatusOrden] PRIMARY KEY CLUSTERED 
(
	[catord_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_HccMesas]    Script Date: 17/07/2024 02:28:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_HccMesas](
	[mes_id] [int] IDENTITY(1,1) NOT NULL,
	[mes_lugares] [smallint] NOT NULL,
	[mes_disponible] [tinyint] NOT NULL,
	[mes_estatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Tb_HccMesas] PRIMARY KEY CLUSTERED 
(
	[mes_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_HccOrdenes]    Script Date: 17/07/2024 02:28:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_HccOrdenes](
	[ord_id] [int] NOT NULL,
	[mes_id] [int] NOT NULL,
	[catord_id] [int] NOT NULL,
	[ord_fecha_inicio] [datetime] NOT NULL,
	[ord_estatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Tb_HccOrdenes_1] PRIMARY KEY CLUSTERED 
(
	[ord_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_HccOrdenesDetalle]    Script Date: 17/07/2024 02:28:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_HccOrdenesDetalle](
	[orddet_id] [int] NOT NULL,
	[ord_id] [int] NOT NULL,
	[pro_id] [int] NOT NULL,
	[orddet_cantidad] [smallint] NOT NULL,
	[orddet_estatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Tb_HccOrdenesDetalle_1] PRIMARY KEY CLUSTERED 
(
	[orddet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_HccProductos]    Script Date: 17/07/2024 02:28:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_HccProductos](
	[pro_id] [int] IDENTITY(1,1) NOT NULL,
	[alm_id] [int] NOT NULL,
	[pro_nombre] [varchar](50) NOT NULL,
	[pro_descripcion] [varchar](120) NOT NULL,
	[pro_precio] [decimal](10, 4) NOT NULL,
	[pro_estatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Tb_HccProductos] PRIMARY KEY CLUSTERED 
(
	[pro_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tb_HccCatEstatusOrden] ON 

INSERT [dbo].[Tb_HccCatEstatusOrden] ([catord_id], [catord_nombre], [catord_estatus]) VALUES (1, N'nueva orden', 1)
INSERT [dbo].[Tb_HccCatEstatusOrden] ([catord_id], [catord_nombre], [catord_estatus]) VALUES (2, N'orden recibida', 1)
INSERT [dbo].[Tb_HccCatEstatusOrden] ([catord_id], [catord_nombre], [catord_estatus]) VALUES (3, N'orden en preparación', 1)
INSERT [dbo].[Tb_HccCatEstatusOrden] ([catord_id], [catord_nombre], [catord_estatus]) VALUES (4, N'orden lista', 1)
INSERT [dbo].[Tb_HccCatEstatusOrden] ([catord_id], [catord_nombre], [catord_estatus]) VALUES (5, N'orden pagada', 1)
SET IDENTITY_INSERT [dbo].[Tb_HccCatEstatusOrden] OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_HccMesas] ON 

INSERT [dbo].[Tb_HccMesas] ([mes_id], [mes_lugares], [mes_disponible], [mes_estatus]) VALUES (1, 4, 1, 1)
INSERT [dbo].[Tb_HccMesas] ([mes_id], [mes_lugares], [mes_disponible], [mes_estatus]) VALUES (2, 4, 1, 1)
INSERT [dbo].[Tb_HccMesas] ([mes_id], [mes_lugares], [mes_disponible], [mes_estatus]) VALUES (3, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[Tb_HccMesas] OFF
GO
INSERT [dbo].[Tb_HccOrdenes] ([ord_id], [mes_id], [catord_id], [ord_fecha_inicio], [ord_estatus]) VALUES (1, 1, 1, CAST(N'2024-07-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Tb_HccOrdenes] ([ord_id], [mes_id], [catord_id], [ord_fecha_inicio], [ord_estatus]) VALUES (2, 2, 1, CAST(N'2024-07-17T02:09:00.633' AS DateTime), 1)
GO
INSERT [dbo].[Tb_HccOrdenesDetalle] ([orddet_id], [ord_id], [pro_id], [orddet_cantidad], [orddet_estatus]) VALUES (1, 1, 2, 2, 1)
INSERT [dbo].[Tb_HccOrdenesDetalle] ([orddet_id], [ord_id], [pro_id], [orddet_cantidad], [orddet_estatus]) VALUES (2, 1, 2, 3, 1)
INSERT [dbo].[Tb_HccOrdenesDetalle] ([orddet_id], [ord_id], [pro_id], [orddet_cantidad], [orddet_estatus]) VALUES (3, 2, 3, 5, 1)
INSERT [dbo].[Tb_HccOrdenesDetalle] ([orddet_id], [ord_id], [pro_id], [orddet_cantidad], [orddet_estatus]) VALUES (4, 2, 3, 5, 1)
INSERT [dbo].[Tb_HccOrdenesDetalle] ([orddet_id], [ord_id], [pro_id], [orddet_cantidad], [orddet_estatus]) VALUES (5, 1, 1, 10, 1)
GO
SET IDENTITY_INSERT [dbo].[Tb_HccProductos] ON 

INSERT [dbo].[Tb_HccProductos] ([pro_id], [alm_id], [pro_nombre], [pro_descripcion], [pro_precio], [pro_estatus]) VALUES (1, 1, N'Café Americano', N'Café negro sin azúcar', CAST(25.0000 AS Decimal(10, 4)), 1)
INSERT [dbo].[Tb_HccProductos] ([pro_id], [alm_id], [pro_nombre], [pro_descripcion], [pro_precio], [pro_estatus]) VALUES (2, 2, N'Capuchino', N'Café con leche y espuma', CAST(30.0000 AS Decimal(10, 4)), 1)
INSERT [dbo].[Tb_HccProductos] ([pro_id], [alm_id], [pro_nombre], [pro_descripcion], [pro_precio], [pro_estatus]) VALUES (3, 3, N'Té Verde', N'Té de hojas verdes', CAST(20.0000 AS Decimal(10, 4)), 1)
SET IDENTITY_INSERT [dbo].[Tb_HccProductos] OFF
GO
USE [master]
GO
ALTER DATABASE [API_CRUD] SET  READ_WRITE 
GO
