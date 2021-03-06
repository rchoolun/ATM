USE [master]
GO
/****** Object:  Database [ATM]    Script Date: 1/5/2020 5:59:35 PM ******/
CREATE DATABASE [ATM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ATM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ATM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ATM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ATM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ATM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ATM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ATM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ATM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ATM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ATM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ATM] SET ARITHABORT OFF 
GO
ALTER DATABASE [ATM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ATM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ATM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ATM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ATM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ATM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ATM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ATM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ATM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ATM] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ATM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ATM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ATM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ATM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ATM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ATM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ATM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ATM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ATM] SET  MULTI_USER 
GO
ALTER DATABASE [ATM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ATM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ATM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ATM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ATM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ATM] SET QUERY_STORE = OFF
GO
USE [ATM]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 1/5/2020 5:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [nvarchar](50) NOT NULL,
	[CardId] [int] NOT NULL,
	[AccountTypeId] [int] NOT NULL,
	[AmountAvailable] [int] NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccountType]    Script Date: 1/5/2020 5:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_AccountType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Card]    Script Date: 1/5/2020 5:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Card](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CardNumber] [nvarchar](50) NOT NULL,
	[Pin] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Card] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionHistory]    Script Date: 1/5/2020 5:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CardId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[TransactionType] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[TransactionAmount] [int] NULL,
 CONSTRAINT [PK_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/5/2020 5:59:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsLoggedIn] [bit] NOT NULL,
	[LoginAttempt] [int] NULL,
	[Status] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [AccountNumber], [CardId], [AccountTypeId], [AmountAvailable]) VALUES (1, N'12345678', 1, 1, 500)
INSERT [dbo].[Account] ([Id], [AccountNumber], [CardId], [AccountTypeId], [AmountAvailable]) VALUES (2, N'87654321', 2, 1, 16300)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[AccountType] ON 

INSERT [dbo].[AccountType] ([Id], [Name]) VALUES (1, N'Current')
INSERT [dbo].[AccountType] ([Id], [Name]) VALUES (2, N'Saving')
INSERT [dbo].[AccountType] ([Id], [Name]) VALUES (3, N'Shared')
SET IDENTITY_INSERT [dbo].[AccountType] OFF
SET IDENTITY_INSERT [dbo].[Card] ON 

INSERT [dbo].[Card] ([Id], [UserId], [CardNumber], [Pin], [Status]) VALUES (1, 3, N'1234567890', 1234, 3)
INSERT [dbo].[Card] ([Id], [UserId], [CardNumber], [Pin], [Status]) VALUES (2, 4, N'0987654321', 4321, 1)
SET IDENTITY_INSERT [dbo].[Card] OFF
SET IDENTITY_INSERT [dbo].[TransactionHistory] ON 

INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (1, 4, 2, 2, 1, 1, CAST(N'2020-01-05T16:04:20.690' AS DateTime), 100)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (2, 4, 2, 2, 1, 1, CAST(N'2020-01-05T16:05:58.930' AS DateTime), 100)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (3, 4, 2, 2, 1, 1, CAST(N'2020-01-05T16:08:14.020' AS DateTime), 200)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (4, 4, 2, 2, 1, 1, CAST(N'2020-01-05T16:10:04.497' AS DateTime), 1000)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (5, 4, 2, 2, 1, 1, CAST(N'2020-01-05T16:10:22.443' AS DateTime), 1000)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (6, 4, 2, 2, 1, 2, CAST(N'2020-01-05T16:43:11.100' AS DateTime), 340)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (7, 4, 2, 2, 1, 2, CAST(N'2020-01-05T16:53:03.520' AS DateTime), 980)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (8, 4, 2, 2, 1, 2, CAST(N'2020-01-05T16:59:03.003' AS DateTime), 380)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (9, 4, 2, 2, 1, 1, CAST(N'2020-01-05T16:59:50.437' AS DateTime), 200)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (10, 4, 2, 2, 1, 1, CAST(N'2020-01-05T17:44:32.327' AS DateTime), 50)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (11, 4, 2, 2, 1, 1, CAST(N'2020-01-05T17:51:44.317' AS DateTime), 1000)
INSERT [dbo].[TransactionHistory] ([Id], [UserId], [CardId], [AccountId], [TransactionType], [Status], [CreatedOn], [TransactionAmount]) VALUES (12, 4, 2, 2, 1, 1, CAST(N'2020-01-05T17:57:43.390' AS DateTime), 50)
SET IDENTITY_INSERT [dbo].[TransactionHistory] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [IsLoggedIn], [LoginAttempt], [Status], [UserName]) VALUES (3, 0, 3, 0, N'Test')
INSERT [dbo].[User] ([Id], [IsLoggedIn], [LoginAttempt], [Status], [UserName]) VALUES (4, 0, 0, 0, N'Ravish')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([AccountTypeId])
REFERENCES [dbo].[AccountType] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_AccountType]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Card] FOREIGN KEY([CardId])
REFERENCES [dbo].[Card] ([Id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Card]
GO
ALTER TABLE [dbo].[Card]  WITH CHECK ADD  CONSTRAINT [FK_Card_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Card] CHECK CONSTRAINT [FK_Card_User]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_Account]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_Card] FOREIGN KEY([CardId])
REFERENCES [dbo].[Card] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_Card]
GO
ALTER TABLE [dbo].[TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_TransactionHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransactionHistory] CHECK CONSTRAINT [FK_TransactionHistory_User]
GO
USE [master]
GO
ALTER DATABASE [ATM] SET  READ_WRITE 
GO
