USE [master]
GO
/****** Object:  Database [Restaurant]    Script Date: 26-May-20 1:29:51 AM ******/
CREATE DATABASE [Restaurant]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Restaurant', FILENAME = N'D:\Microsoft SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\Restaurant.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Restaurant_log', FILENAME = N'D:\Microsoft SQL\MSSQL15.SQLEXPRESS\MSSQL\DATA\Restaurant_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Restaurant] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Restaurant].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Restaurant] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Restaurant] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Restaurant] SET ARITHABORT OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Restaurant] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Restaurant] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Restaurant] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Restaurant] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Restaurant] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Restaurant] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Restaurant] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Restaurant] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Restaurant] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Restaurant] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Restaurant] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Restaurant] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Restaurant] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Restaurant] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Restaurant] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Restaurant] SET  MULTI_USER 
GO
ALTER DATABASE [Restaurant] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Restaurant] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Restaurant] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Restaurant] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Restaurant] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Restaurant] SET QUERY_STORE = OFF
GO
USE [Restaurant]
GO
/****** Object:  Table [dbo].[Alergen]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alergen](
	[id_alergen] [int] IDENTITY(1,1) NOT NULL,
	[nume_alergen] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Alergeni] PRIMARY KEY CLUSTERED 
(
	[id_alergen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[id_categorie] [int] IDENTITY(1,1) NOT NULL,
	[nume_categorie] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[id_categorie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda](
	[id_comanda] [int] IDENTITY(1,1) NOT NULL,
	[stare] [nchar](20) NOT NULL,
	[total_price] [float] NOT NULL,
	[data] [nvarchar](30) NOT NULL,
	[timp_livrare] [nvarchar](20) NOT NULL,
	[utilizator_id] [int] NOT NULL,
 CONSTRAINT [PK_Comanda] PRIMARY KEY CLUSTERED 
(
	[id_comanda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda_Meniu_Aux]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda_Meniu_Aux](
	[id_comanda_meniu] [int] IDENTITY(1,1) NOT NULL,
	[comanda_id] [int] NOT NULL,
	[meniu_id] [int] NOT NULL,
 CONSTRAINT [PK_Comanda_Meniu_Aux] PRIMARY KEY CLUSTERED 
(
	[id_comanda_meniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comanda_Preparat_Aux]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comanda_Preparat_Aux](
	[id_comanda_preparat] [int] IDENTITY(1,1) NOT NULL,
	[comanda_id] [int] NOT NULL,
	[preparat_id] [int] NOT NULL,
 CONSTRAINT [PK_Comanda_Preparat_Aux] PRIMARY KEY CLUSTERED 
(
	[id_comanda_preparat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meniu]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meniu](
	[id_meniu] [int] IDENTITY(1,1) NOT NULL,
	[nume_meniu] [nvarchar](30) NOT NULL,
	[pret] [float] NOT NULL,
	[categorie_id] [int] NOT NULL,
	[photo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Meniu] PRIMARY KEY CLUSTERED 
(
	[id_meniu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meniu_Preparat_Aux]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meniu_Preparat_Aux](
	[id_meniu_preparat] [int] IDENTITY(1,1) NOT NULL,
	[meniu_id] [int] NOT NULL,
	[preparat_id] [int] NOT NULL,
 CONSTRAINT [PK_Meniu_Preparat_Aux] PRIMARY KEY CLUSTERED 
(
	[id_meniu_preparat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preparat]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preparat](
	[id_preparat] [int] IDENTITY(1,1) NOT NULL,
	[nume_preparat] [nvarchar](30) NOT NULL,
	[pret] [float] NOT NULL,
	[cantitate_meniu] [float] NOT NULL,
	[cantitate_totala] [float] NOT NULL,
	[fotografie] [nvarchar](100) NULL,
	[categorie_id] [int] NOT NULL,
 CONSTRAINT [PK_Preparat] PRIMARY KEY CLUSTERED 
(
	[id_preparat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preparat_Alergen_Aux]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preparat_Alergen_Aux](
	[id_preparat_alergen] [int] IDENTITY(1,1) NOT NULL,
	[preparat_id] [int] NOT NULL,
	[alergen_id] [int] NOT NULL,
 CONSTRAINT [PK_Preparat_Alergan_Aux] PRIMARY KEY CLUSTERED 
(
	[id_preparat_alergen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizator]    Script Date: 26-May-20 1:29:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizator](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[nume_user] [nchar](30) NOT NULL,
	[prenume_user] [nchar](30) NOT NULL,
	[email] [nvarchar](30) NOT NULL,
	[telefon] [nvarchar](10) NOT NULL,
	[adresa_livrare] [nvarchar](200) NOT NULL,
	[parola] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alergen] ON 

INSERT [dbo].[Alergen] ([id_alergen], [nume_alergen]) VALUES (6, N'Lactoza             ')
INSERT [dbo].[Alergen] ([id_alergen], [nume_alergen]) VALUES (7, N'Oua                 ')
INSERT [dbo].[Alergen] ([id_alergen], [nume_alergen]) VALUES (8, N'Cereale             ')
INSERT [dbo].[Alergen] ([id_alergen], [nume_alergen]) VALUES (9, N'Mustar              ')
INSERT [dbo].[Alergen] ([id_alergen], [nume_alergen]) VALUES (10, N'Susan               ')
SET IDENTITY_INSERT [dbo].[Alergen] OFF
GO
SET IDENTITY_INSERT [dbo].[Categorie] ON 

INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (7, N'Breakfast                     ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (8, N'Brunch                        ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (9, N'Cafea                         ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (10, N'Supa                          ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (11, N'Desert                        ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (12, N'Soft drink                    ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (13, N'Alcool                        ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (14, N'Snack                         ')
INSERT [dbo].[Categorie] ([id_categorie], [nume_categorie]) VALUES (15, N'Cina                          ')
SET IDENTITY_INSERT [dbo].[Categorie] OFF
GO
SET IDENTITY_INSERT [dbo].[Comanda] ON 

INSERT [dbo].[Comanda] ([id_comanda], [stare], [total_price], [data], [timp_livrare], [utilizator_id]) VALUES (37, N'inregistrata        ', 47, N'25.05.2020', N'00:42', 4)
INSERT [dbo].[Comanda] ([id_comanda], [stare], [total_price], [data], [timp_livrare], [utilizator_id]) VALUES (38, N'livrata             ', 89, N'25.05.2020', N'00:43', 4)
INSERT [dbo].[Comanda] ([id_comanda], [stare], [total_price], [data], [timp_livrare], [utilizator_id]) VALUES (39, N'inregistrata        ', 70, N'25.05.2020', N'00:45', 4)
INSERT [dbo].[Comanda] ([id_comanda], [stare], [total_price], [data], [timp_livrare], [utilizator_id]) VALUES (40, N'inregistrata        ', 65, N'25.05.2020', N'00:46', 6)
INSERT [dbo].[Comanda] ([id_comanda], [stare], [total_price], [data], [timp_livrare], [utilizator_id]) VALUES (41, N'inregistrata        ', 55, N'25.05.2020', N'00:46', 6)
SET IDENTITY_INSERT [dbo].[Comanda] OFF
GO
SET IDENTITY_INSERT [dbo].[Comanda_Meniu_Aux] ON 

INSERT [dbo].[Comanda_Meniu_Aux] ([id_comanda_meniu], [comanda_id], [meniu_id]) VALUES (11, 39, 9)
SET IDENTITY_INSERT [dbo].[Comanda_Meniu_Aux] OFF
GO
SET IDENTITY_INSERT [dbo].[Comanda_Preparat_Aux] ON 

INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (31, 37, 13)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (32, 37, 13)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (33, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (34, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (35, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (36, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (37, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (38, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (39, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (40, 38, 14)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (41, 39, 18)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (42, 40, 13)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (43, 40, 15)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (44, 40, 18)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (45, 40, 23)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (46, 41, 13)
INSERT [dbo].[Comanda_Preparat_Aux] ([id_comanda_preparat], [comanda_id], [preparat_id]) VALUES (47, 41, 17)
SET IDENTITY_INSERT [dbo].[Comanda_Preparat_Aux] OFF
GO
SET IDENTITY_INSERT [dbo].[Meniu] ON 

INSERT [dbo].[Meniu] ([id_meniu], [nume_meniu], [pret], [categorie_id], [photo]) VALUES (9, N'Friptura cu cartofi', 45, 15, N'13654235-grilled-steak-with-french-fries.jpg')
INSERT [dbo].[Meniu] ([id_meniu], [nume_meniu], [pret], [categorie_id], [photo]) VALUES (10, N'Parfait si smoothie fructe', 32.3999999165535, 7, N'Triple-Berry-Crisp-Smoothie-Parfait-ig.jpg')
INSERT [dbo].[Meniu] ([id_meniu], [nume_meniu], [pret], [categorie_id], [photo]) VALUES (11, N'Snack Pack', 22.5, 14, N'snackpack.jpg')
INSERT [dbo].[Meniu] ([id_meniu], [nume_meniu], [pret], [categorie_id], [photo]) VALUES (12, N'Meniu 3 feluri', 65.700000047683716, 15, N'download (3).jpg')
SET IDENTITY_INSERT [dbo].[Meniu] OFF
GO
SET IDENTITY_INSERT [dbo].[Meniu_Preparat_Aux] ON 

INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (13, 9, 23)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (14, 9, 24)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (15, 10, 14)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (16, 10, 25)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (17, 11, 23)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (18, 11, 20)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (19, 12, 13)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (20, 12, 24)
INSERT [dbo].[Meniu_Preparat_Aux] ([id_meniu_preparat], [meniu_id], [preparat_id]) VALUES (21, 12, 17)
SET IDENTITY_INSERT [dbo].[Meniu_Preparat_Aux] OFF
GO
SET IDENTITY_INSERT [dbo].[Preparat] ON 

INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (13, N'Omleta', 15, 200, 5000, N'Scrambled-Eggs-Recipe-2-1200.jpg', 7)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (14, N'Parfait fructe', 9, 250, 0, N'Rainbow-Fruit-Parfait-10.jpg', 7)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (15, N'Cold brew', 10, 150, 2000, N'2016-07-5-HT-Cold-Brew-29.jpg', 9)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (16, N'Latte', 12, 350, 5000, N'res_4d9294a96299f9184ad397b499844b57_full.jpg', 9)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (17, N'Supa ciuperci', 23, 400, 10000, N'1506455983-delish-cream-mushroom-soup.jpg', 10)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (18, N'Coca Cola', 8, 330, 10000, N'dbe24953448273.593557543c6cd.jpg', 12)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (19, N'Gin tonic', 20, 400, 3000, N'b_vintage-gin-tonic-nude-glass-359581-rel467797d2.jpg', 13)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (20, N'Alune picante', 10, 200, 5000, N'sweet-spicy-peanuts-feature-480x270.jpg', 14)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (21, N'Sprite', 7, 330, 5000, N'sprite-sleek-330ml_9137.jpg', 12)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (22, N'Whisky', 13, 50, 1000, N'download (1).jpg', 13)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (23, N'French fries', 15, 500, 5000, N'download.jpg', 14)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (24, N'Friptura vita', 35, 420, 10000, N'picfWIjXl.jpg', 15)
INSERT [dbo].[Preparat] ([id_preparat], [nume_preparat], [pret], [cantitate_meniu], [cantitate_totala], [fotografie], [categorie_id]) VALUES (25, N'Smoothie mango', 27, 350, 1500, N'download (2).jpg', 12)
SET IDENTITY_INSERT [dbo].[Preparat] OFF
GO
SET IDENTITY_INSERT [dbo].[Preparat_Alergen_Aux] ON 

INSERT [dbo].[Preparat_Alergen_Aux] ([id_preparat_alergen], [preparat_id], [alergen_id]) VALUES (14, 13, 7)
INSERT [dbo].[Preparat_Alergen_Aux] ([id_preparat_alergen], [preparat_id], [alergen_id]) VALUES (15, 14, 6)
INSERT [dbo].[Preparat_Alergen_Aux] ([id_preparat_alergen], [preparat_id], [alergen_id]) VALUES (16, 16, 6)
INSERT [dbo].[Preparat_Alergen_Aux] ([id_preparat_alergen], [preparat_id], [alergen_id]) VALUES (17, 23, 9)
INSERT [dbo].[Preparat_Alergen_Aux] ([id_preparat_alergen], [preparat_id], [alergen_id]) VALUES (18, 24, 9)
INSERT [dbo].[Preparat_Alergen_Aux] ([id_preparat_alergen], [preparat_id], [alergen_id]) VALUES (19, 14, 8)
SET IDENTITY_INSERT [dbo].[Preparat_Alergen_Aux] OFF
GO
SET IDENTITY_INSERT [dbo].[Utilizator] ON 

INSERT [dbo].[Utilizator] ([id_user], [nume_user], [prenume_user], [email], [telefon], [adresa_livrare], [parola]) VALUES (4, N'Ionascu                       ', N'Mihai                         ', N'ionascumihaig@gmail.com', N'0734880767', N'Ion Berindei nr. 9 bl. 20', N'caine')
INSERT [dbo].[Utilizator] ([id_user], [nume_user], [prenume_user], [email], [telefon], [adresa_livrare], [parola]) VALUES (5, N'Ovidiu                        ', N'Andrei                        ', N'oviandrei@restaurant.com', N'0756434754', N'Str. Memorandului nr. 23 bl. 15', N'caine')
INSERT [dbo].[Utilizator] ([id_user], [nume_user], [prenume_user], [email], [telefon], [adresa_livrare], [parola]) VALUES (6, N'Carmen                        ', N'Alia                          ', N'caralia@yahoo.com', N'0732300653', N'Str. Carpati nr. 56 bl. 23', N'pisica')
SET IDENTITY_INSERT [dbo].[Utilizator] OFF
GO
ALTER TABLE [dbo].[Comanda]  WITH NOCHECK ADD  CONSTRAINT [FK_Utilizator_Comanda] FOREIGN KEY([utilizator_id])
REFERENCES [dbo].[Utilizator] ([id_user])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comanda] CHECK CONSTRAINT [FK_Utilizator_Comanda]
GO
ALTER TABLE [dbo].[Comanda_Meniu_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Comanda_Meniu] FOREIGN KEY([comanda_id])
REFERENCES [dbo].[Comanda] ([id_comanda])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comanda_Meniu_Aux] CHECK CONSTRAINT [FK_Comanda_Meniu]
GO
ALTER TABLE [dbo].[Comanda_Meniu_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Comanda_Meniu_2] FOREIGN KEY([meniu_id])
REFERENCES [dbo].[Meniu] ([id_meniu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comanda_Meniu_Aux] CHECK CONSTRAINT [FK_Comanda_Meniu_2]
GO
ALTER TABLE [dbo].[Comanda_Preparat_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Comanda_Preparat_1] FOREIGN KEY([comanda_id])
REFERENCES [dbo].[Comanda] ([id_comanda])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comanda_Preparat_Aux] CHECK CONSTRAINT [FK_Comanda_Preparat_1]
GO
ALTER TABLE [dbo].[Comanda_Preparat_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Comanda_Preparat_2] FOREIGN KEY([preparat_id])
REFERENCES [dbo].[Preparat] ([id_preparat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comanda_Preparat_Aux] CHECK CONSTRAINT [FK_Comanda_Preparat_2]
GO
ALTER TABLE [dbo].[Meniu]  WITH NOCHECK ADD  CONSTRAINT [FK_Categorie_Meniu] FOREIGN KEY([categorie_id])
REFERENCES [dbo].[Categorie] ([id_categorie])
GO
ALTER TABLE [dbo].[Meniu] CHECK CONSTRAINT [FK_Categorie_Meniu]
GO
ALTER TABLE [dbo].[Meniu_Preparat_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Meniu_Meniu_Preparat_Aux] FOREIGN KEY([meniu_id])
REFERENCES [dbo].[Meniu] ([id_meniu])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meniu_Preparat_Aux] CHECK CONSTRAINT [FK_Meniu_Meniu_Preparat_Aux]
GO
ALTER TABLE [dbo].[Meniu_Preparat_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Preparat_Meniu_Preparat_Aux] FOREIGN KEY([preparat_id])
REFERENCES [dbo].[Preparat] ([id_preparat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Meniu_Preparat_Aux] CHECK CONSTRAINT [FK_Preparat_Meniu_Preparat_Aux]
GO
ALTER TABLE [dbo].[Preparat]  WITH NOCHECK ADD  CONSTRAINT [FK_Preparat_Categorie] FOREIGN KEY([categorie_id])
REFERENCES [dbo].[Categorie] ([id_categorie])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Preparat] CHECK CONSTRAINT [FK_Preparat_Categorie]
GO
ALTER TABLE [dbo].[Preparat_Alergen_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Alergen_Preparat-Alergen-Aux] FOREIGN KEY([alergen_id])
REFERENCES [dbo].[Alergen] ([id_alergen])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Preparat_Alergen_Aux] CHECK CONSTRAINT [FK_Alergen_Preparat-Alergen-Aux]
GO
ALTER TABLE [dbo].[Preparat_Alergen_Aux]  WITH NOCHECK ADD  CONSTRAINT [FK_Preparat_Preparat-Alergen-Aux] FOREIGN KEY([preparat_id])
REFERENCES [dbo].[Preparat] ([id_preparat])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Preparat_Alergen_Aux] CHECK CONSTRAINT [FK_Preparat_Preparat-Alergen-Aux]
GO
/****** Object:  StoredProcedure [dbo].[AddAllergen]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddAllergen]
@Allergen nchar(20)
AS
INSERT INTO Alergen
VALUES (@Allergen);
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddCategory]
@Category nchar(30)
AS
INSERT INTO Categorie
VALUES (@Category);
GO
/****** Object:  StoredProcedure [dbo].[AddMenuComponent]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[AddMenuComponent]
@menu_id int,
@preparat_id int,
@discount_value float
AS
insert into Meniu_Preparat_Aux values(@menu_id, @preparat_id);
update Meniu
set Meniu.pret += Preparat.pret - @discount_value
from Meniu, Preparat
where Meniu.id_meniu = @menu_id AND Preparat.id_preparat = @preparat_id

GO
/****** Object:  StoredProcedure [dbo].[AddMenuItem]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddMenuItem]
@Name nvarchar(30),
@Price float,
@Category int,
@Photo nvarchar(100)
AS
INSERT INTO Meniu
VALUES (@Name, @Price, @Category, @Photo);
GO
/****** Object:  StoredProcedure [dbo].[AddPreparat]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddPreparat]
@Name nvarchar(30),
@Price float,
@Menu_quantity float,
@Total_quantity float,
@Photo nvarchar(100),
@Category int
AS
INSERT INTO Preparat
VALUES (@Name, @Price, @Menu_quantity, @Total_quantity, @Photo, @Category);
GO
/****** Object:  StoredProcedure [dbo].[AddPreparatAllergen]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddPreparatAllergen]
@Preparat_id int,
@Alergen_id int
AS
insert into Preparat_Alergen_Aux values (@Preparat_id, @Alergen_id)
GO
/****** Object:  StoredProcedure [dbo].[AddToComandaMeniuAux]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddToComandaMeniuAux]
@id_comanda int,
@id_meniu int
as
insert into Comanda_Meniu_Aux
values (@id_comanda, @id_meniu)
GO
/****** Object:  StoredProcedure [dbo].[AddToComandaPreparatAux]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AddToComandaPreparatAux]
@id_comanda int,
@id_preparat int
as
insert into Comanda_Preparat_Aux
values (@id_comanda, @id_preparat)
GO
/****** Object:  StoredProcedure [dbo].[CancelOrder]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[CancelOrder]
@order_id int
as
update Comanda
set stare = 'anulata'
where id_comanda = @order_id
GO
/****** Object:  StoredProcedure [dbo].[CheckEmailAndPassword]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CheckEmailAndPassword]
@Email nvarchar(30),
@Password nvarchar(30)
AS
SELECT email, id_user from Utilizator where (email = @Email AND parola = @Password)
GO
/****** Object:  StoredProcedure [dbo].[DeleteMeniu]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeleteMeniu]
@meniu_index int
as
delete from Meniu
where id_meniu = @meniu_index
GO
/****** Object:  StoredProcedure [dbo].[DeletePreparat]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DeletePreparat]
@preparat_index int
as
delete from Preparat
where id_preparat = @preparat_index
GO
/****** Object:  StoredProcedure [dbo].[FindMenuByName]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FindMenuByName]
@SearchText varchar(20)
as
select id_meniu, nume_meniu, pret, photo
from Meniu
where nume_meniu like '%'+@SearchText+'%'
order by categorie_id
GO
/****** Object:  StoredProcedure [dbo].[FindPreparatByName]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FindPreparatByName]
@SearchText varchar(20)
as
select id_preparat, nume_preparat, pret, cantitate_meniu, cantitate_totala, fotografie
from Preparat
where nume_preparat like '%'+@SearchText+'%'
order by categorie_id
GO
/****** Object:  StoredProcedure [dbo].[FindPreparateForGivenOrderIndex]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FindPreparateForGivenOrderIndex]
@order_index int
as
select id_preparat, cantitate_meniu
from Preparat
inner join Comanda_Preparat_Aux on Preparat.id_preparat = Comanda_Preparat_Aux.preparat_id
where comanda_id=@order_index
GO
/****** Object:  StoredProcedure [dbo].[FindPreparateIdForMenuIndex]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FindPreparateIdForMenuIndex]
@menu_index int
as
select preparat_id
from Meniu_Preparat_Aux
where Meniu_Preparat_Aux.meniu_id = @menu_index
GO
/****** Object:  StoredProcedure [dbo].[GetAllergensForPreparat]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllergensForPreparat]
@preparat_index int
as
select nume_alergen
from Preparat_Alergen_Aux
inner join Alergen on alergen_id = id_alergen
where preparat_id = @preparat_index
GO
/****** Object:  StoredProcedure [dbo].[GetAllergenStrings]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetAllergenStrings]
AS
select Alergen.nume_alergen from Alergen
GO
/****** Object:  StoredProcedure [dbo].[GetAllergenStrings2]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetAllergenStrings2]
as
select Alergen.id_alergen, Alergen.nume_alergen from Alergen
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryStrings]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCategoryStrings]
AS
select id_categorie, nume_categorie from Categorie
GO
/****** Object:  StoredProcedure [dbo].[GetFiecareAlergenDinFiecarePreparatAlUnuiMeniu]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetFiecareAlergenDinFiecarePreparatAlUnuiMeniu]
@meniu_index int
as
select distinct nume_alergen
from Preparat_Alergen_Aux
inner join Alergen on alergen_id = id_alergen
inner join Meniu_Preparat_Aux on Preparat_Alergen_Aux.preparat_id = Meniu_Preparat_Aux.preparat_id
where meniu_id = @meniu_index
GO
/****** Object:  StoredProcedure [dbo].[GetFoodNamesForUserWithOrderId]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetFoodNamesForUserWithOrderId]
@user_id int,
@order_id int
as
select
nume_preparat
from Comanda_Preparat_Aux
inner join Preparat on Comanda_Preparat_Aux.preparat_id = Preparat.id_preparat
inner join Comanda on Comanda_Preparat_Aux.comanda_id = Comanda.id_comanda
where Comanda.utilizator_id = @user_id and comanda_id=@order_id
GO
/****** Object:  StoredProcedure [dbo].[GetFoodNamesForUserWithOrderId2]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetFoodNamesForUserWithOrderId2]
@user_id int,
@order_id int
as
select
nume_meniu
from Comanda_Meniu_Aux
inner join Meniu on Comanda_Meniu_Aux.meniu_id = Meniu.id_meniu
inner join Comanda on Comanda_Meniu_Aux.comanda_id = Comanda.id_comanda
where Comanda.utilizator_id = @user_id and comanda_id=@order_id
GO
/****** Object:  StoredProcedure [dbo].[GetLastOrderId]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetLastOrderId]
as
select top 1 id_comanda
from Comanda
order by id_comanda DESC
GO
/****** Object:  StoredProcedure [dbo].[GetLowStockFood]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetLowStockFood]
@weight_threshold int
as
select id_preparat, nume_preparat, pret, cantitate_meniu, cantitate_totala, fotografie
from Preparat
where cantitate_totala <= @weight_threshold
order by categorie_id
GO
/****** Object:  StoredProcedure [dbo].[GetMenuItemStrings]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetMenuItemStrings]
AS
select nume_meniu from Meniu
GO
/****** Object:  StoredProcedure [dbo].[GetMenuPreparatComponentsWeightAndId]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetMenuPreparatComponentsWeightAndId]
@order_index int
as
select id_preparat, cantitate_meniu
from Meniu
inner join Comanda_Meniu_Aux on Comanda_Meniu_Aux.meniu_id = Meniu.id_meniu
inner join Meniu_Preparat_Aux on Meniu.id_meniu = Meniu_Preparat_Aux.meniu_id
inner join Preparat on Preparat.id_preparat = Meniu_Preparat_Aux.preparat_id
where comanda_id=@order_index
GO
/****** Object:  StoredProcedure [dbo].[GetMenuQuantities]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetMenuQuantities]
@menu_index int
as
select cantitate_meniu
from Preparat
inner join Meniu_Preparat_Aux 
on Preparat.id_preparat = Meniu_Preparat_Aux.preparat_id
where meniu_id = @menu_index
GO
/****** Object:  StoredProcedure [dbo].[GetMenus]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetMenus]
as
select id_meniu, nume_meniu, pret, photo, categorie_id
from Meniu
GO
/****** Object:  StoredProcedure [dbo].[GetNumberOfOrders]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetNumberOfOrders]
@user_index int,
@time_inf nvarchar(20),
@time_sup nvarchar(20),
@today_date nvarchar(30)
as
select count(id_comanda)
from Comanda
where utilizator_id = @user_index AND
timp_livrare >= @time_inf AND
timp_livrare <= @time_sup AND
data = @today_date
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDetailsForGivenOrderId]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetOrderDetailsForGivenOrderId]
@order_id int
as
select 
total_price, stare, data, timp_livrare 
from Comanda
where id_comanda = @order_id
GO
/****** Object:  StoredProcedure [dbo].[GetOrderIdsForCustomer]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetOrderIdsForCustomer]
@user_id int
as
select id_comanda
from Comanda
where utilizator_id = @user_id
GO
/****** Object:  StoredProcedure [dbo].[GetOrdersUnsorted]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetOrdersUnsorted]
as
select id_comanda, nume_user, prenume_user, stare, total_price, data, timp_livrare,
telefon, adresa_livrare
from Comanda
inner join Utilizator on Comanda.utilizator_id = Utilizator.id_user
GO
/****** Object:  StoredProcedure [dbo].[GetPreparate]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetPreparate]
as
select id_preparat, nume_preparat, pret, cantitate_meniu, cantitate_totala, fotografie
from Preparat
order by categorie_id
GO
/****** Object:  StoredProcedure [dbo].[GetPreparateStrings]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetPreparateStrings]
as
select nume_preparat from Preparat
GO
/****** Object:  StoredProcedure [dbo].[RegisterOrder]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[RegisterOrder]
@total_price float,
@current_date nvarchar(30),
@delivery_time nvarchar(20),
@user_id int
as
insert into Comanda
values ('inregistrata', @total_price, @current_date, @delivery_time, @user_id)
GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[RegisterUser]
@Name nchar(30),
@Surname nchar(30),
@Email nvarchar(30),
@Phone nvarchar(10),
@Address nvarchar(200),
@Password nvarchar(30)
AS
INSERT INTO Utilizator
VALUES (@Name, @Surname, @Email, @Phone, @Address, @Password);
GO
/****** Object:  StoredProcedure [dbo].[SortActivesByDate]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SortActivesByDate]
as
select id_comanda, nume_user, prenume_user, stare, total_price, data, timp_livrare,
telefon, adresa_livrare
from Comanda
inner join Utilizator on Comanda.utilizator_id = Utilizator.id_user
where stare != 'livrata' AND stare != 'anulata'
order by data DESC
GO
/****** Object:  StoredProcedure [dbo].[SortActivesByETA]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SortActivesByETA]
as
select id_comanda, nume_user, prenume_user, stare, total_price, data, timp_livrare,
telefon, adresa_livrare
from Comanda
inner join Utilizator on Comanda.utilizator_id = Utilizator.id_user
where stare != 'livrata' AND stare != 'anulata'
order by timp_livrare DESC
GO
/****** Object:  StoredProcedure [dbo].[SortByDate]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SortByDate]
as
select id_comanda, nume_user, prenume_user, stare, total_price, data, timp_livrare,
telefon, adresa_livrare
from Comanda
inner join Utilizator on Comanda.utilizator_id = Utilizator.id_user
order by data DESC
GO
/****** Object:  StoredProcedure [dbo].[SortByETA]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SortByETA]
as
select id_comanda, nume_user, prenume_user, stare, total_price, data, timp_livrare,
telefon, adresa_livrare
from Comanda
inner join Utilizator on Comanda.utilizator_id = Utilizator.id_user
order by timp_livrare DESC
GO
/****** Object:  StoredProcedure [dbo].[UpdateMeniu]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateMeniu]
@Name nvarchar(30),
@Old_name nvarchar(30)
as
update Meniu
set nume_meniu = @Name
where nume_meniu = @Old_name
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrderState]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateOrderState]
@new_state nchar(20),
@order_index int
as
update Comanda
set stare = @new_state
where id_comanda = @order_index
GO
/****** Object:  StoredProcedure [dbo].[UpdatePreparat]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdatePreparat]
@Name nvarchar(30),
@Price float,
@Menu_quantity float,
@Total_quantity float,
@Old_name nvarchar(30)
as
update Preparat
set nume_preparat = @Name, pret=@Price, cantitate_meniu=@Menu_quantity, cantitate_totala=@Total_quantity
where nume_preparat = @Old_name
GO
/****** Object:  StoredProcedure [dbo].[UpdateRestaurantWeight]    Script Date: 26-May-20 1:29:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateRestaurantWeight]
@current_weight float,
@preparat_index int
as
update Preparat
set cantitate_totala -= @current_weight
where id_preparat = @preparat_index
GO
USE [master]
GO
ALTER DATABASE [Restaurant] SET  READ_WRITE 
GO
