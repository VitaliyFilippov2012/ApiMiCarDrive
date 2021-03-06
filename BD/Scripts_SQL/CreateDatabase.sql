USE [master]
GO

/****** Object:  Database [MiCarDrive]    Script Date: 3/15/2021 9:30:40 PM ******/
CREATE DATABASE [MiCarDrive]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MiCarDrive', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.VITALISQL\MSSQL\DATA\MiCarDrive.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MiCarDrive_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.VITALISQL\MSSQL\DATA\MiCarDrive_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiCarDrive].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MiCarDrive] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MiCarDrive] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MiCarDrive] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MiCarDrive] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MiCarDrive] SET ARITHABORT OFF 
GO

ALTER DATABASE [MiCarDrive] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MiCarDrive] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MiCarDrive] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MiCarDrive] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MiCarDrive] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MiCarDrive] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MiCarDrive] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MiCarDrive] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MiCarDrive] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MiCarDrive] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MiCarDrive] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MiCarDrive] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MiCarDrive] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MiCarDrive] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MiCarDrive] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MiCarDrive] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [MiCarDrive] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MiCarDrive] SET RECOVERY FULL 
GO

ALTER DATABASE [MiCarDrive] SET  MULTI_USER 
GO

ALTER DATABASE [MiCarDrive] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MiCarDrive] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MiCarDrive] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MiCarDrive] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MiCarDrive] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MiCarDrive] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MiCarDrive] SET  READ_WRITE 
GO


