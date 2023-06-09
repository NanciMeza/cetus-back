USE [master]
GO
/****** Object:  Database [Cetus]    Script Date: 2/06/2023 7:41:46 p. m. ******/
CREATE DATABASE [Cetus] ON  PRIMARY 
( NAME = N'Cetus', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Cetus.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Cetus_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Cetus_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Cetus] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cetus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cetus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cetus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cetus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cetus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cetus] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cetus] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Cetus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cetus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cetus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cetus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cetus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cetus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cetus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cetus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cetus] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cetus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cetus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cetus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cetus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cetus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cetus] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Cetus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cetus] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cetus] SET  MULTI_USER 
GO
ALTER DATABASE [Cetus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cetus] SET DB_CHAINING OFF 
GO
USE [Cetus]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/06/2023 7:41:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/06/2023 7:41:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[NombreLaboratorio] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 2/06/2023 7:41:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[ProveedorId] [int] IDENTITY(1,1) NOT NULL,
	[TipoIdentificacion] [nvarchar](max) NULL,
	[NombreRazonSocial] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[NombreContacto] [nvarchar](max) NULL,
	[CelularContacto] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
	[NumIdentificacion] [int] NOT NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceptionProducts]    Script Date: 2/06/2023 7:41:46 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceptionProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaHoraRecepcion] [datetime2](7) NOT NULL,
	[ProductoId] [int] NOT NULL,
	[ProveedorId] [int] NOT NULL,
	[Factura] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Lote] [int] NOT NULL,
	[RegistroInvima] [nvarchar](max) NULL,
	[FechaVencimiento] [datetime2](7) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
 CONSTRAINT [PK_ReceptionProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Providers] ADD  DEFAULT ((0)) FOR [NumIdentificacion]
GO
USE [master]
GO
ALTER DATABASE [Cetus] SET  READ_WRITE 
GO
