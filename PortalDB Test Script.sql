USE [PortalDB]
GO
ALTER TABLE [dbo].[LoginUser] DROP CONSTRAINT [FK_LoginUser_Role]
GO
ALTER TABLE [dbo].[LoginUser] DROP CONSTRAINT [FK_LoginUser_LoginUser]
GO
ALTER TABLE [dbo].[LoginUser] DROP CONSTRAINT [DF__LoginUser__Creat__5FB337D6]
GO
ALTER TABLE [dbo].[LoginUser] DROP CONSTRAINT [DF__LoginUser__Statu__5EBF139D]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29-04-2020 13:26:48 ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 29-04-2020 13:26:48 ******/
DROP TABLE [dbo].[LoginUser]
GO
USE [master]
GO
/****** Object:  Database [PortalDB]    Script Date: 29-04-2020 13:26:48 ******/
DROP DATABASE [PortalDB]
GO
/****** Object:  Database [PortalDB]    Script Date: 29-04-2020 13:26:48 ******/
CREATE DATABASE [PortalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PortalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PortalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PortalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\PortalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PortalDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PortalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PortalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PortalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PortalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PortalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PortalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PortalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PortalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PortalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PortalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PortalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PortalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PortalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PortalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PortalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PortalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PortalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PortalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PortalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PortalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PortalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PortalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PortalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PortalDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PortalDB] SET  MULTI_USER 
GO
ALTER DATABASE [PortalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PortalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PortalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PortalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PortalDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PortalDB', N'ON'
GO
ALTER DATABASE [PortalDB] SET QUERY_STORE = OFF
GO
USE [PortalDB]
GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 29-04-2020 13:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nchar](100) NOT NULL,
	[MobileNumber] [nvarchar](15) NOT NULL,
	[Address] [nvarchar](1000) NOT NULL,
	[Status] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdateedDate] [datetime] NULL,
	[UpdateddBy] [int] NULL,
 CONSTRAINT [PK__LoginUse__1788CC4C11DC2303] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29-04-2020 13:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LoginUser] ON 

INSERT [dbo].[LoginUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [Address], [Status], [RoleId], [CreatedBy], [CreatedDate], [UpdateedDate], [UpdateddBy]) VALUES (15, N'Rahul Singh', N'admin@admin.com', N'123                                                                                                 ', N'8989776767', N'Delhi', 1, 1, 1, CAST(N'2020-04-29T10:12:09.120' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [Address], [Status], [RoleId], [CreatedBy], [CreatedDate], [UpdateedDate], [UpdateddBy]) VALUES (16, N'Sanjay', N'Agent@agent.com', N'1234                                                                                                ', N'6767567876', N'Chennai', 1, 3, 2, CAST(N'2020-04-29T10:12:44.143' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [Address], [Status], [RoleId], [CreatedBy], [CreatedDate], [UpdateedDate], [UpdateddBy]) VALUES (17, N'Manohar', N'Super@super.com', N'12345                                                                                               ', N'878654325', N'Mumbai', 1, 2, 1, CAST(N'2020-04-29T10:13:22.387' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [Address], [Status], [RoleId], [CreatedBy], [CreatedDate], [UpdateedDate], [UpdateddBy]) VALUES (18, N'Sanjay Kumar', N'sanju@gmail.com', N'123                                                                                                 ', N'7776665554', N'Delhi UttamNagar', 1, 1, 1, CAST(N'2020-04-29T11:56:40.300' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [Address], [Status], [RoleId], [CreatedBy], [CreatedDate], [UpdateedDate], [UpdateddBy]) VALUES (19, N'Rajnish', N'raj@gmail.com', N'123                                                                                                 ', N'12345', N'123', 1, 2, 1, CAST(N'2020-04-29T12:31:01.737' AS DateTime), NULL, NULL)
INSERT [dbo].[LoginUser] ([UserId], [FullName], [Email], [Password], [MobileNumber], [Address], [Status], [RoleId], [CreatedBy], [CreatedDate], [UpdateedDate], [UpdateddBy]) VALUES (20, N'Kaliya', N'kali@gmail.com', N'123                                                                                                 ', N'12345667', N'123', 1, 2, 17, CAST(N'2020-04-29T12:46:21.137' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[LoginUser] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [Role]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([RoleID], [Role]) VALUES (2, N'Supervisor')
INSERT [dbo].[Role] ([RoleID], [Role]) VALUES (3, N'Agent')
SET IDENTITY_INSERT [dbo].[Role] OFF
ALTER TABLE [dbo].[LoginUser] ADD  CONSTRAINT [DF__LoginUser__Statu__5EBF139D]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[LoginUser] ADD  CONSTRAINT [DF__LoginUser__Creat__5FB337D6]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[LoginUser]  WITH CHECK ADD  CONSTRAINT [FK_LoginUser_LoginUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[LoginUser] ([UserId])
GO
ALTER TABLE [dbo].[LoginUser] CHECK CONSTRAINT [FK_LoginUser_LoginUser]
GO
ALTER TABLE [dbo].[LoginUser]  WITH CHECK ADD  CONSTRAINT [FK_LoginUser_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[LoginUser] CHECK CONSTRAINT [FK_LoginUser_Role]
GO
USE [master]
GO
ALTER DATABASE [PortalDB] SET  READ_WRITE 
GO
