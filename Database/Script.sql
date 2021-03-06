USE [dbMovies]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblRating]') AND type in (N'U'))
ALTER TABLE [dbo].[tblRating] DROP CONSTRAINT IF EXISTS [FK_tblRating_tblUser_UserId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblRating]') AND type in (N'U'))
ALTER TABLE [dbo].[tblRating] DROP CONSTRAINT IF EXISTS [FK_tblRating_tblMovie_MovieId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]') AND type in (N'U'))
ALTER TABLE [dbo].[tblMovieGenre] DROP CONSTRAINT IF EXISTS [FK_tblMovieGenre_tblMovie_MovieId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]') AND type in (N'U'))
ALTER TABLE [dbo].[tblMovieGenre] DROP CONSTRAINT IF EXISTS [FK_tblMovieGenre_tblGenre_GenreId]
GO
/****** Object:  Index [IX_tblRating_UserId]    Script Date: 26/05/2019 17:29:16 ******/
DROP INDEX IF EXISTS [IX_tblRating_UserId] ON [dbo].[tblRating]
GO
/****** Object:  Index [IX_tblRating_MovieId]    Script Date: 26/05/2019 17:29:16 ******/
DROP INDEX IF EXISTS [IX_tblRating_MovieId] ON [dbo].[tblRating]
GO
/****** Object:  Index [IX_tblMovieGenre_MovieId]    Script Date: 26/05/2019 17:29:16 ******/
DROP INDEX IF EXISTS [IX_tblMovieGenre_MovieId] ON [dbo].[tblMovieGenre]
GO
/****** Object:  Index [IX_tblMovieGenre_GenreId]    Script Date: 26/05/2019 17:29:16 ******/
DROP INDEX IF EXISTS [IX_tblMovieGenre_GenreId] ON [dbo].[tblMovieGenre]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 26/05/2019 17:29:16 ******/
DROP TABLE IF EXISTS [dbo].[tblUser]
GO
/****** Object:  Table [dbo].[tblRating]    Script Date: 26/05/2019 17:29:16 ******/
DROP TABLE IF EXISTS [dbo].[tblRating]
GO
/****** Object:  Table [dbo].[tblMovieGenre]    Script Date: 26/05/2019 17:29:16 ******/
DROP TABLE IF EXISTS [dbo].[tblMovieGenre]
GO
/****** Object:  Table [dbo].[tblMovie]    Script Date: 26/05/2019 17:29:16 ******/
DROP TABLE IF EXISTS [dbo].[tblMovie]
GO
/****** Object:  Table [dbo].[tblGenre]    Script Date: 26/05/2019 17:29:16 ******/
DROP TABLE IF EXISTS [dbo].[tblGenre]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/05/2019 17:29:16 ******/
DROP TABLE IF EXISTS [dbo].[__EFMigrationsHistory]
GO
USE [master]
GO
/****** Object:  Database [dbMovies]    Script Date: 26/05/2019 17:29:16 ******/
DROP DATABASE IF EXISTS [dbMovies]
GO
/****** Object:  Database [dbMovies]    Script Date: 26/05/2019 17:29:16 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'dbMovies')
BEGIN
CREATE DATABASE [dbMovies]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbMovies', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQL2016\MSSQL\DATA\dbMovies.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbMovies_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQL2016\MSSQL\DATA\dbMovies_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END
GO
ALTER DATABASE [dbMovies] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbMovies].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbMovies] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbMovies] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbMovies] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbMovies] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbMovies] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbMovies] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbMovies] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbMovies] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbMovies] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbMovies] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbMovies] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbMovies] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbMovies] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbMovies] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbMovies] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbMovies] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbMovies] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbMovies] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbMovies] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbMovies] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbMovies] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbMovies] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbMovies] SET RECOVERY FULL 
GO
ALTER DATABASE [dbMovies] SET  MULTI_USER 
GO
ALTER DATABASE [dbMovies] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbMovies] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbMovies] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbMovies] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbMovies] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'dbMovies', N'ON'
GO
ALTER DATABASE [dbMovies] SET QUERY_STORE = OFF
GO
USE [dbMovies]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [dbMovies]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/05/2019 17:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblGenre]    Script Date: 26/05/2019 17:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblGenre]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblGenre](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblGenre] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblMovie]    Script Date: 26/05/2019 17:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblMovie]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblMovie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[YearOfRelease] [int] NOT NULL,
	[RunningTime] [int] NOT NULL,
 CONSTRAINT [PK_tblMovie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblMovieGenre]    Script Date: 26/05/2019 17:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblMovieGenre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_tblMovieGenre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblRating]    Script Date: 26/05/2019 17:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblRating]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblRating](
	[MovieRatingId] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[Rating] [decimal](18, 1) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_tblRating] PRIMARY KEY CLUSTERED 
(
	[MovieRatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 26/05/2019 17:29:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tblUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190526162851_Setup-Data', N'2.2.4-servicing-10062')
GO
SET IDENTITY_INSERT [dbo].[tblGenre] ON 
GO
INSERT [dbo].[tblGenre] ([GenreId], [Name]) VALUES (1, N'Action')
GO
INSERT [dbo].[tblGenre] ([GenreId], [Name]) VALUES (2, N'Thriller')
GO
INSERT [dbo].[tblGenre] ([GenreId], [Name]) VALUES (3, N'Comedy')
GO
INSERT [dbo].[tblGenre] ([GenreId], [Name]) VALUES (4, N'Animation')
GO
INSERT [dbo].[tblGenre] ([GenreId], [Name]) VALUES (5, N'Romance')
GO
SET IDENTITY_INSERT [dbo].[tblGenre] OFF
GO
SET IDENTITY_INSERT [dbo].[tblMovie] ON 
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (1, 1, N'Road Trip', 2000, 94)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (2, 2, N'Avengers Endgame', 2019, 182)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (3, 3, N'Wonder Woman', 2017, 149)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (4, 4, N'The Silence Of The Lambs', 1991, 139)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (5, 5, N'It', 2017, 135)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (6, 6, N'Bridesmaids', 2011, 132)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (7, 7, N'Incredibles 2', 2018, 125)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (8, 8, N'The Lion King', 1994, 89)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (9, 9, N'The Hangover', 2009, 108)
GO
INSERT [dbo].[tblMovie] ([Id], [MovieId], [Title], [YearOfRelease], [RunningTime]) VALUES (10, 10, N'Hot Fuzz', 2007, 121)
GO
SET IDENTITY_INSERT [dbo].[tblMovie] OFF
GO
SET IDENTITY_INSERT [dbo].[tblMovieGenre] ON 
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (1, 1, 3)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (2, 2, 1)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (3, 2, 2)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (4, 3, 1)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (5, 4, 2)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (6, 5, 2)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (7, 6, 1)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (8, 7, 4)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (9, 8, 4)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (10, 9, 3)
GO
INSERT [dbo].[tblMovieGenre] ([Id], [MovieId], [GenreId]) VALUES (11, 10, 3)
GO
SET IDENTITY_INSERT [dbo].[tblMovieGenre] OFF
GO
SET IDENTITY_INSERT [dbo].[tblRating] ON 
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (1, 1, CAST(4.5 AS Decimal(18, 1)), 1)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (2, 2, CAST(4.2 AS Decimal(18, 1)), 1)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (3, 1, CAST(4.5 AS Decimal(18, 1)), 2)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (4, 2, CAST(4.2 AS Decimal(18, 1)), 2)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (5, 3, CAST(3.8 AS Decimal(18, 1)), 1)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (6, 8, CAST(2.4 AS Decimal(18, 1)), 2)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (7, 5, CAST(4.9 AS Decimal(18, 1)), 1)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (9, 4, CAST(1.4 AS Decimal(18, 1)), 2)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (10, 5, CAST(4.9 AS Decimal(18, 1)), 2)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (11, 7, CAST(3.0 AS Decimal(18, 1)), 1)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (12, 7, CAST(3.8 AS Decimal(18, 1)), 2)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (13, 9, CAST(3.8 AS Decimal(18, 1)), 1)
GO
INSERT [dbo].[tblRating] ([MovieRatingId], [MovieId], [Rating], [UserId]) VALUES (14, 10, CAST(3.8 AS Decimal(18, 1)), 1)
GO
SET IDENTITY_INSERT [dbo].[tblRating] OFF
GO
SET IDENTITY_INSERT [dbo].[tblUser] ON 
GO
INSERT [dbo].[tblUser] ([UserId], [Name]) VALUES (1, N'Paul Saxton')
GO
INSERT [dbo].[tblUser] ([UserId], [Name]) VALUES (2, N'Fred Smith')
GO
INSERT [dbo].[tblUser] ([UserId], [Name]) VALUES (3, N'John Jones')
GO
SET IDENTITY_INSERT [dbo].[tblUser] OFF
GO
/****** Object:  Index [IX_tblMovieGenre_GenreId]    Script Date: 26/05/2019 17:29:16 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]') AND name = N'IX_tblMovieGenre_GenreId')
CREATE NONCLUSTERED INDEX [IX_tblMovieGenre_GenreId] ON [dbo].[tblMovieGenre]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblMovieGenre_MovieId]    Script Date: 26/05/2019 17:29:16 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]') AND name = N'IX_tblMovieGenre_MovieId')
CREATE NONCLUSTERED INDEX [IX_tblMovieGenre_MovieId] ON [dbo].[tblMovieGenre]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblRating_MovieId]    Script Date: 26/05/2019 17:29:16 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblRating]') AND name = N'IX_tblRating_MovieId')
CREATE NONCLUSTERED INDEX [IX_tblRating_MovieId] ON [dbo].[tblRating]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_tblRating_UserId]    Script Date: 26/05/2019 17:29:16 ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[tblRating]') AND name = N'IX_tblRating_UserId')
CREATE NONCLUSTERED INDEX [IX_tblRating_UserId] ON [dbo].[tblRating]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblMovieGenre_tblGenre_GenreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]'))
ALTER TABLE [dbo].[tblMovieGenre]  WITH CHECK ADD  CONSTRAINT [FK_tblMovieGenre_tblGenre_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[tblGenre] ([GenreId])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblMovieGenre_tblGenre_GenreId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]'))
ALTER TABLE [dbo].[tblMovieGenre] CHECK CONSTRAINT [FK_tblMovieGenre_tblGenre_GenreId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblMovieGenre_tblMovie_MovieId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]'))
ALTER TABLE [dbo].[tblMovieGenre]  WITH CHECK ADD  CONSTRAINT [FK_tblMovieGenre_tblMovie_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[tblMovie] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblMovieGenre_tblMovie_MovieId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblMovieGenre]'))
ALTER TABLE [dbo].[tblMovieGenre] CHECK CONSTRAINT [FK_tblMovieGenre_tblMovie_MovieId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblRating_tblMovie_MovieId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblRating]'))
ALTER TABLE [dbo].[tblRating]  WITH CHECK ADD  CONSTRAINT [FK_tblRating_tblMovie_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[tblMovie] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblRating_tblMovie_MovieId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblRating]'))
ALTER TABLE [dbo].[tblRating] CHECK CONSTRAINT [FK_tblRating_tblMovie_MovieId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblRating_tblUser_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblRating]'))
ALTER TABLE [dbo].[tblRating]  WITH CHECK ADD  CONSTRAINT [FK_tblRating_tblUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[tblUser] ([UserId])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_tblRating_tblUser_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[tblRating]'))
ALTER TABLE [dbo].[tblRating] CHECK CONSTRAINT [FK_tblRating_tblUser_UserId]
GO
USE [master]
GO
ALTER DATABASE [dbMovies] SET  READ_WRITE 
GO
