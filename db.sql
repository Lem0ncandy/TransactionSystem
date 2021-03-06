USE [master]
GO
/****** Object:  Database [Transitionsys]    Script Date: 2019/11/18 21:58:14 ******/
CREATE DATABASE [Transitionsys]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Transitionsys', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Transitionsys.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Transitionsys_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Transitionsys_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Transitionsys] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Transitionsys].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Transitionsys] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Transitionsys] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Transitionsys] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Transitionsys] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Transitionsys] SET ARITHABORT OFF 
GO
ALTER DATABASE [Transitionsys] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Transitionsys] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Transitionsys] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Transitionsys] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Transitionsys] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Transitionsys] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Transitionsys] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Transitionsys] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Transitionsys] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Transitionsys] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Transitionsys] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Transitionsys] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Transitionsys] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Transitionsys] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Transitionsys] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Transitionsys] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Transitionsys] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Transitionsys] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Transitionsys] SET  MULTI_USER 
GO
ALTER DATABASE [Transitionsys] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Transitionsys] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Transitionsys] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Transitionsys] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Transitionsys] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Transitionsys] SET QUERY_STORE = OFF
GO
USE [Transitionsys]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2019/11/18 21:58:14 ******/
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
/****** Object:  Table [dbo].[Comments]    Script Date: 2019/11/18 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [uniqueidentifier] NOT NULL,
	[DemandId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Content] [ntext] NOT NULL,
	[CreteTime] [datetime] NOT NULL,
	[IsRemove] [bit] NOT NULL,
	[MinPrice] [real] NOT NULL,
	[MaxPrice] [real] NOT NULL,
	[Title] [varchar](80) NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Demands]    Script Date: 2019/11/18 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demands](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](60) NOT NULL,
	[Content] [ntext] NOT NULL,
	[CreteTime] [datetime] NOT NULL,
	[IsRemove] [bit] NOT NULL,
	[IsHidden] [bit] NOT NULL,
	[Introduction] [varchar](80) NOT NULL,
 CONSTRAINT [PK_dbo.Demands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedBacks]    Script Date: 2019/11/18 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBacks](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](80) NOT NULL,
	[Content] [ntext] NOT NULL,
	[CreteTime] [datetime] NOT NULL,
	[IsRemove] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.FeedBacks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2019/11/18 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [uniqueidentifier] NOT NULL,
	[DemandId] [uniqueidentifier] NOT NULL,
	[CommentId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[OrderState] [int] NOT NULL,
	[CreteTime] [datetime] NOT NULL,
	[IsRemove] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Replies]    Script Date: 2019/11/18 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Replies](
	[Id] [uniqueidentifier] NOT NULL,
	[CommentId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Content] [ntext] NOT NULL,
	[CreteTime] [datetime] NOT NULL,
	[IsRemove] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Replies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2019/11/18 21:58:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[UserName] [varchar](16) NULL,
	[ImagePath] [varchar](300) NULL,
	[UesrType] [int] NOT NULL,
	[TelphoneNumber] [varchar](11) NULL,
	[Address] [varchar](8000) NULL,
	[RealName] [varchar](10) NULL,
	[CompanyName] [varchar](50) NULL,
	[CreteTime] [datetime] NOT NULL,
	[IsRemove] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_DemandId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_DemandId] ON [dbo].[Comments]
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Demands]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[FeedBacks]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CommentId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_CommentId] ON [dbo].[Orders]
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DemandId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_DemandId] ON [dbo].[Orders]
(
	[DemandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CommentId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_CommentId] ON [dbo].[Replies]
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 2019/11/18 21:58:14 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Replies]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT ((0)) FOR [MinPrice]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT ((0)) FOR [MaxPrice]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT ('') FOR [Title]
GO
ALTER TABLE [dbo].[Demands] ADD  DEFAULT ((0)) FOR [IsHidden]
GO
ALTER TABLE [dbo].[Demands] ADD  DEFAULT ('') FOR [Introduction]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comments_dbo.Demands_DemandId] FOREIGN KEY([DemandId])
REFERENCES [dbo].[Demands] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_dbo.Comments_dbo.Demands_DemandId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Comments_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_dbo.Comments_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Demands]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Demands_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Demands] CHECK CONSTRAINT [FK_dbo.Demands_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[FeedBacks]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FeedBacks_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[FeedBacks] CHECK CONSTRAINT [FK_dbo.FeedBacks_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Comments_CommentId] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comments] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Comments_CommentId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Demands_DemandId] FOREIGN KEY([DemandId])
REFERENCES [dbo].[Demands] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Demands_DemandId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Replies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Replies_dbo.Comments_CommentId] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comments] ([Id])
GO
ALTER TABLE [dbo].[Replies] CHECK CONSTRAINT [FK_dbo.Replies_dbo.Comments_CommentId]
GO
ALTER TABLE [dbo].[Replies]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Replies_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Replies] CHECK CONSTRAINT [FK_dbo.Replies_dbo.Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [Transitionsys] SET  READ_WRITE 
GO
