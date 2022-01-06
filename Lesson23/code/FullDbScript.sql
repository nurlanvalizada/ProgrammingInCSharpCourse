USE [master]
GO

CREATE DATABASE [StudentsDb]
GO
USE [StudentsDb]
GO


/****** Object:  Table [dbo].[tblCourse]    Script Date: 2022-01-06 17:50:57 ******/
CREATE TABLE [dbo].[tblCourse] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreationTime] [datetime] NULL,
 CONSTRAINT [PK_tblCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO


/****** Object:  Table [dbo].[tblStudent]    Script Date: 2022-01-06 17:50:57 ******/
CREATE TABLE [dbo].[tblStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Surname] [nvarchar](20) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Salary] [float] NULL,
 CONSTRAINT [PK_tblStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO


/****** Object:  Table [dbo].[tblStudentCourse]    Script Date: 2022-01-06 17:50:57 ******/
CREATE TABLE [dbo].[tblStudentCourse](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_tblStudentCourse] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
))
GO


SET IDENTITY_INSERT [dbo].[tblCourse] ON 
GO
INSERT [dbo].[tblCourse] ([Id], [Name], [CreationTime]) VALUES (1, N'Fizika', CAST(N'2022-01-05T21:36:10.347' AS DateTime))
GO
INSERT [dbo].[tblCourse] ([Id], [Name], [CreationTime]) VALUES (2, N'Riyaziyyat', CAST(N'2022-01-05T21:36:18.457' AS DateTime))
GO
INSERT [dbo].[tblCourse] ([Id], [Name], [CreationTime]) VALUES (3, N'Kimya', CAST(N'2022-01-05T21:36:25.010' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tblCourse] OFF
GO


SET IDENTITY_INSERT [dbo].[tblStudent] ON 
GO
INSERT [dbo].[tblStudent] ([Id], [Name], [Surname], [DateOfBirth], [Salary]) VALUES (1, N'Nurlan', N'Valizada', CAST(N'1993-06-06' AS Date), 200)
GO
INSERT [dbo].[tblStudent] ([Id], [Name], [Surname], [DateOfBirth], [Salary]) VALUES (3, N'Kamran', N'Shikhalizada', CAST(N'1994-09-14' AS Date), 300)
GO
INSERT [dbo].[tblStudent] ([Id], [Name], [Surname], [DateOfBirth], [Salary]) VALUES (4, N'Kamran2', N'Shikhalizada1', CAST(N'1994-09-14' AS Date), 300)
GO
INSERT [dbo].[tblStudent] ([Id], [Name], [Surname], [DateOfBirth], [Salary]) VALUES (5, N'Samir', N'Ehmedov', CAST(N'1994-09-14' AS Date), 300)
GO
INSERT [dbo].[tblStudent] ([Id], [Name], [Surname], [DateOfBirth], [Salary]) VALUES (6, N'Samir2', N'Ehmedov2', CAST(N'1994-09-15' AS Date), 300)
GO
INSERT [dbo].[tblStudent] ([Id], [Name], [Surname], [DateOfBirth], [Salary]) VALUES (7, N'Samir3', N'Ehmedov3', CAST(N'1996-09-15' AS Date), 300)
GO
SET IDENTITY_INSERT [dbo].[tblStudent] OFF
GO


INSERT [dbo].[tblStudentCourse] ([StudentId], [CourseId], [StartDate], [EndDate]) VALUES (1, 2, CAST(N'2022-01-05T21:39:17.793' AS DateTime), NULL)
GO