USE [master]
GO
/****** Object:  Database [PasswordGen]    Script Date: 10.05.2023 12:42:19 ******/
CREATE DATABASE [PasswordGen]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PasswordGen', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PasswordGen.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PasswordGen_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PasswordGen_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PasswordGen] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PasswordGen].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PasswordGen] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PasswordGen] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PasswordGen] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PasswordGen] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PasswordGen] SET ARITHABORT OFF 
GO
ALTER DATABASE [PasswordGen] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PasswordGen] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PasswordGen] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PasswordGen] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PasswordGen] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PasswordGen] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PasswordGen] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PasswordGen] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PasswordGen] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PasswordGen] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PasswordGen] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PasswordGen] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PasswordGen] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PasswordGen] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PasswordGen] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PasswordGen] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PasswordGen] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PasswordGen] SET RECOVERY FULL 
GO
ALTER DATABASE [PasswordGen] SET  MULTI_USER 
GO
ALTER DATABASE [PasswordGen] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PasswordGen] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PasswordGen] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PasswordGen] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PasswordGen] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PasswordGen] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PasswordGen', N'ON'
GO
ALTER DATABASE [PasswordGen] SET QUERY_STORE = OFF
GO
USE [PasswordGen]
GO
/****** Object:  Table [dbo].[PasswordContainer]    Script Date: 10.05.2023 12:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordContainer](
	[Nazwa] [varchar](50) NOT NULL,
	[Haslo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PasswordContainer] PRIMARY KEY CLUSTERED 
(
	[Nazwa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PasswordContainer] ([Nazwa], [Haslo]) VALUES (N'KolejnyTest', N'$DnEDe,E2&')
INSERT [dbo].[PasswordContainer] ([Nazwa], [Haslo]) VALUES (N'nastepnytest', N'5iu98:PUOY')
GO
USE [master]
GO
ALTER DATABASE [PasswordGen] SET  READ_WRITE 
GO
