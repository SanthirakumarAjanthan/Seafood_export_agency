USE [master]
GO
/****** Object:  Database [Export]    Script Date: 6/25/2021 12:29:30 PM ******/
CREATE DATABASE [Export]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Export', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Export.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Export_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Export_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Export] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Export].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Export] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Export] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Export] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Export] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Export] SET ARITHABORT OFF 
GO
ALTER DATABASE [Export] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Export] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Export] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Export] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Export] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Export] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Export] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Export] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Export] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Export] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Export] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Export] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Export] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Export] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Export] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Export] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Export] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Export] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Export] SET  MULTI_USER 
GO
ALTER DATABASE [Export] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Export] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Export] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Export] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Export]
GO
/****** Object:  Table [dbo].[Admin_Log]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin_Log](
	[Reg_Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Designation] [nvarchar](100) NULL,
 CONSTRAINT [PK_Admin_Log] PRIMARY KEY CLUSTERED 
(
	[Reg_Id] ASC,
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[category]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[catno] [int] IDENTITY(1,1) NOT NULL,
	[catname] [nvarchar](50) NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[catno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[customer]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[custno] [int] IDENTITY(1,1) NOT NULL,
	[custname] [nvarchar](50) NULL,
	[custemail] [nvarchar](50) NULL,
	[custphone] [nvarchar](15) NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[custno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expo_Details]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Expo_Details](
	[exp_ID] [int] NULL,
	[Cus_ID] [int] NULL,
	[pro_id] [int] NULL,
	[Proname] [varchar](50) NULL,
	[P_Qty] [int] NULL,
	[U_price] [int] NULL,
	[p_tot] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Export]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Export](
	[exp_id] [int] IDENTITY(1,1) NOT NULL,
	[Expd_id] [int] NULL,
	[cus_id] [nvarchar](50) NULL,
	[date] [nvarchar](20) NULL,
	[total] [int] NULL,
	[Status] [nvarchar](20) NULL,
 CONSTRAINT [PK_Export] PRIMARY KEY CLUSTERED 
(
	[exp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[product]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[catno] [nvarchar](50) NOT NULL,
	[proid] [int] IDENTITY(100,1) NOT NULL,
	[proname] [nvarchar](100) NULL,
	[b_price] [nvarchar](20) NULL,
	[S_price] [nvarchar](20) NULL,
	[avqty] [int] NULL,
	[Expdate] [datetime] NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[catno] ASC,
	[proid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[purchase]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchase](
	[pu_id] [int] IDENTITY(1,1) NOT NULL,
	[purch_ID] [int] NULL,
	[sup_id] [nvarchar](50) NULL,
	[date] [nvarchar](20) NULL,
	[total] [int] NULL,
	[Status] [nvarchar](20) NULL,
 CONSTRAINT [PK_purchase] PRIMARY KEY CLUSTERED 
(
	[pu_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchase_Details]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Purchase_Details](
	[purch_ID] [int] NOT NULL,
	[Sup_ID] [int] NULL,
	[pro_id] [int] NULL,
	[Proname] [varchar](50) NULL,
	[P_Qty] [int] NULL,
	[U_price] [int] NULL,
	[p_tot] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[supplier]    Script Date: 6/25/2021 12:29:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[supplier](
	[supno] [int] IDENTITY(1,1) NOT NULL,
	[supname] [nvarchar](50) NULL,
	[supemail] [nvarchar](50) NULL,
	[supphone] [nvarchar](15) NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_supplier] PRIMARY KEY CLUSTERED 
(
	[supno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [Export] SET  READ_WRITE 
GO
