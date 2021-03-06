USE [master]
GO
/****** Object:  Database [Bazar]    Script Date: 11/09/2017 16:25:24 ******/
CREATE DATABASE [Bazar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Bazar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Bazar.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Bazar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Bazar_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Bazar] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bazar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bazar] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bazar] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bazar] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bazar] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bazar] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bazar] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bazar] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bazar] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bazar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bazar] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bazar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bazar] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bazar] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bazar] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bazar] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Bazar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bazar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bazar] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bazar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bazar] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bazar] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bazar] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bazar] SET RECOVERY FULL 
GO
ALTER DATABASE [Bazar] SET  MULTI_USER 
GO
ALTER DATABASE [Bazar] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bazar] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bazar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bazar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bazar] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Bazar', N'ON'
GO
ALTER DATABASE [Bazar] SET QUERY_STORE = OFF
GO
USE [Bazar]
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
USE [Bazar]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordine]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordine](
	[IdOrdine] [int] IDENTITY(1,1) NOT NULL,
	[DataOrdine] [datetime2](7) NOT NULL,
	[Stato] [nvarchar](max) NOT NULL,
	[DataSpedizione] [datetime2](7) NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdOrdine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordine_Prodotto]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordine_Prodotto](
	[IdOrdine] [int] NOT NULL,
	[IdProdotto] [int] NOT NULL,
	[Quantita] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProdotto] ASC,
	[IdOrdine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prodotto]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodotto](
	[IdProdotto] [int] IDENTITY(1,1) NOT NULL,
	[NomeProdotto] [nvarchar](max) NOT NULL,
	[DescrizioneProdotto] [nvarchar](max) NOT NULL,
	[Prezzo] [decimal](9, 2) NOT NULL,
	[Sconto] [tinyint] NULL,
	[LinkImmagine] [nvarchar](max) NULL,
	[Disponibile] [bit] NOT NULL,
	[LinkImmagineCarosello] [nvarchar](max) NULL,
	[LinkImmagineCarrello] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProdotto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 11/09/2017 16:25:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Email] [nvarchar](50) NOT NULL,
	[Ruolo] [nvarchar](10) NOT NULL,
	[Psw] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170808134612_Initial', N'1.1.2')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'30af6dbe-d4ca-4876-9e0e-1e74cd83ee36', N'6e1d448d-8d30-47e4-a219-dc99711e8469', N'User', N'USER')
INSERT [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'96319a21-e995-4d63-ad40-89157629741a', N'bfb14dab-d866-4820-89f6-23f74675198a', N'Admin', N'ADMIN')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'85f0d54c-fcce-4016-a7e3-15c4e8996305', N'30af6dbe-d4ca-4876-9e0e-1e74cd83ee36')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e42b124f-9431-4c76-87b1-e50a7c20332a', N'96319a21-e995-4d63-ad40-89157629741a')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'85f0d54c-fcce-4016-a7e3-15c4e8996305', 0, N'df7e858f-82fa-4642-9f90-17dc08d6b106', N'user1@email.com', 0, 1, NULL, N'USER1@EMAIL.COM', N'USER1@EMAIL.COM', N'AQAAAAEAACcQAAAAELm8T3vheM/KtPC9PZoiktCZWP6sY0pYzQY+O3PqSb2bOKXN3k6QWDZEAfkkPElnSQ==', NULL, 0, N'4d8abd7a-6ea1-41e2-8324-10c36a528623', 0, N'user1@email.com')
INSERT [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'e42b124f-9431-4c76-87b1-e50a7c20332a', 0, N'6ca2f491-de8b-464f-aa82-867855637723', N'admin@email.com', 0, 1, NULL, N'ADMIN@EMAIL.COM', N'ADMIN@EMAIL.COM', N'AQAAAAEAACcQAAAAENFHn4MjLwy4YhRlvh/SqregUcWmmPrJEyJMTEu6472cRtrwwFO6EI50JSG5AK8jmg==', NULL, 0, N'd38d2704-2bc4-44e0-9595-5bc3c75b2170', 0, N'admin@email.com')
SET IDENTITY_INSERT [dbo].[Ordine] ON 

INSERT [dbo].[Ordine] ([IdOrdine], [DataOrdine], [Stato], [DataSpedizione], [Email]) VALUES (2049, CAST(N'2017-09-11T16:17:35.0142142' AS DateTime2), N'Spedito', NULL, N'user1@email.com')
SET IDENTITY_INSERT [dbo].[Ordine] OFF
INSERT [dbo].[Ordine_Prodotto] ([IdOrdine], [IdProdotto], [Quantita]) VALUES (2049, 12, 1)
INSERT [dbo].[Ordine_Prodotto] ([IdOrdine], [IdProdotto], [Quantita]) VALUES (2049, 13, 1)
INSERT [dbo].[Ordine_Prodotto] ([IdOrdine], [IdProdotto], [Quantita]) VALUES (2049, 15, 1)
INSERT [dbo].[Ordine_Prodotto] ([IdOrdine], [IdProdotto], [Quantita]) VALUES (2049, 16, 1)
INSERT [dbo].[Ordine_Prodotto] ([IdOrdine], [IdProdotto], [Quantita]) VALUES (2049, 17, 1)
INSERT [dbo].[Ordine_Prodotto] ([IdOrdine], [IdProdotto], [Quantita]) VALUES (2049, 19, 1)
SET IDENTITY_INSERT [dbo].[Prodotto] ON 

INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (12, N'Dragon Quest', N'Quando un’onda oscura si abbatte sulla città di Arba, i mostri che prima convivevano pacificamente con gli abitanti vengono travolti da una furia incontrollabile. 
Scegli tra il protagonista Lucyus o la protagonista Aurora e combatti al fianco di alcuni dei personaggi più amati della serie, come Alena, Bianca e Yangus, per calmare i mostri e riportare la pace nel regno.', CAST(26.12 AS Decimal(9, 2)), 50, N'/img/home_dragon_quest.jpg', 1, N'/img/carosello_dragon_quest.jpg', N'/img/carrello_dragon_quest.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (13, N'World of Final Fantasy', N'Con una grafica adorabile che conquisterà grandi e piccini, il gioco ti permette di raccogliere, allevare e far combattere mostri leggendari incolonnandoli l’uno sull’altro in vere e proprie torri di mostri. Ritrova i mostri più memorabili di FINAL FANTASY in questo mondo fantastico e colorato e vivi una storia epica insieme ai tuoi piccoli amici.', CAST(30.11 AS Decimal(9, 2)), 8, N'/img/home_final_fantasy.jpg', 1, N'/img/carosello_final_fantasy.jpg', N'/img/carrello_final_fantasy.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (14, N'Odin Sphere', N'E'' un RPG d''azione in 2D a scorrimento orizzontale, ricco di mitologia nordica e l’atmosfera di un’opera wagneriana. La nuova versione è un remake completo in HD di quella classica originale per PS2 Odin Sphere di Vanillaware. Il regno di Valentine era il paese più potente del continente di Erion. La sua gente prosperava con il magico potere della Crystallization Cauldron, ma è stato distrutto in una notte fatale.', CAST(30.01 AS Decimal(9, 2)), 25, N'/img/home_odin_sphere.jpg', 0, N'/img/carosello_odin_sphere.jpg', N'/img/carrello_odin_sphere.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (15, N'Valkyria Chronicles', N'Nel mondo alternativo di Valkyria Chronicles è l’anno 1935 e il continente Europeo è coinvolto in una guerra tra l’autocratica Allenza Imperiale dell’Est, conosciuta anche come l’Impero, e la Federazione Atlantica, per il possesso di una preziosa risorsa, la ragnite. L''Impero si sta diffondendo smisuratamente a macchia d’olio attraverso il continente puntando i ricchi giacimenti di ragnite del Principato di Gallia.', CAST(20.98 AS Decimal(9, 2)), NULL, N'/img/home_valkyria.jpg', 1, N'/img/carosello_valkyria.jpg', N'/img/carrello_valkyria.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (16, N'Gravity Rush', N'Gravity Rush Remastered arriva in esclusiva su PlayStation 4 con un gameplay innovativo capace di stravolgere le leggi della fisica. Vesti nuovamente i panni di Kat, manipola la gravità e scopri gli incredibili personaggi che la aiuteranno a fermare la distruzione incombente', CAST(20.99 AS Decimal(9, 2)), NULL, N'/img/home_gravity_rush.jpg', 1, N'/img/carosello_gravity_rush.jpg', N'/img/carrello_gravity_rush.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (17, N'Resident Evil', N'Resident Evil 7 racchiuderà tutti gli elementi di gameplay più caratteristici e distintivi che hanno decretato il successo della serie e che includono l’esplorazione e le atmosfere cupe che hanno segnato, 20 anni fa, la nascita del genere “survival horror”; un sistema totalmente rinnovato porterà l’esperienza di gioco a un livello di profondità mai raggiunto prima. Capace di terrorizzare i fan, in tutti gli eventi.', CAST(30.99 AS Decimal(9, 2)), 30, N'/img/home_resident_evil.jpg', 1, N'/img/carosello_resident_evil.jpg', N'/img/carrello_resident_evil.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (18, N'Vampyr', N'Esplora le strade colpite dalla malattia in Vampyr – un Action /RPG dall’atmosfera cupa – sviluppato utilizzando l’Unreal Engine 4.', CAST(56.99 AS Decimal(9, 2)), 0, N'/img/home_vampyr.jpg', 0, N'/img/carosello_vampyr.jpg', N'/img/carrello_vampyr.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (19, N'Wolfenstein 2', N'Wolfenstein II: The New Colossus è l''attesissimo seguito dell''acclamato sparatutto in soggettiva Wolfenstein: The New Order, sviluppato dal pluripremiato studio MachineGames.jpg', CAST(62.99 AS Decimal(9, 2)), 5, N'/img/home_wolfenstein.jpg', 1, N'/img/carosello_wolfenstein.jpg', N'/img/carrello_wolfenstein.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (20, N'Far Cry 5', N'Far Cry 5 è un videogioco sparatutto in prima persona, sviluppato da Ubisoft Montreal, Ubisoft Reflections, Ubisoft Kiev, Ubisoft Shanghai e Ubisoft Toronto per PlayStation 4, Xbox One e Microsoft Windows.', CAST(65.98 AS Decimal(9, 2)), 1, N'/img/home_far_cry.jpg', 1, N'/img/carosello_far_cry.jpg', N'/img/carrello_far_cry.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (21, N'God of War', N'Fai vibrare la tua PS Vita con God of War Collection e vivi le prime due avventure di Kratos in HD!
Per la prima volta in HD su PS Vita potrai riscoprire il brutale mondo dell’antica Grecia nei panni del leggendario Kratos, vendicarti del Dio Ares e realizzare ciò che nessun mortale ha mai tentato prima: alterare il corso del proprio destino.', CAST(30.99 AS Decimal(9, 2)), 18, N'/img/home_god_of_war.jpg', 0, N'/img/carosello_god_of_war.jpg', N'/img/carrello_god_of_war.jpg')
INSERT [dbo].[Prodotto] ([IdProdotto], [NomeProdotto], [DescrizioneProdotto], [Prezzo], [Sconto], [LinkImmagine], [Disponibile], [LinkImmagineCarosello], [LinkImmagineCarrello]) VALUES (22, N'Uncharted', N'E'' un videogioco di avventura dinamica in terza-persona. I giocatori controllano Chloe Frazer, una cacciatrice di tesori abile e in grado di saltare, arrampicarsi, nuotare ed eseguire azioni acrobatiche. In combattimento, è possibile utilizzare armi da fuoco a lungo raggio, come fucili, e pistole a corto raggio come pistole e revolvers; sono disponibili anche esplosivi come granate e C4.', CAST(35.99 AS Decimal(9, 2)), NULL, N'/img/home_uncharted.jpg', 1, N'/img/carosello_uncharted.jpg', N'/img/carrello_uncharted.jpg')
SET IDENTITY_INSERT [dbo].[Prodotto] OFF
INSERT [dbo].[Utente] ([Email], [Ruolo], [Psw]) VALUES (N'admin@email.com', N'Admin', N'Admin2017.')
INSERT [dbo].[Utente] ([Email], [Ruolo], [Psw]) VALUES (N'user1@email.com', N'User', N'User2017.')
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 11/09/2017 16:25:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/09/2017 16:25:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 11/09/2017 16:25:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 11/09/2017 16:25:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 11/09/2017 16:25:24 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/09/2017 16:25:24 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/09/2017 16:25:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Ordine]  WITH CHECK ADD FOREIGN KEY([Email])
REFERENCES [dbo].[Utente] ([Email])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ordine]  WITH CHECK ADD CHECK  (([Stato]='Spedito' OR [Stato]='Processato'))
GO
ALTER TABLE [dbo].[Utente]  WITH CHECK ADD CHECK  (([Ruolo]='User' OR [Ruolo]='Admin'))
GO
USE [master]
GO
ALTER DATABASE [Bazar] SET  READ_WRITE 
GO
