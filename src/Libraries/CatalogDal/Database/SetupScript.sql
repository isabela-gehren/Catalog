USE [master]
GO
/****** Object:  Database [CatalogCategoriesAndProducts]    Script Date: 15/01/2014 23:34:38 ******/
CREATE DATABASE [CatalogCategoriesAndProducts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CatalogCategoriesAndProducts', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CatalogCategoriesAndProducts.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CatalogCategoriesAndProducts_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\CatalogCategoriesAndProducts_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CatalogCategoriesAndProducts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET ARITHABORT OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET RECOVERY FULL 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET  MULTI_USER 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CatalogCategoriesAndProducts', N'ON'
GO
USE [CatalogCategoriesAndProducts]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 15/01/2014 23:34:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 15/01/2014 23:34:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[ParentCategoryId] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 15/01/2014 23:34:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[BrandId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 15/01/2014 23:34:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Brand_Name]    Script Date: 15/01/2014 23:34:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Brand_Name] ON [dbo].[Brand]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Category_Name]    Script Date: 15/01/2014 23:34:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Category_Name] ON [dbo].[Category]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Product_Name]    Script Date: 15/01/2014 23:34:40 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Product_Name] ON [dbo].[Product]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_ParentCategory] FOREIGN KEY([ParentCategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_ParentCategory]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO
USE [master]
GO
ALTER DATABASE [CatalogCategoriesAndProducts] SET  READ_WRITE 
GO
