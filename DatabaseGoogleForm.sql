USE [master]
GO
/****** Object:  Database [GoogleForm]    Script Date: 12/20/2017 22:56:13 ******/
CREATE DATABASE [GoogleForm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GoogleForm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GoogleForm.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GoogleForm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GoogleForm_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GoogleForm] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GoogleForm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GoogleForm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GoogleForm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GoogleForm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GoogleForm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GoogleForm] SET ARITHABORT OFF 
GO
ALTER DATABASE [GoogleForm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GoogleForm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GoogleForm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GoogleForm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GoogleForm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GoogleForm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GoogleForm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GoogleForm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GoogleForm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GoogleForm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GoogleForm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GoogleForm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GoogleForm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GoogleForm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GoogleForm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GoogleForm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GoogleForm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GoogleForm] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GoogleForm] SET  MULTI_USER 
GO
ALTER DATABASE [GoogleForm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GoogleForm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GoogleForm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GoogleForm] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GoogleForm] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GoogleForm]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 12/20/2017 22:56:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AnwserDetails]    Script Date: 12/20/2017 22:56:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnwserDetails](
	[AnwserId] [int] IDENTITY(1,1) NOT NULL,
	[Detail] [nvarchar](1000) NOT NULL,
	[UserId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AnwserDetails] PRIMARY KEY CLUSTERED 
(
	[AnwserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Forms]    Script Date: 12/20/2017 22:56:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dbo.Forms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Questions]    Script Date: 12/20/2017 22:56:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionName] [nvarchar](max) NOT NULL,
	[Type] [int] NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[FormId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AnwserDetails] ON 

INSERT [dbo].[AnwserDetails] ([AnwserId], [Detail], [UserId], [QuestionId]) VALUES (6, N'ngô văn phấn', 1, 1)
INSERT [dbo].[AnwserDetails] ([AnwserId], [Detail], [UserId], [QuestionId]) VALUES (7, N'1997-08-15', 1, 4)
INSERT [dbo].[AnwserDetails] ([AnwserId], [Detail], [UserId], [QuestionId]) VALUES (8, N'Chơi Game', 1, 5)
INSERT [dbo].[AnwserDetails] ([AnwserId], [Detail], [UserId], [QuestionId]) VALUES (9, N'SI;SE', 1, 3)
INSERT [dbo].[AnwserDetails] ([AnwserId], [Detail], [UserId], [QuestionId]) VALUES (10, N'Nam', 1, 2)
SET IDENTITY_INSERT [dbo].[AnwserDetails] OFF
SET IDENTITY_INSERT [dbo].[Forms] ON 

INSERT [dbo].[Forms] ([Id]) VALUES (1)
SET IDENTITY_INSERT [dbo].[Forms] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionId], [QuestionName], [Type], [Answer], [FormId]) VALUES (1, N'Họ Tên', 1, N'', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuestionName], [Type], [Answer], [FormId]) VALUES (2, N'Giới tính', 2, N'Nam; Nữ', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuestionName], [Type], [Answer], [FormId]) VALUES (3, N'Chuyên nghành', 3, N'muckhac_ SI; IT', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuestionName], [Type], [Answer], [FormId]) VALUES (4, N'Ngày Sinh', 4, N'', 1)
INSERT [dbo].[Questions] ([QuestionId], [QuestionName], [Type], [Answer], [FormId]) VALUES (5, N'Sở thích', 5, N'Xem Tivi; Chơi Game; Đọc báo', 1)
SET IDENTITY_INSERT [dbo].[Questions] OFF
/****** Object:  Index [IX_QuestionId]    Script Date: 12/20/2017 22:56:13 ******/
CREATE NONCLUSTERED INDEX [IX_QuestionId] ON [dbo].[AnwserDetails]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FormId]    Script Date: 12/20/2017 22:56:13 ******/
CREATE NONCLUSTERED INDEX [IX_FormId] ON [dbo].[Questions]
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AnwserDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AnwserDetails_dbo.Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AnwserDetails] CHECK CONSTRAINT [FK_dbo.AnwserDetails_dbo.Questions_QuestionId]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Questions_dbo.Forms_FormId] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_dbo.Questions_dbo.Forms_FormId]
GO
/****** Object:  StoredProcedure [dbo].[DynamicPivot]    Script Date: 12/20/2017 22:56:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DynamicPivot]
 @FormID int
AS
 Declare @QuestionId int
 Declare @QuestionName nvarchar(max),@Name nvarchar(max)
 set @QuestionId = (select min(QuestionId) From Questions Where FormId=@FormID)
 set @QuestionName = (select QuestionName from Questions where QuestionId = @QuestionId)
 set @Name = N''
 DECLARE @sql AS nvarchar(MAX)
 begin
 					
 while @QuestionName is not null
 BEGIN
	set @Name = @Name + N',['+@QuestionName+']'
	set @QuestionId = (select min(QuestionId) From Questions Where QuestionId > @QuestionId and QuestionId in 
						(select QuestionId From Questions Where FormId=@FormID))
	set @QuestionName = (select QuestionName from Questions where QuestionId = @QuestionId)
	
 END
	set @Name = SUBSTRING(@Name,2,LEN(@Name))
	print @FormID
	SET @sql = N'select UserId,'+ @Name +'
	from (select Detail,UserId,QuestionName 
	from  AnwserDetails a inner join Questions q on a.QuestionId=q.QuestionId where FormId='+CONVERT(nvarchar(10),@FormID)+') as a
	pivot(max(Detail) for QuestionName in ('+@Name+')) piv'
	print @sql
	EXEC sp_executesql @sql
 end


GO
USE [master]
GO
ALTER DATABASE [GoogleForm] SET  READ_WRITE 
GO
