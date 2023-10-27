use master
--Delete database company (works on any SQL Server version)
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'GameAPIDB')
BEGIN
	ALTER DATABASE GameAPIDB SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE GameAPIDB SET ONLINE;
	DROP DATABASE GameAPIDB;
end
--drop database if exists Company --Delete database company (works only SQL Server  version > 14)
go

create database GameAPIDB -- Create new database with name company

go

use GameAPIDB 
GO
/*******************************************************************************
   Create Tables
********************************************************************************/
GO
CREATE TABLE [dbo].[Authors]
(
    [ID] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [PosterUrl] NVARCHAR(200) NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([ID])
);
GO
CREATE TABLE [dbo].[Games]
(
    [ID] INT NOT NULL IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(500) NOT NULL,
    [ShortDescription] NVARCHAR(150) NOT NULL,
    [Price] DECIMAL(10, 2) NOT NULL,
    [PosterUrl] NVARCHAR(200) NOT NULL,
    [ImgUrl] NVARCHAR(200) NOT NULL,
    [Logo] NVARCHAR(200) NOT NULL,
    [AuthorId] INT NOT NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([ID]),
    CONSTRAINT [FK_Game_Author_Id] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors]([ID])
);
GO

INSERT INTO [dbo].[Authors]
([Name], [Description], [PosterUrl])
VALUES (
    'Riot Games', 
    'Riot Games, Inc. is an American vIdeo game developer, publisher and esports tournament organizer based in Los Angeles, California.', 
    'https://www.riotgames.com/darkroom/800/87521fcaeca5867538ae7f46ac152740:2f8144e17957078916e41d2410c111c3/002-rg-2021-full-lockup-offwhite.jpg'
)
INSERT INTO [dbo].[Authors]
([Name], [Description], [PosterUrl])
VALUES (
    'Rockstar Games', 
    'Rockstar Games, Inc. is an American vIdeo game publisher based in New York City. The company was established in December 1998 as a subsIdiary of Take-Two Interactive, using the assets Take-Two had previously acquired from BMG Interactive.', 
    'https://cdn.dribbble.com/users/1732431/screenshots/4902347/media/0ab5af099dbcf00a89a25edf29a3c74f.png'
)
INSERT INTO [dbo].[Authors]
([Name], [Description], [PosterUrl])
VALUES (
    'CD Projekt', 
    'CD Projekt S.A. is a Polish vIdeo game developer, publisher and distributor based in Warsaw, founded in May 1994 by Marcin Iwiński and Michał Kiciński. Iwiński and Kiciński were vIdeo game retailers before they founded the company, which initially acted as a distributor of foreign vIdeo games for the domestic market.', 
    'https://www.cdprojekt.com/en/wp-content/uploads-en/2016/01/cdp_004-1024x760.jpg'
)
INSERT INTO [dbo].[Authors]
([Name], [Description], [PosterUrl])
VALUES (
    'Mundfish', 
    'Mundfish is a vIdeo game development company based in Russia. The company was founded in 2016 and is focused on creating unique and innovative games that provIde players with immersive and engaging experiences.', 
    'https://trademarks.justia.com/media/og_image.php?serial=88188420'
)

INSERT INTO [dbo].[Games]
([Name], [Description], [ShortDescription], [Price], [PosterUrl], [ImgUrl], [Logo], [AuthorId])
VALUES (
    'Valorant', 
    'Riot Games presents VALORANT: a 5v5 character-based tactical FPS where precise gunplay meets unique agent abilities. Learn about VALORANT and its stylish gameplay.', 
    '5v5 character-based tactical FPS where precise gunplay meets unique agent abilities.', 
    0, 
    'https://m.media-amazon.com/images/M/MV5BNmNhM2NjMTgtNmIyZC00ZmVjLTk4YWItZmZjNGY2NThiNDhkXkEyXkFqcGdeQXVyODU4MDU1NjU@._V1_.jpg',
    'https://www.riotgames.com/darkroom/1440/d0807e131a84f2e42c7a303bda672789:3d02afa7e0bfb75f645d97467765b24c/valorant-offwhitelaunch-keyart.jpg',
    'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Valorant_logo_-_pink_color_version.svg/2560px-Valorant_logo_-_pink_color_version.svg.png',
    1
)
INSERT INTO [dbo].[Games]
([Name], [Description], [ShortDescription], [Price], [PosterUrl], [ImgUrl], [Logo], [AuthorId])
VALUES (
    'Grand Theft Auto V', 
    'Grand Theft Auto V is an action-adventure game played from either a third-person or first-person perspective. Players complete missions—linear scenarios with set objectives—to progress through the story. OutsIde of the missions, players may freely roam the open world.', 
    'Action-adventure game played from either a third-person or first-person perspective.', 
    59.99, 
    'https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/51MFu2e82VL.jpg',
    'https://i0.wp.com/www.alphr.com/wp-content/uploads/2021/03/How-to-Switch-Characters-in-GTA-5-scaled.jpg',
    'https://www.freepnglogos.com/uploads/gta-5-logo-png/grand-theft-auto-v-1.png',
    2
)
INSERT INTO [dbo].[Games]
([Name], [Description], [ShortDescription], [Price], [PosterUrl], [ImgUrl], [Logo], [AuthorId])
VALUES (
    'The Witcher 3: Wild Hunt', 
    'The Witcher 3: Wild Hunt is a story-driven, open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences. In The Witcher, you play as Geralt of Rivia, a monster hunter tasked with finding a child from an ancient prophecy.', 
    'A story-driven, open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences.', 
    19.99, 
    'https://picfiles.alphacoders.com/198/thumb-198636.jpg',
    'https://pbs.twimg.com/media/FnfVL5SXkAAKXBc.png:large',
    'https://upload.wikimedia.org/wikipedia/fr/thumb/4/44/The_Witcher_3_Wild_Hunt_Logo.png/2560px-The_Witcher_3_Wild_Hunt_Logo.png',
    3
)
INSERT INTO [dbo].[Games]
([Name], [Description], [ShortDescription], [Price], [PosterUrl], [ImgUrl], [Logo], [AuthorId])
VALUES (
    'Atomic Heart', 
    'Atomic Heart is an adventure role-playing action game with a closed world, which takes place in an alternative Soviet Union of 1955. Science, equality and fraternity are the main symbols of Freedom in this reality.', 
    'Adventure role-playing action game with a closed world, which takes place in an alternative Soviet Union of 1955.', 
    59.99, 
    'https://upload.wikimedia.org/wikipedia/en/d/d3/Atomic_Heart_cover.jpg',
    'https://cdn.cloudflare.steamstatic.com/steam/apps/668580/capsule_616x353.jpg',
    'https://mundfish.com/wp-content/themes/atomicheart/img/main-sub-logo.png',
    4
)
INSERT INTO [dbo].[Games]
([Name], [Description], [ShortDescription], [Price], [PosterUrl], [ImgUrl], [Logo], [AuthorId])
VALUES (
    'League of Legends', 
    'League of Legends is a team-based strategy game where two teams of five powerful champions face off to destroy the others base.', 
    'Team-based strategy game where two teams of five powerful champions face off to destroy the others base.', 
    0, 
    'https://cdn1.epicgames.com/offer/24b9b5e323bc40eea252a10cdd3b2f10/LoL_1200x1600-15ad6c981af8d98f50e833eac7843986',
    'https://portforward.com/league-of-legends/league-of-legends-header-small.webp',
    'https://www.leagueoflegends.com/static/logo-1200-589b3ef693ce8a750fa4b4704f1e61f2.png',
    1
)
GO

/*

DROP TABLE [dbo].[Games]
DROP TABLE [dbo].[Authors]

select *
from [dbo].[Games]
select *
from [dbo].[Authors]

*/