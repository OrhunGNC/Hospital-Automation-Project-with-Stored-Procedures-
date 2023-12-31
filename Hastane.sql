USE [master]
GO
/****** Object:  Database [Hastane]    Script Date: 13.08.2023 11:07:59 ******/
CREATE DATABASE [Hastane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Hastane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Hastane.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Hastane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Hastane_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Hastane] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Hastane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Hastane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Hastane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Hastane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Hastane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Hastane] SET ARITHABORT OFF 
GO
ALTER DATABASE [Hastane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Hastane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Hastane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Hastane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Hastane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Hastane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Hastane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Hastane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Hastane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Hastane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Hastane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Hastane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Hastane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Hastane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Hastane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Hastane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Hastane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Hastane] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Hastane] SET  MULTI_USER 
GO
ALTER DATABASE [Hastane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Hastane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Hastane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Hastane] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Hastane] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Hastane] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Hastane] SET QUERY_STORE = ON
GO
ALTER DATABASE [Hastane] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Hastane]
GO
/****** Object:  Table [dbo].[Arayüz]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arayüz](
	[arayuzNo] [int] IDENTITY(1,1) NOT NULL,
	[hastaNo] [int] NULL,
	[poliklinikNo] [int] NULL,
 CONSTRAINT [PK_Arayüz] PRIMARY KEY CLUSTERED 
(
	[arayuzNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doktorlar]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doktorlar](
	[doktorNo] [int] IDENTITY(1,1) NOT NULL,
	[doktorAdSoyad] [varchar](50) NULL,
	[doktorBolum] [varchar](50) NULL,
	[doktorUnvan] [varchar](50) NULL,
	[poliklinikNo] [int] NULL,
 CONSTRAINT [PK_Doktorlar] PRIMARY KEY CLUSTERED 
(
	[doktorNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hastalar]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastalar](
	[hastaNo] [int] IDENTITY(1,1) NOT NULL,
	[hastaAdSoyad] [varchar](50) NULL,
	[hastaYas] [int] NULL,
	[hastaBoy] [int] NULL,
	[hastaKilo] [int] NULL,
 CONSTRAINT [PK_Hastalar] PRIMARY KEY CLUSTERED 
(
	[hastaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poliklinik]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poliklinik](
	[poliklinikNo] [int] IDENTITY(1,1) NOT NULL,
	[poliklinikBolum] [varchar](50) NULL,
	[poliklinikCalisanSayisi] [int] NULL,
	[poliklinikSorumlusu] [varchar](50) NULL,
 CONSTRAINT [PK_Poliklinik] PRIMARY KEY CLUSTERED 
(
	[poliklinikNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receteler]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receteler](
	[receteNo] [int] IDENTITY(1,1) NOT NULL,
	[receteTarih] [datetime] NULL,
	[receteTanimi] [varchar](50) NULL,
	[hastaNo] [int] NULL,
	[doktorNo] [int] NULL,
 CONSTRAINT [PK_Receteler] PRIMARY KEY CLUSTERED 
(
	[receteNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sekreter]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sekreter](
	[sekreterNo] [int] IDENTITY(1,1) NOT NULL,
	[sekreterKAdi] [varchar](50) NULL,
	[sekreterSifre] [varchar](50) NULL,
	[sekreterAdSoyad] [varchar](50) NULL,
 CONSTRAINT [PK_Sekreter] PRIMARY KEY CLUSTERED 
(
	[sekreterNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yonetici]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yonetici](
	[yoneticiNo] [int] IDENTITY(1,1) NOT NULL,
	[yoneticiAdSoyad] [varchar](50) NULL,
	[yoneticiKAdi] [varchar](50) NULL,
	[yoneticiSifre] [varchar](50) NULL,
 CONSTRAINT [PK_Yonetici] PRIMARY KEY CLUSTERED 
(
	[yoneticiNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doktorlar] ON 

INSERT [dbo].[Doktorlar] ([doktorNo], [doktorAdSoyad], [doktorBolum], [doktorUnvan], [poliklinikNo]) VALUES (2, N'Orhun Gença', N'Beyin Cerrahi', N'Profesör', 1)
SET IDENTITY_INSERT [dbo].[Doktorlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Hastalar] ON 

INSERT [dbo].[Hastalar] ([hastaNo], [hastaAdSoyad], [hastaYas], [hastaBoy], [hastaKilo]) VALUES (2, N'orhun gença', 22, 178, 83)
SET IDENTITY_INSERT [dbo].[Hastalar] OFF
GO
SET IDENTITY_INSERT [dbo].[Poliklinik] ON 

INSERT [dbo].[Poliklinik] ([poliklinikNo], [poliklinikBolum], [poliklinikCalisanSayisi], [poliklinikSorumlusu]) VALUES (1, N'Cerrahi', 15, NULL)
INSERT [dbo].[Poliklinik] ([poliklinikNo], [poliklinikBolum], [poliklinikCalisanSayisi], [poliklinikSorumlusu]) VALUES (2, N'Ortopedi', 10, NULL)
INSERT [dbo].[Poliklinik] ([poliklinikNo], [poliklinikBolum], [poliklinikCalisanSayisi], [poliklinikSorumlusu]) VALUES (3, N'Dermotoloji', 5, NULL)
SET IDENTITY_INSERT [dbo].[Poliklinik] OFF
GO
SET IDENTITY_INSERT [dbo].[Receteler] ON 

INSERT [dbo].[Receteler] ([receteNo], [receteTarih], [receteTanimi], [hastaNo], [doktorNo]) VALUES (1, CAST(N'2001-05-15T00:00:00.000' AS DateTime), N'Bogaz Enfeksiyonu', 2, 2)
SET IDENTITY_INSERT [dbo].[Receteler] OFF
GO
SET IDENTITY_INSERT [dbo].[Sekreter] ON 

INSERT [dbo].[Sekreter] ([sekreterNo], [sekreterKAdi], [sekreterSifre], [sekreterAdSoyad]) VALUES (1, N'bugra', N'1234', N'bugra karliyol')
INSERT [dbo].[Sekreter] ([sekreterNo], [sekreterKAdi], [sekreterSifre], [sekreterAdSoyad]) VALUES (2, N'berker', N'1234', N'berker')
SET IDENTITY_INSERT [dbo].[Sekreter] OFF
GO
SET IDENTITY_INSERT [dbo].[Yonetici] ON 

INSERT [dbo].[Yonetici] ([yoneticiNo], [yoneticiAdSoyad], [yoneticiKAdi], [yoneticiSifre]) VALUES (2, N'orhun gença', N'orhun', N'123456')
INSERT [dbo].[Yonetici] ([yoneticiNo], [yoneticiAdSoyad], [yoneticiKAdi], [yoneticiSifre]) VALUES (3, N'fdskgs', N'ali', N'1234')
INSERT [dbo].[Yonetici] ([yoneticiNo], [yoneticiAdSoyad], [yoneticiKAdi], [yoneticiSifre]) VALUES (4, N'skhsdf', N'mehmet', N'123456789')
INSERT [dbo].[Yonetici] ([yoneticiNo], [yoneticiAdSoyad], [yoneticiKAdi], [yoneticiSifre]) VALUES (5, N'gggg', N'gggg', N'gggg')
SET IDENTITY_INSERT [dbo].[Yonetici] OFF
GO
ALTER TABLE [dbo].[Arayüz]  WITH CHECK ADD  CONSTRAINT [FK_Arayüz_Hastalar] FOREIGN KEY([hastaNo])
REFERENCES [dbo].[Hastalar] ([hastaNo])
GO
ALTER TABLE [dbo].[Arayüz] CHECK CONSTRAINT [FK_Arayüz_Hastalar]
GO
ALTER TABLE [dbo].[Arayüz]  WITH CHECK ADD  CONSTRAINT [FK_Arayüz_Poliklinik] FOREIGN KEY([poliklinikNo])
REFERENCES [dbo].[Poliklinik] ([poliklinikNo])
GO
ALTER TABLE [dbo].[Arayüz] CHECK CONSTRAINT [FK_Arayüz_Poliklinik]
GO
ALTER TABLE [dbo].[Doktorlar]  WITH CHECK ADD  CONSTRAINT [FK_Doktorlar_Poliklinik1] FOREIGN KEY([poliklinikNo])
REFERENCES [dbo].[Poliklinik] ([poliklinikNo])
GO
ALTER TABLE [dbo].[Doktorlar] CHECK CONSTRAINT [FK_Doktorlar_Poliklinik1]
GO
ALTER TABLE [dbo].[Receteler]  WITH CHECK ADD  CONSTRAINT [FK_Receteler_Doktorlar] FOREIGN KEY([doktorNo])
REFERENCES [dbo].[Doktorlar] ([doktorNo])
GO
ALTER TABLE [dbo].[Receteler] CHECK CONSTRAINT [FK_Receteler_Doktorlar]
GO
ALTER TABLE [dbo].[Receteler]  WITH CHECK ADD  CONSTRAINT [FK_Receteler_Hastalar] FOREIGN KEY([hastaNo])
REFERENCES [dbo].[Hastalar] ([hastaNo])
GO
ALTER TABLE [dbo].[Receteler] CHECK CONSTRAINT [FK_Receteler_Hastalar]
GO
/****** Object:  StoredProcedure [dbo].[DoktorAra]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[DoktorAra]
@doktorAdSoyad varchar(50)
as begin
select * from Doktorlar where doktorAdSoyad like '%'+@doktorAdSoyad + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorAraBolum]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DoktorAraBolum]	
@doktorBolum varchar(50)
as begin
select * from Doktorlar where doktorBolum like '%'+@doktorBolum+'%' order by doktorBolum asc
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorAraPoliNo]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DoktorAraPoliNo]
@poliklinikNo int
as begin
select * from Doktorlar where poliklinikNo =@poliklinikNo order by poliklinikNo asc
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorAraUnvan]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DoktorAraUnvan]
@doktorUnvan varchar(50)
as begin
select * from Doktorlar where doktorUnvan like '%'+@doktorUnvan+'%' order by doktorUnvan asc
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorDel]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorDel]
@doktorNo int
as begin 
delete from Doktorlar where doktorNo=@doktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorEkle]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorEkle]
@doktorAdSoyad varchar(50),
@doktorBolum varchar(50),
@doktorUnvan varchar(50),
@poliklinikNo int 
as begin
insert into Doktorlar([doktorAdSoyad],[doktorBolum],[doktorUnvan],[poliklinikNo])values(@doktorAdSoyad,@doktorBolum,@doktorUnvan,@poliklinikNo)
end
GO
/****** Object:  StoredProcedure [dbo].[HastaAraBoy]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[HastaAraBoy]
@hastaBoy int
as begin
select*from Hastalar where hastaBoy=@hastaBoy order by hastaBoy asc
end
GO
/****** Object:  StoredProcedure [dbo].[HastaAraKilo]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[HastaAraKilo]
@hastaKilo int
as begin
select* from Hastalar where hastaKilo=@hastaKilo order by hastaKilo asc
end
GO
/****** Object:  StoredProcedure [dbo].[HastaAraYas]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[HastaAraYas]
@hastaYas int
as begin
select *from Hastalar where hastaYas=@hastaYas order by hastaYas asc
end
GO
/****** Object:  StoredProcedure [dbo].[HastaDel]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaDel]
@hastaNo int
as begin
delete from Hastalar where hastaNo=@hastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[HastaEkle]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[HastaEkle]
@hastaAdSoyad varchar(50),
@hastaYas int,
@hastaBoy int,
@hastaKilo int
as begin
insert into Hastalar([hastaAdSoyad],[hastaYas],[hastaBoy],[hastaKilo])values(@hastaAdSoyad,@hastaYas,@hastaBoy,@hastaKilo)
end
GO
/****** Object:  StoredProcedure [dbo].[HastaList]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[HastaList]
@hastaAdSoyad varchar(50)
as begin
select *from Hastalar where hastaAdSoyad like '%'+@hastaAdSoyad+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[HastaList2]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaList2]
as begin
select * from Hastalar
end
GO
/****** Object:  StoredProcedure [dbo].[ListDoktor]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListDoktor]
as begin 
select *from Doktorlar
end
GO
/****** Object:  StoredProcedure [dbo].[PoliklinikAra]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PoliklinikAra]
@poliklinikBolum varchar(50)
as begin
select * from Poliklinik where poliklinikBolum like '%'+@poliklinikBolum + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[PoliklinikAraCSayisi]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PoliklinikAraCSayisi]
@poliklinikCalisanSayisi int
as begin
select * from Poliklinik where poliklinikCalisanSayisi =@poliklinikCalisanSayisi order by poliklinikCalisanSayisi asc
end
GO
/****** Object:  StoredProcedure [dbo].[PoliklinikDel]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PoliklinikDel]
@poliklinikNo int
as begin
delete from Poliklinik where poliklinikNo=@poliklinikNo
end
GO
/****** Object:  StoredProcedure [dbo].[PoliklinikEkle]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PoliklinikEkle]
@poliklinikBolum varchar(50),
@poliklinikCalisanSayisi int
as begin
insert into Poliklinik([poliklinikBolum],[poliklinikCalisanSayisi])values(@poliklinikBolum,@poliklinikCalisanSayisi)
end
GO
/****** Object:  StoredProcedure [dbo].[PoliklinikList]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[PoliklinikList]
as begin
select*from Poliklinik
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteAra]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ReceteAra]
@receteTanimi varchar(50)
as begin
select * from Receteler where receteTanimi like '%'+@receteTanimi + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteAraDoktorNo]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ReceteAraDoktorNo]
@doktorNo int
as begin
select * from Recete where doktorNo =@doktorNo order by doktorNo asc
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteAraHastaNo]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ReceteAraHastaNo]
@hastaNo int
as begin
select * from Recete where hastaNo =@hastaNo order by hastaNo asc
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteAraTarih]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ReceteAraTarih]
@receteTarih datetime
as begin
select * from Recete where receteTarih=@receteTarih order by receteTarih asc
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteDel]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteDel]
@receteNo int
as begin
delete from Receteler where receteNo=@receteNo
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteEkle]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteEkle]
@receteTarih datetime,
@receteTanimi varchar(50),
@hastaNo int,
@doktorNo int
as begin
insert into Receteler([receteTarih],[receteTanimi],[hastaNo],[doktorNo])values(@receteTarih,@receteTanimi,@hastaNo,@doktorNo)
end
GO
/****** Object:  StoredProcedure [dbo].[ReceteList]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ReceteList]
as begin
select*from Receteler
end
GO
/****** Object:  StoredProcedure [dbo].[SekreteLogin]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SekreteLogin]
@sekreterKAdi varchar(50),
@sekreterSifre varchar(50)
as begin
select * from Sekreter where sekreterKAdi=@sekreterKAdi and sekretersifre=@sekreterSifre
end
GO
/****** Object:  StoredProcedure [dbo].[SekreterAra]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SekreterAra]
@sekreterAdSoyad varchar(50)
as begin
select * from Sekreter where sekreterAdSoyad like '%'+@sekreterAdSoyad + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[SekreterAraKAdi]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SekreterAraKAdi]
@sekreterKAdi varchar(50)
as begin
select * from Sekreter where sekreterKAdi like '%' + @sekreterKAdi + '%' order by sekreterKAdi asc
end
GO
/****** Object:  StoredProcedure [dbo].[SekreterAraSifre]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[SekreterAraSifre]
@sekreterSifre varchar(50)
as begin
select * from Sekreter where sekreterSifre like '%' + @sekreterSifre + '%' order by sekreterSifre asc
end
GO
/****** Object:  StoredProcedure [dbo].[SekreterDel]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SekreterDel]
@sekreterNo int
as begin
delete from Sekreter where sekreterNo=@sekreterNo
end
GO
/****** Object:  StoredProcedure [dbo].[SekreterEkle]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SekreterEkle]
@sekreterKAdi varchar(50),
@sekreterSifre varchar(50),
@sekreterAdSoyad varchar(50)
as begin
insert into Sekreter([sekreterKAdi],[sekreterSifre],[sekreterAdSoyad])values(@sekreterKAdi,@sekreterSifre,@sekreterAdSoyad)
end
GO
/****** Object:  StoredProcedure [dbo].[SekreterList]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SekreterList]
as begin
select * from Sekreter
end
GO
/****** Object:  StoredProcedure [dbo].[updateDoktor]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateDoktor]
@doktorNo int,
@doktorAdSoyad varchar(50),
@doktorBolum varchar(50),
@doktorUnvan varchar(50),
@poliklinikNo int 
as begin
update Doktorlar set doktorAdSoyad=@doktorAdSoyad,doktorBolum=@doktorBolum,doktorUnvan=@doktorUnvan,poliklinikNo=@poliklinikNo where doktorNo=@doktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[updateHasta]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[updateHasta]
@hastaNo int,
@hastaAdSoyad varchar(50),
@hastaYas int,
@hastaBoy int,
@hastaKilo int
as begin
update Hastalar set hastaAdSoyad=@hastaAdSoyad,hastaYas=@hastaYas,hastaBoy=@hastaBoy,hastaKilo=@hastaKilo where hastaNo=@hastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[updatePoliklinik]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updatePoliklinik]
@poliklinikNo int,
@poliklinikBolum varchar(50),
@poliklinikCalisanSayisi int
as begin
update Poliklinik set poliklinikBolum=@poliklinikBolum, poliklinikCalisanSayisi=@poliklinikCalisanSayisi where poliklinikNo=@poliklinikNo
end
GO
/****** Object:  StoredProcedure [dbo].[updateRecete]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateRecete]
@receteNo int,
@receteTarih datetime,
@receteTanimi varchar(50),
@hastaNo int,
@doktorNo int
as begin
update Receteler set receteTarih=@receteTarih, receteTanimi=@receteTanimi,hastaNo=@hastaNo,doktorNo=@doktorNo where receteNo=@receteNo
end
GO
/****** Object:  StoredProcedure [dbo].[updateSekreter]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateSekreter]
@sekreterNo int,
@sekreterKAdi varchar(50),
@sekreterSifre varchar(50),
@sekreterAdSoyad varchar(50)
as begin
update Sekreter set sekreterKAdi=@sekreterKAdi,sekreterSifre=@sekreterSifre,sekreterAdSoyad=@sekreterAdSoyad where sekreterNo=@sekreterNo
end
GO
/****** Object:  StoredProcedure [dbo].[updateYonetici]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[updateYonetici]
@yoneticiNo int,
@yoneticiAdSoyad varchar(50),
@yoneticiKAdi varchar(50),
@yoneticiSifre varchar(50)
as begin
update Yonetici set yoneticiAdSoyad=@yoneticiAdSoyad,yoneticiKAdi=@yoneticiKAdi,yoneticiSifre=@yoneticiSifre where yoneticiNo=@yoneticiNo
end
GO
/****** Object:  StoredProcedure [dbo].[YoneticiAra]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[YoneticiAra]
@yoneticiAdSoyad varchar(50)
as begin
select * from Yonetici where yoneticiAdSoyad like '%'+@yoneticiAdSoyad + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[YoneticiArakAdi]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[YoneticiArakAdi]
@yoneticiKAdi varchar(50)
as begin
select * from Yonetici where yoneticiKAdi like '%' + @yoneticiKAdi + '%' order by yoneticiKAdi asc
end
GO
/****** Object:  StoredProcedure [dbo].[YoneticiAraSifre]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[YoneticiAraSifre]
@yoneticiSifre varchar(50)
as begin
select * from Yonetici where yoneticiSifre like '%' + @yoneticiSifre + '%' order by yoneticiSifre asc
end
GO
/****** Object:  StoredProcedure [dbo].[YoneticiDel]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[YoneticiDel]
@yoneticiNo int
as begin 
delete from Yonetici where yoneticiNo=@yoneticiNo
end
GO
/****** Object:  StoredProcedure [dbo].[YoneticiEkle]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[YoneticiEkle]
@yoneticiAdSoyad varchar(50),
@yoneticiKAdi varchar(50),
@yoneticiSifre varchar(50)
as begin
insert into Yonetici([yoneticiAdSoyad],[yoneticiKAdi],[yoneticiSifre])values(@yoneticiAdSoyad,@yoneticiKAdi,@yoneticiSifre)
end
GO
/****** Object:  StoredProcedure [dbo].[YoneticiList]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[YoneticiList]
as begin
select*from Yonetici
end
GO
/****** Object:  StoredProcedure [dbo].[YoneticiLogin]    Script Date: 13.08.2023 11:07:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[YoneticiLogin]
@yoneticiKAdi varchar(50),
@yoneticiSifre varchar(50)
as begin
select * from Yonetici where yoneticiKAdi=@yoneticiKAdi and yoneticisifre=@yoneticiSifre
end
GO
USE [master]
GO
ALTER DATABASE [Hastane] SET  READ_WRITE 
GO
