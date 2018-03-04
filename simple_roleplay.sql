-- phpMyAdmin SQL Dump
-- version 4.2.12deb2+deb8u2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Erstellungszeit: 22. Nov 2017 um 00:33
-- Server Version: 10.0.32-MariaDB-0+deb8u1
-- PHP-Version: 5.6.30-0+deb8u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Datenbank: `gtmp_roleplay`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `accounts`
--

CREATE TABLE IF NOT EXISTS `accounts` (
`Id` int(11) NOT NULL,
  `SocialClubName` varchar(512) NOT NULL,
  `Password` varchar(512) NOT NULL,
  `LoggedIn` tinyint(1) NOT NULL DEFAULT '0',
  `AdminLvl` int(11) NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `LastUsage` datetime NOT NULL,
  `LastIP` varchar(512) NOT NULL,
  `LastHWID` varchar(512) NOT NULL,
  `Locked` int(1) NOT NULL DEFAULT '0',
  `MaxCharacters` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `atms`
--

CREATE TABLE IF NOT EXISTS `atms` (
`Id` int(11) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT '1',
  `PosX` float NOT NULL,
  `PosY` float NOT NULL,
  `PosZ` float NOT NULL,
  `MoneyStorage` double DEFAULT '0',
  `ShowOnMap` int(1) DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `atms`
--

INSERT INTO `atms` (`Id`, `Status`, `PosX`, `PosY`, `PosZ`, `MoneyStorage`, `ShowOnMap`) VALUES
(1, 1, 147.584, -1035.69, 29.3431, 0, 0),
(2, 1, 146.012, -1035.13, 29.3449, 0, 0),
(3, 1, 119.182, -883.582, 31.1231, 0, 0),
(4, 1, 112.54, -819.281, 31.3387, 0, 0),
(5, 1, 111.256, -775.341, 31.4382, 0, 0),
(6, 1, 114.435, -776.48, 31.4175, 0, 0),
(7, 1, 5.2445, -919.784, 29.56, 0, 0),
(8, 1, -203.691, -861.315, 30.2676, 0, 0),
(9, 1, -301.587, -830.319, 32.4185, 0, 0),
(10, 1, -303.302, -829.721, 32.4173, 0, 0),
(11, 1, -258.835, -723.438, 33.4722, 0, 0),
(12, 1, -256.201, -715.907, 33.528, 0, 0),
(13, 1, -254.383, -692.471, 33.6093, 0, 0),
(14, 1, -537.921, -854.519, 29.283, 0, 0),
(15, 1, -2072.46, -317.276, 13.316, 0, 0),
(16, 1, -1314.83, -836.06, 16.9602, 0, 0),
(17, 1, -1315.69, -834.765, 16.9617, 0, 0),
(18, 1, -1109.75, -1690.57, 4.37503, 0, 0),
(19, 1, -821.523, -1081.89, 11.1324, 0, 0),
(20, 1, -526.521, -1222.92, 18.455, 0, 0),
(21, 1, -56.8791, -1752.12, 29.421, 0, 0),
(22, 1, 288.789, -1282.4, 29.6481, 0, 0),
(23, 1, 289.049, -1256.86, 29.4408, 0, 0),
(24, 1, 1166.87, -456.127, 66.8075, 0, 0),
(25, 1, 1138.26, -468.818, 66.7338, 0, 0),
(26, 1, 1153.93, -326.654, 69.2051, 0, 0),
(27, 1, 2558.8, 350.842, 108.621, 0, 0),
(28, 1, 2558.41, 389.649, 108.623, 0, 0),
(29, 1, 2683.05, 3286.51, 55.2411, 0, 0),
(30, 1, 1701.23, 6426.61, 32.764, 0, 0),
(31, 1, 174.183, 6637.77, 31.573, 0, 0),
(32, 1, 155.901, 6642.74, 31.6039, 0, 0),
(33, 1, -282.964, 6225.98, 31.4932, 0, 0),
(34, 1, -386.822, 6046.03, 31.5017, 0, 0),
(35, 1, -3144.31, 1127.66, 20.8549, 0, 0),
(36, 1, -2958.97, 487.756, 15.4639, 0, 0),
(37, 1, -2956.97, 487.649, 15.4639, 0, 0),
(38, 1, 1735.21, 6410.54, 35.0372, 0, 0),
(39, 1, 540.435, 2671.01, 42.1565, 0, 0),
(40, 1, 295.602, -896.061, 29.2129, 0, 0),
(41, 1, 296.363, -894.129, 29.2295, 0, 0),
(42, 1, 1171.49, 2702.49, 38.1755, 0, 0),
(43, 1, 1172.62, 2702.59, 38.1747, 0, 0),
(44, 1, -614.54, -704.749, 31.2359, 0, 0),
(45, 1, -611.958, -704.825, 31.2359, 0, 0),
(46, 1, -618.295, -706.845, 30.0528, 0, 0),
(47, 1, -618.273, -708.794, 30.0528, 0, 0),
(48, 1, 1702.95, 4933.58, 42.0636, 0, 0),
(49, 1, 1968.09, 3743.65, 32.3438, 0, 0),
(50, 1, 33.1493, -1348.16, 29.497, 0, 0),
(51, 1, -1827.19, 784.91, 138.302, 0, 0),
(52, 1, 237.378, 217.792, 106.287, 0, 0),
(53, 1, 236.937, 218.74, 106.287, 0, 0),
(54, 1, 237.806, 216.889, 106.287, 0, 0),
(55, 1, 238.298, 215.817, 106.287, 0, 0),
(56, 1, 236.543, 219.584, 106.287, 0, 0),
(57, 1, 158.346, 234.216, 106.634, 0, 0),
(58, 1, -165.068, 234.752, 94.9219, 0, 0),
(59, 1, -165.069, 232.651, 94.922, 0, 0),
(60, 1, -866.677, -187.709, 37.8428, 0, 0),
(61, 1, -867.657, -186.059, 37.843, 0, 0),
(62, 1, -846.713, -340.253, 38.6803, 0, 0),
(63, 1, -846.264, -341.143, 38.6802, 0, 0),
(64, 1, -1571.08, -547.294, 34.9579, 0, 0),
(65, 1, -1570.11, -546.577, 34.9537, 0, 0),
(66, 1, -3040.83, 593.139, 7.90893, 0, 0),
(67, 1, -3241.1, 997.528, 12.5505, 0, 0),
(68, 1, -3240.67, 1008.6, 12.8307, 0, 0),
(69, 1, 285.608, 143.411, 104.17, 0, 0),
(70, 1, -132.883, 6366.37, 31.4742, 0, 0),
(71, 1, 356.971, 173.451, 103.067, 0, 0),
(72, 1, 89.8001, 2.33412, 68.3054, 0, 0),
(73, 1, 527.305, -160.572, 57.0943, 0, 0),
(74, 1, -57.7761, -92.5897, 57.7793, 0, 0),
(75, 1, 1686.76, 4815.83, 42.0087, 0, 0),
(76, 1, -1205.62, -324.914, 37.8567, 0, 0),
(77, 1, -1204.88, -326.364, 37.834, 0, 0),
(78, 1, 1077.89, -776.45, 58.2395, 0, 0),
(79, 1, 130.035, -1292.64, 29.2695, 0, 0),
(80, 1, 129.542, -1291.87, 29.2695, 0, 0),
(81, 1, 129.086, -1291.07, 29.2695, 0, 0),
(82, 1, -3044.1, 594.622, 7.73626, 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `characters`
--

CREATE TABLE IF NOT EXISTS `characters` (
`Id` int(11) NOT NULL,
  `SocialClubName` varchar(512) NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `LastUsage` datetime NOT NULL,
  `FirstName` varchar(512) NOT NULL,
  `LastName` varchar(512) NOT NULL,
  `Gender` int(2) NOT NULL,
  `Locked` int(1) NOT NULL,
  `Cash` double NOT NULL,
  `Bank` double NOT NULL,
  `Faction` int(11) NOT NULL,
  `FactionRank` int(11) NOT NULL,
  `PosX` float NOT NULL DEFAULT '0',
  `PosY` float NOT NULL DEFAULT '0',
  `PosZ` float NOT NULL DEFAULT '0',
  `Hair` int(11) NOT NULL,
  `HairColor` int(11) NOT NULL,
  `HairHighlightColor` int(11) NOT NULL,
  `Father` int(11) NOT NULL,
  `Mother` int(11) NOT NULL,
  `Similarity` float NOT NULL,
  `SkinSimilarity` float NOT NULL,
  `EyebrowColor` int(11) NOT NULL,
  `BeardColor` int(11) NOT NULL,
  `EyeColor` int(11) NOT NULL,
  `BlushColor` int(11) NOT NULL,
  `LipstickColor` int(11) NOT NULL,
  `ChestHairColor` int(11) NOT NULL,
  `Blemishes` int(11) NOT NULL,
  `Facialhair` int(11) NOT NULL,
  `Eyebrows` int(11) NOT NULL,
  `Ageing` int(11) NOT NULL,
  `Makeup` int(11) NOT NULL,
  `Blush` int(11) NOT NULL,
  `Complexion` int(11) NOT NULL,
  `Sundamage` int(11) NOT NULL,
  `Lipstick` int(11) NOT NULL,
  `Freckles` int(11) NOT NULL,
  `Chesthair` int(11) NOT NULL,
  `ClothesTop` int(11) NOT NULL DEFAULT '0',
  `ClothesLegs` int(11) NOT NULL DEFAULT '0',
  `ClothesFeets` int(11) NOT NULL DEFAULT '0',
  `Inventory` varchar(20000) NOT NULL DEFAULT '[]',
  `Hunger` int(11) NOT NULL DEFAULT '100',
  `Thirst` int(11) NOT NULL DEFAULT '100',
  `Bought_Clothing` text NOT NULL,
  `OnDuty` int(2) NOT NULL DEFAULT '0',
  `Weapons` varchar(2000) NOT NULL DEFAULT '[]'
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `clothes_feets`
--

CREATE TABLE IF NOT EXISTS `clothes_feets` (
`Id` int(11) NOT NULL,
  `Slot` int(11) NOT NULL,
  `Drawable` int(11) NOT NULL,
  `Texture` int(11) NOT NULL,
  `Torso` int(11) NOT NULL,
  `StoreType` int(11) NOT NULL,
  `Undershirt` int(11) NOT NULL,
  `Gender` int(11) NOT NULL,
  `Price` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `clothes_feets`
--

INSERT INTO `clothes_feets` (`Id`, `Slot`, `Drawable`, `Texture`, `Torso`, `StoreType`, `Undershirt`, `Gender`, `Price`) VALUES
(1, 6, 1, 0, 0, 0, 0, 0, 0),
(2, 6, 1, 0, 0, 0, 0, 1, 0),
(3, 6, 1, 1, 0, 0, 0, 0, 0),
(4, 6, 1, 1, 0, 0, 0, 1, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `clothes_legs`
--

CREATE TABLE IF NOT EXISTS `clothes_legs` (
`Id` int(11) NOT NULL,
  `Slot` int(11) NOT NULL,
  `Drawable` int(11) NOT NULL,
  `Texture` int(11) NOT NULL,
  `Torso` int(11) NOT NULL,
  `StoreType` int(11) NOT NULL,
  `Undershirt` int(11) NOT NULL,
  `Gender` int(11) NOT NULL,
  `Price` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `clothes_legs`
--

INSERT INTO `clothes_legs` (`Id`, `Slot`, `Drawable`, `Texture`, `Torso`, `StoreType`, `Undershirt`, `Gender`, `Price`) VALUES
(1, 4, 0, 0, 0, 0, 0, 0, 0),
(2, 4, 0, 0, 0, 0, 0, 1, 0),
(3, 4, 14, 0, 0, 0, 0, 1, 0),
(4, 4, 6, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `clothes_outfits`
--

CREATE TABLE IF NOT EXISTS `clothes_outfits` (
`Id` int(11) NOT NULL,
  `Outfit` varchar(2000) NOT NULL DEFAULT '{}'
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `clothes_outfits`
--

INSERT INTO `clothes_outfits` (`Id`, `Outfit`) VALUES
(1, '{"Name":"Police Male","Gender":0,"Torso":0,"TorsoTxt":0,"Top":55,"TopTxt":0,"Leg":35,"LegTxt":0,"Feet":25,"FeetTxt":0,"Undershirt":58,"UndershirtTxt":0,"Hat":-1,"HatTxt":0}'),
(2, '{"Name":"Police Female","Gender":1,"Torso":14,"TorsoTxt":0,"Top":48,"TopTxt":0,"Leg":34,"LegTxt":0,"Feet":25,"FeetTxt":0,"Undershirt":35,"UndershirtTxt":0,"Hat":-1,"HatTxt":0}'),
(3, '{"Name":"Prisoner Male","Gender":0,"Torso":5,"TorsoTxt":0,"Top":5,"TopTxt":0,"Leg":7,"LegTxt":15,"Feet":6,"FeetTxt":7,"Undershirt":8,"UndershirtTxt":15,"Hat":-1,"HatTxt":0}'),
(4, '{"Name":"Prisoner Female","Gender":1,"Torso":14,"TorsoTxt":0,"Top":49,"TopTxt":0,"Leg":3,"LegTxt":15,"Feet":10,"FeetTxt":1,"Undershirt":2,"UndershirtTxt":0,"Hat":-1,"HatTxt":0}'),
(5, '{"Name":"EMS Male","Gender":0,"Torso":14,"TorsoTxt":0,"Top":49,"TopTxt":0,"Leg":3,"LegTxt":15,"Feet":10,"FeetTxt":1,"Undershirt":2,"UndershirtTxt":0,"Hat":-1,"HatTxt":0}'),
(6, '{"Name":"EMS Female","Gender":1,"Torso":106,"TorsoTxt":0,"Top":79,"TopTxt":3,"Leg":6,"LegTxt":0,"Feet":10,"FeetTxt":1,"Undershirt":2,"UndershirtTxt":0,"Hat":-1,"HatTxt":0}');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `clothes_tops`
--

CREATE TABLE IF NOT EXISTS `clothes_tops` (
`Id` int(11) NOT NULL,
  `Slot` int(11) NOT NULL,
  `Drawable` int(11) NOT NULL,
  `Texture` int(11) NOT NULL,
  `Torso` int(11) NOT NULL,
  `StoreType` int(11) NOT NULL,
  `Undershirt` int(11) NOT NULL,
  `Gender` int(11) NOT NULL,
  `Price` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=219 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `clothes_tops`
--

INSERT INTO `clothes_tops` (`Id`, `Slot`, `Drawable`, `Texture`, `Torso`, `StoreType`, `Undershirt`, `Gender`, `Price`) VALUES
(1, 11, 0, 0, 0, 0, 2, 1, 0),
(2, 11, 0, 1, 0, 0, 2, 1, 0),
(3, 11, 0, 2, 0, 0, 2, 1, 0),
(4, 11, 0, 3, 0, 0, 2, 1, 0),
(5, 11, 0, 4, 0, 0, 2, 1, 0),
(6, 11, 0, 5, 0, 0, 2, 1, 0),
(7, 11, 0, 6, 0, 0, 2, 1, 0),
(8, 11, 0, 7, 0, 0, 2, 1, 0),
(9, 11, 0, 8, 0, 0, 2, 1, 0),
(10, 11, 0, 9, 0, 0, 2, 1, 0),
(11, 11, 0, 10, 0, 0, 2, 1, 0),
(12, 11, 0, 11, 0, 0, 2, 1, 0),
(13, 11, 0, 12, 0, 0, 2, 1, 0),
(14, 11, 0, 13, 0, 0, 2, 1, 0),
(15, 11, 0, 14, 0, 0, 2, 1, 0),
(16, 11, 0, 15, 0, 0, 2, 1, 0),
(17, 11, 1, 0, 5, 0, 5, 1, 0),
(18, 11, 1, 1, 5, 0, 5, 1, 0),
(19, 11, 1, 2, 5, 0, 5, 1, 0),
(20, 11, 1, 4, 5, 0, 5, 1, 0),
(21, 11, 1, 5, 5, 0, 5, 1, 0),
(22, 11, 1, 6, 5, 0, 5, 1, 0),
(23, 11, 1, 9, 5, 0, 5, 1, 0),
(24, 11, 1, 14, 5, 0, 5, 1, 0),
(25, 11, 2, 0, 2, 0, 3, 1, 0),
(26, 11, 2, 1, 2, 0, 3, 1, 0),
(27, 11, 2, 2, 2, 0, 3, 1, 0),
(28, 11, 2, 3, 2, 0, 3, 1, 0),
(29, 11, 2, 4, 2, 0, 3, 1, 0),
(30, 11, 2, 5, 2, 0, 3, 1, 0),
(31, 11, 2, 6, 2, 0, 3, 1, 0),
(32, 11, 2, 7, 2, 0, 3, 1, 0),
(33, 11, 2, 8, 2, 0, 3, 1, 0),
(34, 11, 2, 9, 2, 0, 3, 1, 0),
(35, 11, 2, 10, 2, 0, 3, 1, 0),
(36, 11, 2, 11, 2, 0, 3, 1, 0),
(37, 11, 2, 12, 2, 0, 3, 1, 0),
(38, 11, 2, 13, 2, 0, 3, 1, 0),
(39, 11, 2, 14, 2, 0, 3, 1, 0),
(40, 11, 2, 15, 2, 0, 3, 1, 0),
(41, 11, 3, 0, 3, 0, 3, 1, 0),
(42, 11, 3, 1, 3, 0, 3, 1, 0),
(43, 11, 3, 2, 3, 0, 3, 1, 0),
(44, 11, 3, 3, 3, 0, 3, 1, 0),
(45, 11, 3, 4, 3, 0, 3, 1, 0),
(46, 11, 3, 10, 3, 0, 3, 1, 0),
(47, 11, 3, 11, 3, 0, 3, 1, 0),
(48, 11, 3, 12, 3, 0, 3, 1, 0),
(49, 11, 3, 13, 3, 0, 3, 1, 0),
(50, 11, 3, 14, 3, 0, 3, 1, 0),
(51, 11, 4, 13, 4, 0, 3, 1, 0),
(52, 11, 4, 14, 4, 0, 3, 1, 0),
(53, 11, 5, 0, 4, 0, 2, 1, 0),
(54, 11, 5, 1, 4, 0, 2, 1, 0),
(55, 11, 5, 7, 4, 0, 2, 1, 0),
(56, 11, 5, 9, 4, 0, 2, 1, 0),
(57, 11, 6, 0, 5, 0, 39, 1, 0),
(58, 11, 6, 1, 5, 0, 39, 1, 0),
(59, 11, 6, 2, 5, 0, 39, 1, 0),
(60, 11, 6, 4, 5, 0, 39, 1, 0),
(61, 11, 7, 0, 3, 0, 39, 1, 0),
(62, 11, 7, 1, 3, 0, 39, 1, 0),
(63, 11, 7, 2, 3, 0, 39, 1, 0),
(64, 11, 7, 8, 3, 0, 39, 1, 0),
(65, 11, 8, 0, 5, 0, 5, 1, 0),
(66, 11, 8, 1, 5, 0, 5, 1, 0),
(67, 11, 8, 2, 5, 0, 5, 1, 0),
(68, 11, 8, 12, 5, 0, 5, 1, 0),
(69, 11, 9, 0, 0, 0, 3, 1, 0),
(70, 11, 9, 1, 0, 0, 3, 1, 0),
(71, 11, 9, 2, 0, 0, 3, 1, 0),
(72, 11, 9, 3, 0, 0, 3, 1, 0),
(73, 11, 9, 4, 0, 0, 3, 1, 0),
(74, 11, 9, 5, 0, 0, 3, 1, 0),
(75, 11, 9, 6, 0, 0, 3, 1, 0),
(76, 11, 9, 7, 0, 0, 3, 1, 0),
(77, 11, 9, 8, 0, 0, 3, 1, 0),
(78, 11, 9, 9, 0, 0, 3, 1, 0),
(79, 11, 9, 11, 0, 0, 3, 1, 0),
(80, 11, 9, 12, 0, 0, 3, 1, 0),
(81, 11, 9, 13, 0, 0, 3, 1, 0),
(82, 11, 9, 14, 0, 0, 3, 1, 0),
(83, 11, 10, 0, 7, 0, 5, 1, 0),
(84, 11, 10, 1, 7, 0, 5, 1, 0),
(85, 11, 10, 2, 7, 0, 5, 1, 0),
(86, 11, 10, 7, 7, 0, 5, 1, 0),
(87, 11, 10, 10, 7, 0, 5, 1, 0),
(88, 11, 10, 11, 7, 0, 5, 1, 0),
(89, 11, 10, 13, 7, 0, 5, 1, 0),
(90, 11, 10, 15, 7, 0, 5, 1, 0),
(91, 11, 0, 0, 0, 0, 57, 0, 0),
(92, 11, 11, 0, 4, 0, 3, 1, 0),
(93, 11, 11, 1, 4, 0, 3, 1, 0),
(94, 11, 11, 2, 4, 0, 3, 1, 0),
(95, 11, 11, 10, 4, 0, 3, 1, 0),
(96, 11, 11, 11, 4, 0, 3, 1, 0),
(97, 11, 11, 15, 4, 0, 3, 1, 0),
(98, 11, 12, 7, 12, 0, 3, 1, 0),
(99, 11, 12, 8, 12, 0, 3, 1, 0),
(100, 11, 12, 9, 12, 0, 3, 1, 0),
(101, 11, 13, 0, 4, 0, 3, 1, 0),
(102, 11, 13, 1, 4, 0, 3, 1, 0),
(103, 11, 13, 2, 4, 0, 3, 1, 0),
(104, 11, 13, 3, 4, 0, 3, 1, 0),
(105, 11, 13, 4, 4, 0, 3, 1, 0),
(106, 11, 13, 5, 4, 0, 3, 1, 0),
(107, 11, 13, 6, 4, 0, 3, 1, 0),
(108, 11, 13, 7, 4, 0, 3, 1, 0),
(109, 11, 13, 8, 4, 0, 3, 1, 0),
(110, 11, 13, 9, 4, 0, 3, 1, 0),
(111, 11, 13, 10, 4, 0, 3, 1, 0),
(112, 11, 13, 11, 4, 0, 3, 1, 0),
(113, 11, 13, 12, 4, 0, 3, 1, 0),
(114, 11, 13, 13, 4, 0, 3, 1, 0),
(115, 11, 13, 14, 4, 0, 3, 1, 0),
(116, 11, 13, 15, 4, 0, 3, 1, 0),
(117, 11, 14, 0, 0, 0, 3, 1, 0),
(118, 11, 14, 1, 0, 0, 3, 1, 0),
(119, 11, 14, 2, 0, 0, 3, 1, 0),
(120, 11, 14, 3, 0, 0, 3, 1, 0),
(121, 11, 14, 4, 0, 0, 3, 1, 0),
(122, 11, 14, 5, 0, 0, 3, 1, 0),
(123, 11, 14, 6, 0, 0, 3, 1, 0),
(124, 11, 14, 7, 0, 0, 3, 1, 0),
(125, 11, 14, 8, 0, 0, 3, 1, 0),
(126, 11, 14, 9, 0, 0, 3, 1, 0),
(127, 11, 14, 10, 0, 0, 3, 1, 0),
(128, 11, 14, 11, 0, 0, 3, 1, 0),
(129, 11, 14, 12, 0, 0, 3, 1, 0),
(130, 11, 14, 13, 0, 0, 3, 1, 0),
(131, 11, 14, 14, 0, 0, 3, 1, 0),
(132, 11, 14, 15, 0, 0, 3, 1, 0),
(133, 11, 15, 0, 15, 0, 3, 1, 0),
(134, 11, 15, 3, 15, 0, 3, 1, 0),
(135, 11, 15, 10, 15, 0, 3, 1, 0),
(136, 11, 15, 11, 15, 0, 3, 1, 0),
(137, 11, 16, 0, 12, 0, 3, 1, 0),
(138, 11, 16, 1, 12, 0, 3, 1, 0),
(139, 11, 16, 2, 12, 0, 3, 1, 0),
(140, 11, 16, 3, 12, 0, 3, 1, 0),
(141, 11, 16, 4, 12, 0, 3, 1, 0),
(142, 11, 16, 5, 12, 0, 3, 1, 0),
(143, 11, 16, 6, 12, 0, 3, 1, 0),
(144, 11, 17, 0, 0, 0, 3, 1, 0),
(145, 11, 18, 0, 15, 0, 3, 1, 0),
(146, 11, 18, 1, 15, 0, 3, 1, 0),
(147, 11, 18, 2, 15, 0, 3, 1, 0),
(148, 11, 18, 3, 15, 0, 3, 1, 0),
(149, 11, 18, 4, 15, 0, 3, 1, 0),
(150, 11, 18, 5, 15, 0, 3, 1, 0),
(151, 11, 18, 6, 15, 0, 3, 1, 0),
(152, 11, 18, 7, 15, 0, 3, 1, 0),
(153, 11, 18, 8, 15, 0, 3, 1, 0),
(154, 11, 18, 9, 15, 0, 3, 1, 0),
(155, 11, 18, 10, 15, 0, 3, 1, 0),
(156, 11, 18, 11, 15, 0, 3, 1, 0),
(157, 11, 19, 0, 0, 0, 3, 1, 0),
(158, 11, 19, 1, 0, 0, 3, 1, 0),
(159, 11, 19, 2, 0, 0, 3, 1, 0),
(160, 11, 19, 3, 0, 0, 3, 1, 0),
(161, 11, 20, 0, 5, 0, 0, 1, 0),
(162, 11, 20, 1, 5, 0, 0, 1, 0),
(163, 11, 0, 1, 0, 0, 57, 0, 0),
(164, 11, 0, 2, 0, 0, 57, 0, 0),
(165, 11, 0, 3, 0, 0, 57, 0, 0),
(166, 11, 0, 4, 0, 0, 57, 0, 0),
(167, 11, 0, 5, 0, 0, 57, 0, 0),
(168, 11, 0, 7, 0, 0, 57, 0, 0),
(169, 11, 0, 8, 0, 0, 57, 0, 0),
(170, 11, 0, 11, 0, 0, 57, 0, 0),
(171, 11, 1, 0, 0, 0, 57, 0, 0),
(172, 11, 1, 1, 0, 0, 57, 0, 0),
(173, 11, 1, 3, 0, 0, 57, 0, 0),
(174, 11, 1, 4, 0, 0, 57, 0, 0),
(175, 11, 1, 5, 0, 0, 57, 0, 0),
(176, 11, 1, 6, 0, 0, 57, 0, 0),
(177, 11, 1, 7, 0, 0, 57, 0, 0),
(178, 11, 1, 8, 0, 0, 57, 0, 0),
(179, 11, 1, 11, 0, 0, 57, 0, 0),
(180, 11, 1, 12, 0, 0, 57, 0, 0),
(181, 11, 1, 14, 0, 0, 57, 0, 0),
(182, 11, 2, 9, 2, 0, 57, 0, 0),
(183, 11, 3, 0, 14, 0, 23, 0, 0),
(184, 11, 3, 1, 14, 0, 23, 0, 0),
(185, 11, 3, 2, 14, 0, 23, 0, 0),
(186, 11, 3, 3, 14, 0, 23, 0, 0),
(187, 11, 3, 4, 14, 0, 23, 0, 0),
(188, 11, 3, 5, 14, 0, 23, 0, 0),
(189, 11, 3, 6, 14, 0, 23, 0, 0),
(190, 11, 3, 7, 14, 0, 23, 0, 0),
(191, 11, 3, 8, 14, 0, 23, 0, 0),
(192, 11, 3, 9, 14, 0, 23, 0, 0),
(193, 11, 3, 10, 14, 0, 23, 0, 0),
(194, 11, 3, 11, 14, 0, 23, 0, 0),
(195, 11, 3, 12, 14, 0, 23, 0, 0),
(196, 11, 3, 13, 14, 0, 23, 0, 0),
(197, 11, 3, 14, 14, 0, 23, 0, 0),
(198, 11, 3, 15, 14, 0, 23, 0, 0),
(199, 11, 4, 0, 4, 0, 11, 0, 0),
(200, 11, 4, 2, 4, 0, 11, 0, 0),
(201, 11, 4, 3, 4, 0, 11, 0, 0),
(202, 11, 4, 11, 4, 0, 11, 0, 0),
(203, 11, 4, 14, 4, 0, 11, 0, 0),
(204, 11, 5, 0, 5, 0, 57, 0, 0),
(205, 11, 5, 1, 5, 0, 57, 0, 0),
(206, 11, 5, 2, 5, 0, 57, 0, 0),
(207, 11, 5, 7, 5, 0, 57, 0, 0),
(208, 11, 6, 0, 14, 0, 44, 0, 0),
(209, 11, 6, 1, 14, 0, 44, 0, 0),
(210, 11, 6, 3, 14, 0, 44, 0, 0),
(211, 11, 6, 4, 14, 0, 44, 0, 0),
(212, 11, 6, 5, 14, 0, 44, 0, 0),
(213, 11, 6, 6, 14, 0, 44, 0, 0),
(214, 11, 6, 8, 14, 0, 44, 0, 0),
(215, 11, 6, 9, 14, 0, 44, 0, 0),
(216, 11, 6, 11, 14, 0, 44, 0, 0),
(217, 11, 4, 0, 1, 0, 3, 0, 0),
(218, 11, 4, 3, 4, 0, 3, 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `clothingshops`
--

CREATE TABLE IF NOT EXISTS `clothingshops` (
`Id` int(11) NOT NULL,
  `Name` varchar(512) NOT NULL,
  `Position` text NOT NULL,
  `PedPosition` text NOT NULL,
  `PedRotation` text NOT NULL,
  `Tops` text NOT NULL,
  `Legs` text NOT NULL,
  `Feets` text NOT NULL,
  `Masks` text NOT NULL,
  `Accessories` text NOT NULL,
  `Hats` text NOT NULL,
  `Glasses` text NOT NULL,
  `Ears` text NOT NULL,
  `Watches` text NOT NULL,
  `Bracelets` text NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `clothingshops`
--

INSERT INTO `clothingshops` (`Id`, `Name`, `Position`, `PedPosition`, `PedRotation`, `Tops`, `Legs`, `Feets`, `Masks`, `Accessories`, `Hats`, `Glasses`, `Ears`, `Watches`, `Bracelets`) VALUES
(1, '', '{"X":75.43374,"Y":-1392.72791,"Z":29.3761482}', '{"X":73.91498,"Y":-1393.0553,"Z":29.37613}', '{"X":0.0,"Y":0.0,"Z":-91.4236}', '[{"Id":1,"Slot":11,"Drawable":0,"Texture":0,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":2,"Slot":11,"Drawable":0,"Texture":1,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":true,"Gender":1,"StoreType":0},{"Id":3,"Slot":11,"Drawable":0,"Texture":2,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":4,"Slot":11,"Drawable":0,"Texture":3,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":true,"Gender":1,"StoreType":0},{"Id":5,"Slot":11,"Drawable":0,"Texture":4,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":true,"Gender":1,"StoreType":0},{"Id":6,"Slot":11,"Drawable":0,"Texture":5,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":7,"Slot":11,"Drawable":0,"Texture":6,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":8,"Slot":11,"Drawable":0,"Texture":7,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":9,"Slot":11,"Drawable":0,"Texture":8,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":10,"Slot":11,"Drawable":0,"Texture":9,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":11,"Slot":11,"Drawable":0,"Texture":10,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":12,"Slot":11,"Drawable":0,"Texture":11,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":13,"Slot":11,"Drawable":0,"Texture":12,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":15,"Slot":11,"Drawable":0,"Texture":14,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":14,"Slot":11,"Drawable":0,"Texture":13,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":16,"Slot":11,"Drawable":0,"Texture":15,"Torso":0,"Undershirt":2,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":17,"Slot":11,"Drawable":1,"Texture":0,"Torso":5,"Undershirt":5,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":18,"Slot":11,"Drawable":1,"Texture":1,"Torso":5,"Undershirt":5,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":19,"Slot":11,"Drawable":1,"Texture":2,"Torso":5,"Undershirt":5,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":20,"Slot":11,"Drawable":1,"Texture":4,"Torso":5,"Undershirt":5,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":91,"Slot":11,"Drawable":0,"Texture":0,"Torso":0,"Undershirt":57,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":178,"Slot":11,"Drawable":1,"Texture":8,"Torso":0,"Undershirt":57,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":179,"Slot":11,"Drawable":1,"Texture":11,"Torso":0,"Undershirt":57,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":180,"Slot":11,"Drawable":1,"Texture":12,"Torso":0,"Undershirt":57,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":181,"Slot":11,"Drawable":1,"Texture":14,"Torso":0,"Undershirt":57,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":182,"Slot":11,"Drawable":2,"Texture":9,"Torso":2,"Undershirt":57,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":183,"Slot":11,"Drawable":3,"Texture":0,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":184,"Slot":11,"Drawable":3,"Texture":1,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":185,"Slot":11,"Drawable":3,"Texture":2,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":186,"Slot":11,"Drawable":3,"Texture":3,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":187,"Slot":11,"Drawable":3,"Texture":4,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":188,"Slot":11,"Drawable":3,"Texture":5,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":189,"Slot":11,"Drawable":3,"Texture":6,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":190,"Slot":11,"Drawable":3,"Texture":7,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":191,"Slot":11,"Drawable":3,"Texture":8,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":192,"Slot":11,"Drawable":3,"Texture":9,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":193,"Slot":11,"Drawable":3,"Texture":10,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":194,"Slot":11,"Drawable":3,"Texture":11,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":195,"Slot":11,"Drawable":3,"Texture":12,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":196,"Slot":11,"Drawable":3,"Texture":13,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":197,"Slot":11,"Drawable":3,"Texture":14,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":198,"Slot":11,"Drawable":3,"Texture":15,"Torso":14,"Undershirt":23,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":199,"Slot":11,"Drawable":4,"Texture":0,"Torso":4,"Undershirt":11,"Price":0,"AlreadyBought":true,"Gender":0,"StoreType":0},{"Id":200,"Slot":11,"Drawable":4,"Texture":2,"Torso":4,"Undershirt":11,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":201,"Slot":11,"Drawable":4,"Texture":3,"Torso":4,"Undershirt":11,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":202,"Slot":11,"Drawable":4,"Texture":11,"Torso":4,"Undershirt":11,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0}]', '[{"Id":2,"Slot":4,"Drawable":0,"Texture":0,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":3,"Slot":4,"Drawable":14,"Texture":0,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":1,"Slot":4,"Drawable":0,"Texture":0,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":true,"Gender":0,"StoreType":0},{"Id":4,"Slot":4,"Drawable":6,"Texture":0,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0}]', '[{"Id":1,"Slot":6,"Drawable":1,"Texture":0,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":2,"Slot":6,"Drawable":1,"Texture":0,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0},{"Id":3,"Slot":6,"Drawable":1,"Texture":1,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":false,"Gender":0,"StoreType":0},{"Id":4,"Slot":6,"Drawable":1,"Texture":1,"Torso":0,"Undershirt":0,"Price":0,"AlreadyBought":false,"Gender":1,"StoreType":0}]', '[]', '[]', '[]', '[]', '[]', '[]', '[]');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `custom_blips`
--

CREATE TABLE IF NOT EXISTS `custom_blips` (
`Id` int(11) NOT NULL,
  `PosX` float NOT NULL DEFAULT '0',
  `PosY` float NOT NULL DEFAULT '0',
  `Color` int(11) DEFAULT NULL,
  `Name` varchar(512) NOT NULL,
  `Transparency` int(11) DEFAULT NULL,
  `ShortRange` int(11) DEFAULT NULL,
  `Sprite` int(11) DEFAULT NULL,
  `Scale` float NOT NULL DEFAULT '1',
  `RouteColor` int(11) DEFAULT NULL,
  `Flashing` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `doors`
--

CREATE TABLE IF NOT EXISTS `doors` (
`Id` int(11) NOT NULL,
  `Hash` int(11) NOT NULL DEFAULT '0',
  `Position` varchar(1000) NOT NULL,
  `Locked` int(11) NOT NULL DEFAULT '0',
  `State` float NOT NULL,
  `Name` varchar(512) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `doors`
--

INSERT INTO `doors` (`Id`, `Hash`, `Position`, `Locked`, `State`, `Name`) VALUES
(1, -1148826190, '{"X":82.38156,"Y":-1390.476,"Z":29.52609}', 0, 0, 'Discount Store South Enter Door Right'),
(2, 868499217, '{"X":82.38156,"Y":-1390.752,"Z":29.52609}', 0, 0, 'Discount Store South Enter Door Left'),
(3, -1922281023, '{"X":-715.6154,"Y":-157.2561,"Z":37.67493}', 0, 0, 'Ponsonbys Portola Drive Door Right'),
(4, -1922281023, '{"X":-716.6755,"Y":-155.42,"Z":37.67493}', 0, 0, 'Ponsonbys Portola Drive Door Left'),
(5, -1922281023, '{"X":-1456.201,"Y":-233.3682,"Z":50.05648}', 0, 0, 'Ponsonbys Portola Drive Door Right'),
(6, -1922281023, '{"X":-1454.782,"Y":-231.7927,"Z":50.05649}', 0, 0, 'Ponsonbys Portola Drive Door Left'),
(7, -1922281023, '{"X":-156.439,"Y":-304.4294,"Z":39.99308}', 0, 0, 'Ponsonbys Rockford Plaza Door Right'),
(8, -1922281023, '{"X":-157.1293,"Y":-306.4341,"Z":39.99308}', 0, 0, 'Ponsonbys Rockford Plaza Door Left'),
(9, 1780022985, '{"X":-1201.435,"Y":-776.8566,"Z":17.99184}', 0, 0, 'Sub Urban Prosperity Street Promenade Door'),
(10, 1780022985, '{"X":127.8201,"Y":-211.8274,"Z":55.22751}', 0, 0, 'Sub Urban Hawick Avenue Door'),
(11, 1780022985, '{"X":617.2458,"Y":2751.022,"Z":42.75777}', 0, 0, 'Sub Urban Route 68 Door'),
(12, 1780022985, '{"X":-3167.75,"Y":1055.536,"Z":21.53288}', 0, 0, 'Sub Urban Chumash Plaza Door'),
(13, -1212951353, '{"X":-2973.535,"Y":390.1414,"Z":15.18735}', 0, 0, 'Rob''s Liquor Route 1 Main Enter Door'),
(14, 1417577297, '{"X":-37.33113,"Y":-1108.873,"Z":26.7198}', 0, 0, 'Premium Deluxe Motorsport Parking Doors Right'),
(15, 2059227086, '{"X":-39.13366,"Y":-1108.218,"Z":26.7198}', 0, 0, 'Premium Deluxe Motorsport Parking Doors Left'),
(16, 1417577297, '{"X":-60.54582,"Y":-1094.749,"Z":26.88872}', 0, 0, 'Premium Deluxe Motorsport Main Doors Right'),
(17, 2059227086, '{"X":-59.89302,"Y":-1092.952,"Z":26.88362}', 0, 0, 'Premium Deluxe Motorsport Main Doors Left'),
(18, 320433149, '{"X":434.7479,"Y":-983.2151,"Z":30.83926}', 0, 0, 'Mission Row Police Station Main Enter Doors Right'),
(19, -1215222675, '{"X":434.7479,"Y":-980.6184,"Z":30.83926}', 0, 0, 'Mission Row Police Station Main Enter Doors Left'),
(20, -2023754432, '{"X":469.9679,"Y":-1014.452,"Z":26.53623}', 1, 0, 'Mission Row Police Station Back Enter Doors Right'),
(21, -2023754432, '{"X":467.3716,"Y":-1014.452,"Z":26.53623}', 1, 0, 'Mission Row Police Station Back Enter Doors Left'),
(22, -1033001619, '{"X":463.4782,"Y":-1003.538,"Z":25.00599}', 0, 0, 'Mission Row Police Station Back To Cells Door'),
(23, 631614199, '{"X":461.8065,"Y":-994.4086,"Z":25.06443}', 1, 0, 'Mission Row Police Station Cell Door 1'),
(24, 631614199, '{"X":461.8065,"Y":-997.6583,"Z":25.06443}', 1, 0, 'Mission Row Police Station Cell Door 2'),
(25, 631614199, '{"X":461.8065,"Y":-1001.302,"Z":25.06443}', 1, 0, 'Mission Row Police Station Cell Door 3'),
(26, 631614199, '{"X":464.5701,"Y":-992.6641,"Z":25.06443}', 1, 0, 'Mission Row Police Station Door To Cells Door'),
(27, -340230128, '{"X":464.3613,"Y":-984.678,"Z":43.83443}', 0, 0, 'Mission Row Police Station Roof Door ');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `garages`
--

CREATE TABLE IF NOT EXISTS `garages` (
`Id` int(11) NOT NULL,
  `PosX` float NOT NULL,
  `PosY` float NOT NULL,
  `PosZ` float NOT NULL,
  `PedRotation` float NOT NULL,
  `Spawnpoints` varchar(5000) NOT NULL DEFAULT '[]',
  `FactionType` int(11) NOT NULL DEFAULT '0',
  `Type` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `garages`
--

INSERT INTO `garages` (`Id`, `PosX`, `PosY`, `PosZ`, `PedRotation`, `Spawnpoints`, `FactionType`, `Type`) VALUES
(1, 643.678, 2733.47, 41.9955, 3.93618, '[{"Position":{"X":629.9597,"Y":2724.93774,"Z":41.30155},"Rotation":{"X":-1.6789279,"Y":-0.0180794317,"Z":3.74458146}},{"Position":{"X":624.186768,"Y":2724.287,"Z":41.3119278},"Rotation":{"X":-1.6728996,"Y":0.349029332,"Z":3.876527}},{"Position":{"X":618.062744,"Y":2724.15015,"Z":41.3458633},"Rotation":{"X":-1.69601107,"Y":0.354028434,"Z":2.51521087}},{"Position":{"X":611.87,"Y":2724.012,"Z":41.36497},"Rotation":{"X":-1.05372167,"Y":0.2221052,"Z":2.74042559}},{"Position":{"X":605.672546,"Y":2723.93774,"Z":41.38165},"Rotation":{"X":-0.321339548,"Y":0.2571189,"Z":4.55769825}},{"Position":{"X":623.2246,"Y":2739.047,"Z":41.4590034},"Rotation":{"X":1.54719675,"Y":-0.003663477,"Z":-174.185013}},{"Position":{"X":617.033569,"Y":2738.50024,"Z":41.4433861},"Rotation":{"X":1.591296,"Y":0.3542114,"Z":-178.542358}},{"Position":{"X":610.888062,"Y":2738.03857,"Z":41.445034},"Rotation":{"X":1.91657066,"Y":0.131539568,"Z":-178.801758}},{"Position":{"X":604.832336,"Y":2737.811,"Z":41.4672356},"Rotation":{"X":1.64170349,"Y":-0.281958342,"Z":-176.7922}},{"Position":{"X":598.69,"Y":2736.68286,"Z":41.539608},"Rotation":{"X":0.49415642,"Y":-0.320880532,"Z":-175.6428}},{"Position":{"X":592.572937,"Y":2736.528,"Z":41.54165},"Rotation":{"X":0.563816369,"Y":-0.0404786281,"Z":-175.681534}}]', 0, 0),
(2, 214.034, -808.663, 31.0149, 153.025, '[{"Position":{"X":216.093979,"Y":-801.6743,"Z":30.2954655},"Rotation":{"X":0.9751551,"Y":0.386673629,"Z":68.48637}},{"Position":{"X":218.00145,"Y":-796.6713,"Z":30.2699718},"Rotation":{"X":0.999958634,"Y":0.2803199,"Z":68.09545}},{"Position":{"X":219.848083,"Y":-791.4638,"Z":30.2579155},"Rotation":{"X":0.737632632,"Y":0.006506853,"Z":69.12015}},{"Position":{"X":221.234192,"Y":-786.5174,"Z":30.271759},"Rotation":{"X":0.492127657,"Y":0.0756765157,"Z":67.32428}},{"Position":{"X":223.178452,"Y":-781.4235,"Z":30.2616825},"Rotation":{"X":0.4429713,"Y":0.1346004,"Z":67.3742447}},{"Position":{"X":225.110184,"Y":-776.5132,"Z":30.26905},"Rotation":{"X":0.443451673,"Y":-0.1217122,"Z":68.6688156}},{"Position":{"X":227.105682,"Y":-771.385,"Z":30.2800674},"Rotation":{"X":0.112758428,"Y":0.07174071,"Z":68.0796}},{"Position":{"X":234.11055,"Y":-771.5939,"Z":30.2500286},"Rotation":{"X":-0.3735888,"Y":0.3485295,"Z":-111.732552}},{"Position":{"X":232.619827,"Y":-776.5284,"Z":30.2173843},"Rotation":{"X":-0.443920583,"Y":0.281794131,"Z":-113.766068}},{"Position":{"X":230.8595,"Y":-781.5457,"Z":30.1927013},"Rotation":{"X":-0.686,"Y":0.167563409,"Z":-112.3455}},{"Position":{"X":228.766388,"Y":-786.6677,"Z":30.1870079},"Rotation":{"X":-0.9489452,"Y":0.1940374,"Z":-112.7204}},{"Position":{"X":227.052628,"Y":-791.833,"Z":30.16317},"Rotation":{"X":-0.932133,"Y":0.214721486,"Z":-111.161987}},{"Position":{"X":225.090637,"Y":-796.7498,"Z":30.1554546},"Rotation":{"X":-0.973807752,"Y":0.0472560227,"Z":-112.840057}},{"Position":{"X":223.259888,"Y":-801.801758,"Z":30.1542759},"Rotation":{"X":-1.18440723,"Y":-0.205310851,"Z":-113.30262}},{"Position":{"X":221.464417,"Y":-806.824463,"Z":30.1675224},"Rotation":{"X":-1.28715682,"Y":-0.0792860761,"Z":-112.793167}}]', 0, 0),
(3, -955.651, -2711.77, 14.004, 22.2204, '[{"Position":{"X":-960.4607,"Y":-2709.442,"Z":13.3272676},"Rotation":{"X":-0.125150889,"Y":-0.0008233812,"Z":11.3852434}},{"Position":{"X":-966.8205,"Y":-2710.67651,"Z":13.3294411},"Rotation":{"X":0.0176442545,"Y":0.165699586,"Z":7.51588154}},{"Position":{"X":-973.4313,"Y":-2710.67456,"Z":13.353035},"Rotation":{"X":0.3683363,"Y":0.0630461946,"Z":-2.83907628}},{"Position":{"X":-980.019165,"Y":-2710.00415,"Z":13.3414974},"Rotation":{"X":0.303127944,"Y":-0.146420985,"Z":-14.54465}},{"Position":{"X":-986.003,"Y":-2707.949,"Z":13.3268394},"Rotation":{"X":-0.0890947,"Y":0.000258566928,"Z":-26.0432148}},{"Position":{"X":-961.7796,"Y":-2699.7937,"Z":13.3540993},"Rotation":{"X":-1.25423408,"Y":-2.013444,"Z":151.558273}},{"Position":{"X":-967.556641,"Y":-2696.4104,"Z":13.3269682},"Rotation":{"X":-0.08150501,"Y":-0.0003542463,"Z":148.484711}},{"Position":{"X":-973.519043,"Y":-2693.05957,"Z":13.3264036},"Rotation":{"X":-0.110159181,"Y":0.000750985346,"Z":149.228348}},{"Position":{"X":-979.476868,"Y":-2689.48584,"Z":13.32727},"Rotation":{"X":-0.06219829,"Y":0.0123217152,"Z":152.229767}}]', 0, 0),
(4, 104.803, 6613.77, 32.3978, -131.41, '[{"Position":{"X":118.762756,"Y":6599.44971,"Z":31.5109234},"Rotation":{"X":0.0303069819,"Y":-0.436719239,"Z":-91.51042}},{"Position":{"X":127.102074,"Y":6590.002,"Z":31.4433117},"Rotation":{"X":-0.4103692,"Y":0.0275846086,"Z":-89.35385}},{"Position":{"X":137.0881,"Y":6580.22461,"Z":31.5016632},"Rotation":{"X":-0.970500231,"Y":-0.6406711,"Z":-88.7412338}},{"Position":{"X":145.897339,"Y":6570.768,"Z":31.3921},"Rotation":{"X":-0.9603222,"Y":-0.2741373,"Z":-89.261795}},{"Position":{"X":145.879776,"Y":6601.87744,"Z":31.3464165},"Rotation":{"X":-0.239997089,"Y":0.06538758,"Z":177.583481}},{"Position":{"X":150.524139,"Y":6596.62549,"Z":31.3409576},"Rotation":{"X":-0.06930508,"Y":0.00635446329,"Z":178.767227}}]', 0, 0),
(6, 275.288, -345.293, 45.1734, -17.4249, '[{"Position":{"X":266.944031,"Y":-332.42038,"Z":44.3126831},"Rotation":{"X":0.0170813333,"Y":0.000194788779,"Z":-109.5625}},{"Position":{"X":269.3632,"Y":-326.0133,"Z":44.3165627},"Rotation":{"X":-0.13669759,"Y":0.358596176,"Z":-109.948471}},{"Position":{"X":271.749817,"Y":-319.5448,"Z":44.3132629},"Rotation":{"X":0.0006238667,"Y":0.08335732,"Z":-109.60321}},{"Position":{"X":299.767426,"Y":-329.958557,"Z":44.31256},"Rotation":{"X":0.007442296,"Y":0.0226613842,"Z":69.39221}},{"Position":{"X":297.275024,"Y":-336.4822,"Z":44.31303},"Rotation":{"X":0.000817730033,"Y":0.0678117946,"Z":69.1582947}},{"Position":{"X":294.9349,"Y":-342.952118,"Z":44.31281},"Rotation":{"X":0.0448471755,"Y":-0.000269092154,"Z":70.10886}},{"Position":{"X":292.1626,"Y":-349.283051,"Z":44.3332367},"Rotation":{"X":-0.105146758,"Y":1.261799,"Z":68.608345}}]', 0, 0),
(7, 100.863, -1073.59, 29.3741, 63.0379, '[{"Position":{"X":104.736526,"Y":-1077.61951,"Z":28.6884613},"Rotation":{"X":-0.1315088,"Y":0.000732849934,"Z":-19.5773487}},{"Position":{"X":111.552628,"Y":-1080.36414,"Z":28.68852},"Rotation":{"X":-0.11717353,"Y":0.0035184056,"Z":-20.4154453}},{"Position":{"X":121.368889,"Y":-1080.921,"Z":28.68915},"Rotation":{"X":-0.12678799,"Y":0.1404904,"Z":-0.0102842068}},{"Position":{"X":128.672775,"Y":-1080.89746,"Z":28.6894627},"Rotation":{"X":-0.163061157,"Y":0.0220279824,"Z":-3.18892646}},{"Position":{"X":136.078552,"Y":-1080.98889,"Z":28.6894131},"Rotation":{"X":-0.160063475,"Y":4.13672278E-05,"Z":-0.102412641}},{"Position":{"X":143.61969,"Y":-1081.35815,"Z":28.6881428},"Rotation":{"X":-0.0490881875,"Y":0.00281499024,"Z":2.925668}},{"Position":{"X":150.855423,"Y":-1081.20422,"Z":28.6935253},"Rotation":{"X":0.07639042,"Y":-0.44690755,"Z":3.54711556}},{"Position":{"X":158.229355,"Y":-1081.371,"Z":28.688488},"Rotation":{"X":-0.0912087038,"Y":-8.2418E-05,"Z":-3.89331174}},{"Position":{"X":119.049049,"Y":-1069.24536,"Z":28.6883945},"Rotation":{"X":-0.08670126,"Y":-0.0213723984,"Z":179.3468}},{"Position":{"X":125.686188,"Y":-1069.19885,"Z":28.68831},"Rotation":{"X":-0.0934219658,"Y":0.0257920958,"Z":177.677124}},{"Position":{"X":132.323318,"Y":-1069.366,"Z":28.6893311},"Rotation":{"X":-0.12456046,"Y":-0.0243846774,"Z":177.880676}},{"Position":{"X":138.902451,"Y":-1069.39648,"Z":28.6891632},"Rotation":{"X":-0.105501942,"Y":-0.000764288765,"Z":178.209778}},{"Position":{"X":111.038986,"Y":-1053.17578,"Z":28.6979179},"Rotation":{"X":-0.196339935,"Y":0.215656787,"Z":-114.548683}},{"Position":{"X":108.269783,"Y":-1060.02,"Z":28.68844},"Rotation":{"X":-0.12964502,"Y":0.0298613515,"Z":-117.446083}}]', 0, 0),
(8, -898.297, -153.552, 41.8843, 114.539, '[{"Position":{"X":-901.7994,"Y":-160.012543,"Z":41.3763},"Rotation":{"X":-0.0348992832,"Y":-0.0147135127,"Z":26.2090816}},{"Position":{"X":-908.4532,"Y":-163.183517,"Z":41.3735847},"Rotation":{"X":-0.0366515219,"Y":-0.0173017923,"Z":24.7540684}},{"Position":{"X":-915.01416,"Y":-166.65686,"Z":41.3723221},"Rotation":{"X":-0.0614029653,"Y":0.00119393109,"Z":25.5617352}},{"Position":{"X":-921.621,"Y":-170.165192,"Z":41.3724747},"Rotation":{"X":-0.031427227,"Y":0.0155129228,"Z":26.35189}},{"Position":{"X":-927.9525,"Y":-173.285812,"Z":41.37229},"Rotation":{"X":-0.0578262135,"Y":0.00223133573,"Z":23.60524}},{"Position":{"X":-935.159363,"Y":-177.083725,"Z":41.3721352},"Rotation":{"X":-0.101156794,"Y":0.0300560426,"Z":26.32884}},{"Position":{"X":-942.4661,"Y":-180.704529,"Z":41.3725471},"Rotation":{"X":-0.003846268,"Y":-0.00244084629,"Z":27.0853214}}]', 0, 0),
(9, -1686.61, 58.1014, 64.1467, 156.464, '[{"Position":{"X":-1691.53833,"Y":54.93636,"Z":63.6597061},"Rotation":{"X":1.354147,"Y":-3.947101,"Z":161.508667}},{"Position":{"X":-1696.86707,"Y":59.9440079,"Z":64.04164},"Rotation":{"X":1.596497,"Y":-4.41845751,"Z":162.7036}},{"Position":{"X":-1702.0907,"Y":64.909,"Z":64.4294},"Rotation":{"X":1.72101307,"Y":-4.69267035,"Z":162.921112}},{"Position":{"X":-1685.27844,"Y":49.0375671,"Z":63.1952362},"Rotation":{"X":0.712992132,"Y":-4.01252747,"Z":163.258362}},{"Position":{"X":-1679.98108,"Y":44.358902,"Z":62.8119926},"Rotation":{"X":0.6187459,"Y":-3.75561762,"Z":160.708054}},{"Position":{"X":-1674.62292,"Y":39.4725151,"Z":62.4300232},"Rotation":{"X":0.413796663,"Y":-3.64331412,"Z":163.467651}},{"Position":{"X":-1687.01208,"Y":32.0265732,"Z":63.5087547},"Rotation":{"X":-5.903408,"Y":0.408630222,"Z":-69.4261}},{"Position":{"X":-1692.05432,"Y":37.2044067,"Z":63.83854},"Rotation":{"X":-5.83501673,"Y":0.17163229,"Z":-70.09043}},{"Position":{"X":-1697.36865,"Y":42.091095,"Z":64.2573},"Rotation":{"X":-5.486233,"Y":1.21102071,"Z":-70.06954}},{"Position":{"X":-1702.30383,"Y":47.2383842,"Z":64.65545},"Rotation":{"X":-5.49942446,"Y":1.336364,"Z":-69.56938}},{"Position":{"X":-1707.4353,"Y":52.1260071,"Z":65.07539},"Rotation":{"X":-5.281988,"Y":1.22084594,"Z":-70.78588}},{"Position":{"X":-1712.53345,"Y":57.38811,"Z":65.43053},"Rotation":{"X":-4.935471,"Y":0.8862127,"Z":-69.82093}},{"Position":{"X":-1717.736,"Y":62.42036,"Z":65.808876},"Rotation":{"X":-3.44105816,"Y":1.58486307,"Z":-70.87788}}]', 0, 0),
(10, 638.261, 206.097, 97.6042, -18.1239, '[{"Position":{"X":630.373535,"Y":195.545044,"Z":96.5544052},"Rotation":{"X":-2.90558887,"Y":0.09135471,"Z":-110.843765}},{"Position":{"X":626.977966,"Y":187.9534,"Z":96.66196},"Rotation":{"X":-4.411413,"Y":-0.8523264,"Z":-111.113319}},{"Position":{"X":624.2476,"Y":180.302643,"Z":96.69645},"Rotation":{"X":-5.642883,"Y":0.0235214662,"Z":-110.36953}},{"Position":{"X":621.5141,"Y":172.208984,"Z":96.66404},"Rotation":{"X":-5.463616,"Y":0.271494746,"Z":-108.309845}},{"Position":{"X":618.645752,"Y":164.412674,"Z":96.65241},"Rotation":{"X":-5.67536354,"Y":-0.0006346901,"Z":-111.343651}},{"Position":{"X":645.560059,"Y":162.340912,"Z":94.7017},"Rotation":{"X":4.624371,"Y":0.179059327,"Z":71.1294861}},{"Position":{"X":647.932556,"Y":170.076385,"Z":94.7672348},"Rotation":{"X":6.292381,"Y":-0.0302182324,"Z":70.40752}},{"Position":{"X":651.4319,"Y":177.733185,"Z":94.68996},"Rotation":{"X":6.10732937,"Y":0.6617113,"Z":66.01116}},{"Position":{"X":654.5747,"Y":185.415833,"Z":94.61292},"Rotation":{"X":3.9568224,"Y":-0.660556734,"Z":70.40065}},{"Position":{"X":656.8179,"Y":193.182816,"Z":94.69333},"Rotation":{"X":5.535678,"Y":-0.005539291,"Z":69.31138}}]', 0, 0),
(11, -340.589, 266.33, 85.6795, 18.5593, '[{"Position":{"X":-328.5173,"Y":274.535919,"Z":85.86362},"Rotation":{"X":-3.79106259,"Y":0.4383562,"Z":93.4191055}},{"Position":{"X":-328.6689,"Y":281.436981,"Z":85.78828},"Rotation":{"X":-4.130826,"Y":1.62260592,"Z":94.10551}},{"Position":{"X":-328.6804,"Y":288.966278,"Z":85.67322},"Rotation":{"X":-3.67687345,"Y":0.08222717,"Z":93.06191}},{"Position":{"X":-328.829773,"Y":295.683716,"Z":85.67099},"Rotation":{"X":-3.65992212,"Y":0.32335785,"Z":94.6025848}},{"Position":{"X":-328.558624,"Y":302.238068,"Z":85.69096},"Rotation":{"X":-3.65798616,"Y":0.156334788,"Z":95.18776}},{"Position":{"X":-339.4602,"Y":293.837616,"Z":85.00824},"Rotation":{"X":-3.4590714,"Y":-0.07751767,"Z":91.86307}},{"Position":{"X":-339.979462,"Y":286.900238,"Z":84.9693451},"Rotation":{"X":-3.51982045,"Y":0.110216506,"Z":92.8012543}}]', 0, 0),
(12, 459.042, -1008.04, 28.2631, 83.9009, '[{"Position":{"X":450.559662,"Y":-1015.49805,"Z":27.9899063},"Rotation":{"X":0.822884142,"Y":0.492701441,"Z":92.90861}},{"Position":{"X":451.469482,"Y":-1021.67096,"Z":27.9020824},"Rotation":{"X":0.539578,"Y":3.52987432,"Z":91.1424942}},{"Position":{"X":439.357056,"Y":-1022.38617,"Z":28.144577},"Rotation":{"X":1.14101267,"Y":1.766371,"Z":88.96717}},{"Position":{"X":437.93985,"Y":-1016.28424,"Z":28.241991},"Rotation":{"X":0.7197654,"Y":1.39178288,"Z":91.42592}}]', 1, 0),
(13, 465.208, -982.065, 43.6918, -90.5746, '[{"Position":{"X":449.427124,"Y":-981.000061,"Z":44.08057},"Rotation":{"X":0.155530617,"Y":-0.0209385883,"Z":89.99342}},{"Position":{"X":480.811462,"Y":-982.2873,"Z":41.39686},"Rotation":{"X":0.160310015,"Y":-0.0287659932,"Z":91.4792557}}]', 1, 1),
(14, -1120.36, -2840.96, 13.9458, 152.66, '[{"Position":{"X":-1146.42249,"Y":-2865.34888,"Z":13.6615734},"Rotation":{"X":0.003874709,"Y":-0.00277504884,"Z":-32.5705681}},{"Position":{"X":-1112.77747,"Y":-2884.39185,"Z":13.6625967},"Rotation":{"X":0.0052639707,"Y":-0.0105971107,"Z":-31.0674515}},{"Position":{"X":-1178.64526,"Y":-2846.13477,"Z":13.6621141},"Rotation":{"X":0.00689067,"Y":-0.0058662435,"Z":-31.5924244}}]', 0, 1),
(15, -941.216, -2954.33, 13.9451, 147.025, '[{"Position":{"X":-961.459961,"Y":-2986.139,"Z":15.1140156},"Rotation":{"X":-0.0810889,"Y":8.126531E-05,"Z":60.06318}},{"Position":{"X":-979.091553,"Y":-3019.57642,"Z":15.1146412},"Rotation":{"X":0.161088645,"Y":-0.002154666,"Z":59.80885}}]', 0, 2),
(16, -707.594, -1463.08, 5.04274, 51.5288, '[{"Position":{"X":-745.0727,"Y":-1468.36365,"Z":4.71924639},"Rotation":{"X":0.00399066973,"Y":-0.00646901736,"Z":139.850677}},{"Position":{"X":-724.9215,"Y":-1444.1687,"Z":4.71650743},"Rotation":{"X":0.00545038143,"Y":-0.009692544,"Z":-41.1711731}}]', 0, 1),
(18, -730.746, -1341.33, 1.59522, 47.1339, '[{"Position":{"X":-722.324341,"Y":-1341.16431,"Z":0.08989313},"Rotation":{"X":0.624426544,"Y":0.102965482,"Z":140.906921}},{"Position":{"X":-712.499146,"Y":-1345.34607,"Z":-0.09750092},"Rotation":{"X":1.464099,"Y":-0.3390776,"Z":139.016846}}]', 0, 3),
(19, -500.211, -346.387, 34.5018, -69.6127, '[{"Position":{"X":-488.374084,"Y":-329.9867,"Z":34.1358833},"Rotation":{"X":0.0801260248,"Y":0.296111882,"Z":-96.58295}},{"Position":{"X":-490.095184,"Y":-344.471222,"Z":34.13791},"Rotation":{"X":0.08269235,"Y":-0.08247147,"Z":-97.55476}}]', 2, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `gasstations`
--

CREATE TABLE IF NOT EXISTS `gasstations` (
`Id` int(11) NOT NULL,
  `PosX` float NOT NULL,
  `PosY` float NOT NULL,
  `PosZ` float NOT NULL,
  `GasPumps` varchar(10000) NOT NULL DEFAULT '[]',
  `FuelPrices` varchar(5000) NOT NULL,
  `Storage` varchar(5000) NOT NULL,
  `MoneyStorage` double NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `gasstations`
--

INSERT INTO `gasstations` (`Id`, `PosX`, `PosY`, `PosZ`, `GasPumps`, `FuelPrices`, `Storage`, `MoneyStorage`) VALUES
(1, 179.882, 6602.89, 31.8687, '[{"X":172.616348,"Y":6602.77,"Z":32.0474129},{"X":179.856033,"Y":6604.034,"Z":32.04739},{"X":187.062241,"Y":6605.27637,"Z":32.0474319}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":9848,"Diesel":10000,"Gas":0,"Electricity":0}', 453),
(2, -70.8091, -1762.04, 29.6518, '[{"X":-61.28802,"Y":-1761.76526,"Z":29.261734},{"X":-63.31006,"Y":-1767.03064,"Z":29.2617359},{"X":-71.84124,"Y":-1764.24133,"Z":29.5340614},{"X":-69.84791,"Y":-1758.889,"Z":29.53404},{"X":-77.92497,"Y":-1755.90515,"Z":29.80033},{"X":-79.8839,"Y":-1761.26624,"Z":29.80028}]', '{"Petrol":4.0,"Diesel":3.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(3, 265.098, -1262.26, 29.293, '[{"X":256.526764,"Y":-1254.40686,"Z":29.2929554},{"X":256.365173,"Y":-1260.33911,"Z":29.2929039},{"X":256.445068,"Y":-1267.75562,"Z":29.2929516},{"X":265.180939,"Y":-1267.65955,"Z":29.2929554},{"X":265.070068,"Y":-1260.39258,"Z":29.2929535},{"X":264.86322,"Y":-1252.54114,"Z":29.2929535},{"X":273.981232,"Y":-1254.31372,"Z":29.2929554},{"X":273.899323,"Y":-1260.33923,"Z":29.2927818},{"X":273.8587,"Y":-1267.68042,"Z":29.2928734}]', '{"Petrol":5.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0,"Kerosene":0.0}', '{"Petrol":9614,"Diesel":10000,"Gas":0,"Electricity":0,"Kerosene":0}', 1930),
(4, -525.659, -1210.67, 18.1848, '[{"X":-529.3807,"Y":-1204.35413,"Z":18.3346786},{"X":-524.9934,"Y":-1206.55225,"Z":18.3345718},{"X":-522.124451,"Y":-1207.92615,"Z":18.3335686},{"X":-517.7644,"Y":-1209.96375,"Z":18.3346786},{"X":-521.4238,"Y":-1217.93567,"Z":18.3346653},{"X":-525.8482,"Y":-1215.87415,"Z":18.3346252},{"X":-528.652,"Y":-1214.36084,"Z":18.33391},{"X":-533.121338,"Y":-1212.49512,"Z":18.33468}]', '{"Petrol":4.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(5, -2096.54, -319.182, 13.1686, '[{"X":-2106.09229,"Y":-324.6013,"Z":13.1686115},{"X":-2105.42383,"Y":-320.170563,"Z":13.1686144},{"X":-2104.75586,"Y":-311.940674,"Z":13.1686277},{"X":-2096.25928,"Y":-312.8724,"Z":13.1686277},{"X":-2096.831,"Y":-319.161316,"Z":13.1686268},{"X":-2097.52441,"Y":-325.5428,"Z":13.1686268},{"X":-2088.64722,"Y":-326.26178,"Z":13.1686373},{"X":-2088.206,"Y":-321.980164,"Z":13.1686268},{"X":-2087.13257,"Y":-313.784637,"Z":13.1686354}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(6, 1701.98, 6417.04, 32.764, '[{"X":1706.55225,"Y":6414.127,"Z":32.7640343},{"X":1700.83936,"Y":6416.78564,"Z":32.7640343},{"X":1696.86743,"Y":6418.69043,"Z":32.7640343}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(7, 2005.14, 3774.27, 32.4039, '[{"X":2008.402,"Y":3776.23535,"Z":32.40394},{"X":2006.778,"Y":3775.674,"Z":32.4039726},{"X":2004.30847,"Y":3774.247,"Z":32.4039421},{"X":2002.43567,"Y":3772.61377,"Z":32.4039421}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(8, 264.004, 2607.46, 44.9828, '[{"X":265.441864,"Y":2607.34229,"Z":44.98362},{"X":262.625244,"Y":2606.5835,"Z":44.9923248}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(9, 1181.45, -330.174, 69.3166, '[{"X":1179.857,"Y":-339.356445,"Z":69.3565},{"X":1185.45471,"Y":-338.466919,"Z":69.36456},{"X":1184.072,"Y":-330.030518,"Z":69.3253555},{"X":1178.39685,"Y":-330.844727,"Z":69.3165741},{"X":1176.60168,"Y":-322.0049,"Z":69.3508},{"X":1182.179,"Y":-321.132538,"Z":69.34953}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":9943,"Diesel":10000,"Gas":0,"Electricity":0}', 171),
(10, 1208.99, -1402.41, 35.2242, '[{"X":1210.66931,"Y":-1406.2168,"Z":35.3852463},{"X":1212.37183,"Y":-1404.76135,"Z":35.38523},{"X":1206.40515,"Y":-1398.85547,"Z":35.38554},{"X":1204.91174,"Y":-1400.38623,"Z":35.38555}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(11, 2581.12, 361.622, 108.469, '[{"X":2588.733,"Y":364.987183,"Z":108.6478},{"X":2588.3186,"Y":357.6103,"Z":108.647812},{"X":2580.97925,"Y":357.9045,"Z":108.6478},{"X":2581.10132,"Y":365.347931,"Z":108.647812},{"X":2573.70166,"Y":365.973175,"Z":108.651588},{"X":2573.474,"Y":358.127716,"Z":108.647804}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(12, 2680.1, 3264.3, 55.2443, '[{"X":2678.03467,"Y":3261.44165,"Z":55.4093933},{"X":2681.11768,"Y":3267.34277,"Z":55.40938}]', '{"Petrol":3.0,"Diesel":2.0,"Gas":0.0,"Electricity":1.0}', '{"Petrol":10000,"Diesel":10000,"Gas":0,"Electricity":0}', 0),
(13, -1436.24, -276.592, 46.2077, '[{"X":-1436.171,"Y":-284.016449,"Z":46.3871574},{"X":-1429.74463,"Y":-278.47876,"Z":46.3871651},{"X":-1443.93811,"Y":-275.001923,"Z":46.3941345},{"X":-1437.58362,"Y":-269.4352,"Z":46.3941345}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0}', '{"Petrol":767,"Diesel":1000,"Gas":0,"Electricity":0}', 0),
(14, -1800.32, 802.783, 138.651, '[{"X":-1797.8678,"Y":801.1303,"Z":138.6512},{"X":-1804.16089,"Y":795.0855,"Z":138.685654},{"X":-1808.13171,"Y":799.1896,"Z":138.684555},{"X":-1801.74963,"Y":805.3362,"Z":138.650223},{"X":-1795.22546,"Y":811.394531,"Z":138.689682},{"X":-1791.46313,"Y":807.108948,"Z":138.691635}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0}', '{"Petrol":1000,"Diesel":1000,"Gas":0,"Electricity":0}', 0),
(15, -2556.39, 2334.39, 33.2567, '[{"X":-2557.88965,"Y":2341.58179,"Z":33.25668},{"X":-2553.341,"Y":2341.798,"Z":33.2570267},{"X":-2553.568,"Y":2334.775,"Z":33.2570152},{"X":-2557.58643,"Y":2334.22363,"Z":33.25668},{"X":-2557.05786,"Y":2326.68384,"Z":33.25668},{"X":-2552.29272,"Y":2327.07935,"Z":33.2570152}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0}', '{"Petrol":1000,"Diesel":1000,"Gas":0,"Electricity":0}', 0),
(16, 620.712, 268.846, 103.089, '[{"X":629.6031,"Y":264.743439,"Z":103.277115},{"X":629.687,"Y":273.067261,"Z":103.277122},{"X":620.9874,"Y":273.098816,"Z":103.277122},{"X":620.9406,"Y":264.897583,"Z":103.277122},{"X":612.441956,"Y":265.0582,"Z":103.277122},{"X":612.4197,"Y":273.0447,"Z":103.27713}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0}', '{"Petrol":1000,"Diesel":1000,"Gas":0,"Electricity":0}', 0),
(17, 819.604, -1028.43, 26.4043, '[{"X":827.2089,"Y":-1029.98413,"Z":26.608223},{"X":827.3863,"Y":-1027.21094,"Z":26.6082249},{"X":818.8964,"Y":-1027.1908,"Z":26.4043446},{"X":819.0557,"Y":-1029.98425,"Z":26.40434},{"X":810.5886,"Y":-1030.01208,"Z":26.418848},{"X":810.6011,"Y":-1027.1488,"Z":26.4188519}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0}', '{"Petrol":1000,"Diesel":1000,"Gas":0,"Electricity":0}', 0),
(18, -763.284, -1435.62, 5.0576, '[{"X":-764.9906,"Y":-1451.36414,"Z":5.000522},{"X":-748.153931,"Y":-1431.42871,"Z":5.000523},{"X":-745.1132,"Y":-1434.07825,"Z":5.000523},{"X":-762.4285,"Y":-1453.657,"Z":5.00052166}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0,"Kerosene":8.0}', '{"Petrol":0,"Diesel":0,"Gas":0,"Electricity":0,"Kerosene":100000}', 48),
(19, -1353.07, -2716.63, 13.9449, '[{"X":-1353.06836,"Y":-2716.63281,"Z":13.9449387},{"X":-1349.52393,"Y":-2710.56665,"Z":13.9449463},{"X":-1346.33069,"Y":-2705.19434,"Z":13.9449453},{"X":-1355.97229,"Y":-2721.54175,"Z":13.9449329},{"X":-1360.17615,"Y":-2729.32153,"Z":13.9449339},{"X":-1353.16846,"Y":-2730.404,"Z":13.9449463},{"X":-1348.32385,"Y":-2722.46631,"Z":13.9449453},{"X":-1341.99023,"Y":-2711.65576,"Z":13.94495},{"X":-1352.60718,"Y":-2700.11328,"Z":13.94494},{"X":-1360.21,"Y":-2709.75244,"Z":13.9449282},{"X":-1365.20508,"Y":-2720.337,"Z":13.9449167}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0,"Kerosene":8.0}', '{"Petrol":0,"Diesel":0,"Gas":0,"Electricity":0,"Kerosene":100000}', 0),
(20, -319.678, -1471.6, 30.5486, '[{"X":-322.0405,"Y":-1468.1532,"Z":30.7242031},{"X":-317.648743,"Y":-1475.32263,"Z":30.7242088},{"X":-310.308441,"Y":-1471.00293,"Z":30.7242069},{"X":-314.4407,"Y":-1463.87183,"Z":30.724205},{"X":-329.3741,"Y":-1472.53967,"Z":30.7242069},{"X":-325.192657,"Y":-1479.58582,"Z":30.7242069}]', '{"Petrol":0.0,"Diesel":0.0,"Gas":0.0,"Electricity":0.0,"Kerosene":0.0}', '{"Petrol":1000,"Diesel":1000,"Gas":0,"Electricity":0,"Kerosene":0}', 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `items`
--

CREATE TABLE IF NOT EXISTS `items` (
`Id` int(11) NOT NULL,
  `Name` varchar(512) NOT NULL,
  `Description` varchar(512) NOT NULL,
  `Type` int(11) NOT NULL DEFAULT '0',
  `Weight` int(11) NOT NULL DEFAULT '0',
  `DefaultPrice` double NOT NULL DEFAULT '0',
  `DefaultSellPrice` double NOT NULL DEFAULT '0',
  `Value1` int(11) NOT NULL DEFAULT '0',
  `Value2` int(11) NOT NULL DEFAULT '0',
  `Sellable` int(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `items`
--

INSERT INTO `items` (`Id`, `Name`, `Description`, `Type`, `Weight`, `DefaultPrice`, `DefaultSellPrice`, `Value1`, `Value2`, `Sellable`) VALUES
(1, 'eCola', '', 2, 1, 4, 2, 0, 30, 1),
(2, 'Ego Chaser', '', 1, 0, 2, 1, 20, 0, 1),
(3, 'Meteorite Bar', '', 1, 0, 4, 2, 35, 0, 1),
(4, 'P’s & Q’s', '', 1, 0, 1, 0, 12, 0, 0),
(5, 'Sprunk', '', 2, 0, 4, 2, 0, 30, 1),
(6, 'Flow Water', '', 2, 0, 3, 1, 0, 35, 1),
(7, 'Baked Beans', '', 1, 0, 6, 0, 50, 0, 0),
(8, 'Phat Chips', '', 1, 0, 4, 0, 30, 0, 0),
(9, 'First Aid Kit', '', 3, 4, 15, 0, 20, 0, 0),
(10, 'Small Fuel Canister', '', 6, 10, 20, 0, 20, 0, 0),
(11, 'Repair Kit', '', 4, 10, 30, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `ownedvehicles`
--

CREATE TABLE IF NOT EXISTS `ownedvehicles` (
`ID` int(11) NOT NULL,
  `Owner` varchar(512) NOT NULL,
  `OwnerCharId` int(11) NOT NULL DEFAULT '0',
  `Model` varchar(512) NOT NULL,
  `EngineHealth` int(11) NOT NULL DEFAULT '1000',
  `Fuel` int(11) NOT NULL DEFAULT '10',
  `Faction` int(11) NOT NULL DEFAULT '0',
  `NumberPlate` varchar(20) NOT NULL,
  `PrimaryColor` int(11) DEFAULT '0',
  `SecondaryColor` int(11) NOT NULL DEFAULT '0',
  `Livery` int(11) NOT NULL DEFAULT '0',
  `InUse` int(11) NOT NULL DEFAULT '0',
  `Inventory` varchar(20000) DEFAULT '[]'
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `shops`
--

CREATE TABLE IF NOT EXISTS `shops` (
`Id` int(11) NOT NULL,
  `Owner` varchar(512) NOT NULL,
  `Storage` varchar(20000) NOT NULL,
  `MoneyStorage` double NOT NULL,
  `PosX` float NOT NULL,
  `PosY` float NOT NULL,
  `PosZ` float NOT NULL,
  `PedPosX` float NOT NULL,
  `PedPosY` float NOT NULL,
  `PedPosZ` float NOT NULL,
  `PedRot` float NOT NULL,
  `MenuImage` varchar(512) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `shops`
--

INSERT INTO `shops` (`Id`, `Owner`, `Storage`, `MoneyStorage`, `PosX`, `PosY`, `PosZ`, `PedPosX`, `PedPosY`, `PedPosZ`, `PedRot`, `MenuImage`) VALUES
(1, '', '[{"Id":1,"BuyPrice":10.0,"SellPrice":10.0,"Count":0},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":9},{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":0},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 80, -48.3606, -1757.97, 29.421, -47.313, -1758.71, 29.421, 42.169, 'shopui_title_ltdgasoline.jpg'),
(2, '', '[{"Id":1,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":3,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":4,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":5,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, -1487.6, -378.622, 40.1634, -1486.79, -377.455, 40.1634, 133.844, ''),
(3, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":5,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 1135.67, -982.843, 46.4158, 1134.33, -983.244, 46.4158, -83.6678, ''),
(4, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":4,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":5,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 2555.42, 382.071, 108.623, 2555.67, 380.913, 108.623, -1.793, ''),
(5, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":7,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":1,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 2677.06, 3281.36, 55.2411, 2676.46, 3280.29, 55.2411, -37.035, ''),
(6, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":3,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":5,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 1960.31, 3742.23, 32.3438, 1959.22, 3741.56, 32.3438, -64.1054, ''),
(7, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":0},{"Id":4,"BuyPrice":10.0,"SellPrice":10.0,"Count":2},{"Id":5,"BuyPrice":10.0,"SellPrice":10.0,"Count":2},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 1729.83, 6416.33, 35.0372, 1728.64, 6416.82, 35.0372, -116.155, ''),
(8, '', '[{"Id":1,"BuyPrice":10.0,"SellPrice":10.0,"Count":10},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":10},{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":3,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":5,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 548.087, 2669.42, 42.1565, 549.347, 2669.59, 42.1565, 90.0365, ''),
(9, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":0},{"Id":1,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":3,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 30, 25.7189, -1345.57, 29.497, 24.4252, -1345.61, 29.497, -103.533, ''),
(10, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":7,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 1165.24, 2709.38, 38.1577, 1165.24, 2710.82, 38.1577, 173.656, ''),
(11, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":7,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 0, 1698.06, 4924.5, 42.0636, 1697.18, 4923.48, 42.0636, -41.9544, 'shopui_title_ltdgasoline.jpg'),
(12, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":1},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":2},{"Id":7,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 30, 1392.4, 3605, 34.9809, 1392.06, 3606.09, 34.9809, -167.98, ''),
(13, '', '[{"Id":9,"BuyPrice":10.0,"SellPrice":10.0,"Count":2},{"Id":6,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":7,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":8,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":2,"BuyPrice":10.0,"SellPrice":10.0,"Count":3},{"Id":10,"BuyPrice":42.0,"SellPrice":21.0,"Count":20}]', 10, 1163.36, -322.243, 69.2051, 1164.53, -321.939, 69.2051, 98.7374, 'shopui_title_ltdgasoline.jpg'),
(15, '', '[]', 0, -1821.6, 793.893, 138.116, -1820.7, 794.795, 138.092, 136.998, 'shopui_title_ltdgasoline.jpg'),
(16, '', '[]', 0, -3041.07, 585.188, 7.90893, -3040.98, 583.82, 7.90893, 10.8906, ''),
(17, '', '[]', 0, -3243.87, 1001.34, 12.8307, -3244.53, 1000.2, 12.8307, -32.1194, '');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `vehicleinfo`
--

CREATE TABLE IF NOT EXISTS `vehicleinfo` (
`Id` int(11) NOT NULL,
  `Model` varchar(512) NOT NULL,
  `DisplayName` varchar(512) NOT NULL,
  `MaxFuel` int(11) NOT NULL DEFAULT '100',
  `Fuel` int(11) NOT NULL DEFAULT '0',
  `MaxStorage` int(11) NOT NULL DEFAULT '0',
  `Type` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=507 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `vehicleinfo`
--

INSERT INTO `vehicleinfo` (`Id`, `Model`, `DisplayName`, `MaxFuel`, `Fuel`, `MaxStorage`, `Type`) VALUES
(1, 'Dinghy', 'Dinghy', 100, 1, 45, 5),
(2, 'Dinghy2', 'Dinghy2', 100, 1, 45, 5),
(3, 'Dinghy3', 'Dinghy3', 100, 1, 45, 5),
(4, 'Dinghy4', 'Dinghy4', 100, 1, 45, 5),
(5, 'Jetmax', 'Jetmax', 100, 1, 45, 5),
(6, 'Marquis', 'Marquis', 100, 1, 45, 5),
(7, 'Seashark', 'Seashark', 100, 1, 45, 5),
(8, 'Seashark2', 'Seashark2', 100, 1, 45, 5),
(9, 'Seashark3', 'Seashark3', 100, 1, 45, 5),
(10, 'Speeder', 'Speeder', 100, 1, 45, 5),
(11, 'Speeder2', 'Speeder2', 100, 1, 45, 5),
(12, 'Squalo', 'Squalo', 100, 1, 45, 5),
(13, 'Submersible', 'Submersible', 100, 1, 45, 5),
(14, 'Submersible2', 'Submersible2', 100, 1, 45, 5),
(15, 'Suntrap', 'Suntrap', 100, 1, 45, 5),
(16, 'Toro', 'Toro', 100, 1, 45, 5),
(17, 'Toro2', 'Toro2', 100, 1, 45, 5),
(18, 'Tropic', 'Tropic', 100, 1, 45, 5),
(19, 'Tropic2', 'Tropic2', 100, 1, 45, 5),
(20, 'Tug', 'Tug', 100, 1, 45, 5),
(21, 'Benson', 'Benson', 140, 1, 100, 1),
(22, 'Biff', 'Biff', 140, 1, 100, 1),
(23, 'Hauler', 'Hauler', 140, 1, 100, 1),
(24, 'Hauler2', 'Hauler2', 140, 1, 100, 1),
(25, 'Mule', 'Mule', 140, 1, 100, 1),
(26, 'Mule2', 'Mule2', 140, 1, 100, 1),
(27, 'Mule3', 'Mule3', 140, 1, 100, 1),
(28, 'Packer', 'Packer', 140, 1, 100, 1),
(29, 'Phantom', 'Phantom', 140, 1, 100, 1),
(30, 'Phantom2', 'Phantom2', 140, 1, 100, 1),
(31, 'Phantom3', 'Phantom3', 140, 1, 100, 1),
(32, 'Pounder', 'Pounder', 140, 1, 100, 1),
(33, 'Stockade', 'Stockade', 80, 0, 45, 0),
(34, 'Stockade3', 'Stockade3', 80, 0, 45, 0),
(35, 'Blista', 'Blista', 80, 0, 45, 0),
(36, 'Blista2', 'Blista2', 80, 0, 45, 0),
(37, 'Blista3', 'Blista3', 80, 0, 45, 0),
(38, 'Brioso', 'Brioso', 80, 0, 45, 0),
(39, 'Dilettante', 'Dilettante', 80, 0, 45, 0),
(40, 'Dilettante2', 'Dilettante2', 80, 0, 45, 0),
(41, 'Issi2', 'Issi2', 80, 0, 45, 0),
(42, 'Panto', 'Panto', 80, 0, 45, 0),
(43, 'Prairie', 'Prairie', 80, 0, 45, 0),
(44, 'Rhapsody', 'Rhapsody', 80, 0, 45, 0),
(45, 'CogCabrio', 'CogCabrio', 80, 0, 45, 0),
(46, 'Exemplar', 'Exemplar', 80, 0, 45, 0),
(47, 'F620', 'F620', 80, 0, 45, 0),
(48, 'Felon', 'Felon', 80, 0, 45, 0),
(49, 'Felon2', 'Felon2', 80, 0, 45, 0),
(50, 'Jackal', 'Jackal', 80, 0, 45, 0),
(51, 'Oracle', 'Oracle', 80, 0, 45, 0),
(52, 'Oracle2', 'Oracle2', 80, 0, 45, 0),
(53, 'Sentinel', 'Sentinel', 80, 0, 45, 0),
(54, 'Sentinel2', 'Sentinel2', 80, 0, 45, 0),
(55, 'Windsor', 'Windsor', 80, 0, 45, 0),
(56, 'Windsor2', 'Windsor2', 80, 0, 45, 0),
(57, 'Zion', 'Zion', 80, 0, 45, 0),
(58, 'Zion2', 'Zion2', 80, 0, 45, 0),
(59, 'Bmx', 'Bmx', 100, 0, 0, 6),
(60, 'Cruiser', 'Cruiser', 100, 0, 0, 6),
(61, 'Fixter', 'Fixter', 100, 0, 0, 6),
(62, 'Scorcher', 'Scorcher', 100, 0, 0, 6),
(63, 'TriBike', 'TriBike', 100, 0, 0, 6),
(64, 'TriBike2', 'TriBike2', 100, 0, 0, 6),
(65, 'TriBike3', 'TriBike3', 100, 0, 0, 6),
(66, 'Ambulance', 'Ambulance', 80, 0, 45, 0),
(67, 'FBI', 'FBI', 80, 0, 45, 0),
(68, 'FBI2', 'FBI2', 80, 0, 45, 0),
(69, 'FireTruck', 'FireTruck', 140, 1, 100, 1),
(70, 'PBus', 'PBus', 140, 1, 100, 1),
(71, 'Police', 'Police', 80, 0, 45, 0),
(72, 'Police2', 'Police2', 80, 0, 45, 0),
(73, 'Police3', 'Police3', 80, 0, 45, 0),
(74, 'Police4', 'Police4', 80, 0, 45, 0),
(75, 'PoliceOld1', 'PoliceOld1', 80, 0, 45, 0),
(76, 'PoliceOld2', 'PoliceOld2', 80, 0, 45, 0),
(77, 'PoliceT', 'PoliceT', 80, 0, 45, 0),
(78, 'Policeb', 'Policeb', 35, 0, 20, 2),
(79, 'Polmav', 'Polmav', 220, 4, 0, 3),
(80, 'Pranger', 'Pranger', 80, 0, 45, 0),
(81, 'Predator', 'Predator', 100, 1, 45, 5),
(82, 'Riot', 'Riot', 80, 0, 45, 0),
(83, 'Sheriff', 'Sheriff', 80, 0, 45, 0),
(84, 'Sheriff2', 'Sheriff2', 80, 0, 45, 0),
(85, 'Annihilator', 'Annihilator', 220, 4, 0, 3),
(86, 'Buzzard', 'Buzzard', 220, 4, 0, 3),
(87, 'Buzzard2', 'Buzzard2', 220, 4, 0, 3),
(88, 'Cargobob', 'Cargobob', 220, 4, 0, 3),
(89, 'Cargobob2', 'Cargobob2', 220, 4, 0, 3),
(90, 'Cargobob3', 'Cargobob3', 220, 4, 0, 3),
(91, 'Cargobob4', 'Cargobob4', 220, 4, 0, 3),
(92, 'Frogger', 'Frogger', 220, 4, 0, 3),
(93, 'Frogger2', 'Frogger2', 220, 4, 0, 3),
(94, 'Havok', 'Havok', 220, 4, 0, 3),
(95, 'Hunter', 'Hunter', 220, 4, 0, 3),
(96, 'Maverick', 'Maverick', 220, 4, 0, 3),
(97, 'Savage', 'Savage', 220, 4, 0, 3),
(98, 'Skylift', 'Skylift', 220, 4, 0, 3),
(99, 'Supervolito', 'Supervolito', 220, 4, 0, 3),
(100, 'Supervolito2', 'Supervolito2', 220, 4, 0, 3),
(101, 'Swift', 'Swift', 220, 4, 0, 3),
(102, 'Swift2', 'Swift2', 220, 4, 0, 3),
(103, 'Valkyrie', 'Valkyrie', 220, 4, 0, 3),
(104, 'Valkyrie2', 'Valkyrie2', 220, 4, 0, 3),
(105, 'Volatus', 'Volatus', 220, 4, 0, 3),
(106, 'Bulldozer', 'Bulldozer', 100, 0, 0, 7),
(107, 'Cutter', 'Cutter', 100, 0, 0, 7),
(108, 'Dump', 'Dump', 100, 0, 0, 7),
(109, 'Flatbed', 'Flatbed', 140, 1, 100, 1),
(110, 'Guardian', 'Guardian', 80, 0, 45, 0),
(111, 'Handler', 'Handler', 100, 0, 0, 7),
(112, 'Mixer', 'Mixer', 140, 1, 100, 1),
(113, 'Mixer2', 'Mixer2', 140, 1, 100, 1),
(114, 'Rubble', 'Rubble', 140, 1, 100, 1),
(115, 'TipTruck', 'TipTruck', 140, 1, 100, 1),
(116, 'TipTruck2', 'TipTruck2', 140, 1, 100, 1),
(117, 'APC', 'APC', 100, 0, 0, 7),
(118, 'Barracks', 'Barracks', 140, 1, 100, 1),
(119, 'Barracks2', 'Barracks2', 140, 1, 100, 1),
(120, 'Barracks3', 'Barracks3', 140, 1, 100, 1),
(121, 'Crusader', 'Crusader', 80, 0, 45, 0),
(122, 'Halftrack', 'Halftrack', 100, 0, 0, 7),
(123, 'Rhino', 'Rhino', 100, 0, 0, 7),
(124, 'Trailersmall2', 'Trailersmall2', 100, 0, 0, 7),
(125, 'Akuma', 'Akuma', 35, 0, 20, 2),
(126, 'Avarus', 'Avarus', 35, 0, 20, 2),
(127, 'Bagger', 'Bagger', 35, 0, 20, 2),
(128, 'Bati2', 'Bati2', 35, 0, 20, 2),
(129, 'Bati', 'Bati', 35, 0, 20, 2),
(130, 'BF400', 'BF400', 35, 0, 20, 2),
(131, 'Blazer4', 'Blazer4', 35, 0, 20, 2),
(132, 'CarbonRS', 'CarbonRS', 35, 0, 20, 2),
(133, 'Chimera', 'Chimera', 35, 0, 20, 2),
(134, 'Cliffhanger', 'Cliffhanger', 35, 0, 20, 2),
(135, 'Daemon2', 'Daemon2', 35, 0, 20, 2),
(136, 'Daemon', 'Daemon', 35, 0, 20, 2),
(137, 'Defiler', 'Defiler', 35, 0, 20, 2),
(138, 'Diablous', 'Diablous', 35, 0, 20, 2),
(139, 'Diablous2', 'Diablous2', 35, 0, 20, 2),
(140, 'Double', 'Double', 35, 0, 20, 2),
(141, 'Enduro', 'Enduro', 35, 0, 20, 2),
(142, 'Esskey', 'Esskey', 35, 0, 20, 2),
(143, 'Faggio2', 'Faggio2', 35, 0, 20, 2),
(144, 'Faggio3', 'Faggio3', 35, 0, 20, 2),
(145, 'Faggio', 'Faggio', 35, 0, 20, 2),
(146, 'Fcr2', 'Fcr2', 35, 0, 20, 2),
(147, 'Fcr', 'Fcr', 35, 0, 20, 2),
(148, 'Gargoyle', 'Gargoyle', 35, 0, 20, 2),
(149, 'Hakuchou2', 'Hakuchou2', 35, 0, 20, 2),
(150, 'Hakuchou', 'Hakuchou', 35, 0, 20, 2),
(151, 'Hexer', 'Hexer', 35, 0, 20, 2),
(152, 'Innovation', 'Innovation', 35, 0, 20, 2),
(153, 'Lectro', 'Lectro', 35, 0, 20, 2),
(154, 'Manchez', 'Manchez', 35, 0, 20, 2),
(155, 'Nemesis', 'Nemesis', 35, 0, 20, 2),
(156, 'Nightblade', 'Nightblade', 35, 0, 20, 2),
(157, 'Oppressor', 'Oppressor', 35, 0, 20, 2),
(158, 'PCJ', 'PCJ', 35, 0, 20, 2),
(159, 'Ratbike', 'Ratbike', 35, 0, 20, 2),
(160, 'Ruffian', 'Ruffian', 35, 0, 20, 2),
(161, 'Sanchez2', 'Sanchez2', 35, 0, 20, 2),
(162, 'Sanchez', 'Sanchez', 35, 0, 20, 2),
(163, 'Sanctus', 'Sanctus', 35, 0, 20, 2),
(164, 'Shotaro', 'Shotaro', 35, 0, 20, 2),
(165, 'Sovereign', 'Sovereign', 35, 0, 20, 2),
(166, 'Thrust', 'Thrust', 35, 0, 20, 2),
(167, 'Vader', 'Vader', 35, 0, 20, 2),
(168, 'Vindicator', 'Vindicator', 35, 0, 20, 2),
(169, 'Vortex', 'Vortex', 35, 0, 20, 2),
(170, 'Wolfsbane', 'Wolfsbane', 35, 0, 20, 2),
(171, 'Zombiea', 'Zombiea', 35, 0, 20, 2),
(172, 'Zombieb', 'Zombieb', 35, 0, 20, 2),
(173, 'Zombieb', 'Zombieb', 80, 0, 45, 0),
(174, 'Buccaneer', 'Buccaneer', 80, 0, 45, 0),
(175, 'Buccaneer2', 'Buccaneer2', 80, 0, 45, 0),
(176, 'Chino', 'Chino', 80, 0, 45, 0),
(177, 'Chino2', 'Chino2', 80, 0, 45, 0),
(178, 'Dominator', 'Dominator', 80, 0, 45, 0),
(179, 'Dominator2', 'Dominator2', 80, 0, 45, 0),
(180, 'Dukes', 'Dukes', 80, 0, 45, 0),
(181, 'Dukes2', 'Dukes2', 80, 0, 45, 0),
(182, 'Faction', 'Faction', 80, 0, 45, 0),
(183, 'Faction2', 'Faction2', 80, 0, 45, 0),
(184, 'Faction3', 'Faction3', 80, 0, 45, 0),
(185, 'Gauntlet', 'Gauntlet', 80, 0, 45, 0),
(186, 'Gauntlet2', 'Gauntlet2', 80, 0, 45, 0),
(187, 'Hotknife', 'Hotknife', 80, 0, 45, 0),
(188, 'Lurcher', 'Lurcher', 80, 0, 45, 0),
(189, 'Moonbeam', 'Moonbeam', 80, 0, 45, 0),
(190, 'Moonbeam2', 'Moonbeam2', 80, 0, 45, 0),
(191, 'Nightshade', 'Nightshade', 80, 0, 45, 0),
(192, 'Phoenix', 'Phoenix', 80, 0, 45, 0),
(193, 'Picador', 'Picador', 80, 0, 45, 0),
(194, 'RatLoader', 'RatLoader', 80, 0, 45, 0),
(195, 'RatLoader2', 'RatLoader2', 80, 0, 45, 0),
(196, 'Ruiner', 'Ruiner', 80, 0, 45, 0),
(197, 'Ruiner2', 'Ruiner2', 80, 0, 45, 0),
(198, 'SabreGT', 'SabreGT', 80, 0, 45, 0),
(199, 'SabreGT2', 'SabreGT2', 80, 0, 45, 0),
(200, 'Sadler2', 'Sadler2', 80, 0, 45, 0),
(201, 'SlamVan', 'SlamVan', 80, 0, 45, 0),
(202, 'SlamVan2', 'SlamVan2', 80, 0, 45, 0),
(203, 'SlamVan3', 'SlamVan3', 80, 0, 45, 0),
(204, 'Stalion', 'Stalion', 80, 0, 45, 0),
(205, 'Stalion2', 'Stalion2', 80, 0, 45, 0),
(206, 'Tampa', 'Tampa', 80, 0, 45, 0),
(207, 'Tampa3', 'Tampa3', 80, 0, 45, 0),
(208, 'Vigero', 'Vigero', 80, 0, 45, 0),
(209, 'Virgo', 'Virgo', 80, 0, 45, 0),
(210, 'Virgo2', 'Virgo2', 80, 0, 45, 0),
(211, 'Virgo3', 'Virgo3', 80, 0, 45, 0),
(212, 'Voodoo', 'Voodoo', 80, 0, 45, 0),
(213, 'Voodoo2', 'Voodoo2', 80, 0, 45, 0),
(214, 'BfInjection', 'BfInjection', 80, 0, 45, 0),
(215, 'Bifta', 'Bifta', 80, 0, 45, 0),
(216, 'Blazer', 'Blazer', 35, 0, 20, 2),
(217, 'Blazer2', 'Blazer2', 35, 0, 20, 2),
(218, 'Blazer3', 'Blazer3', 35, 0, 20, 2),
(219, 'Blazer5', 'Blazer5', 35, 0, 20, 2),
(220, 'Bodhi2', 'Bodhi2', 80, 0, 45, 0),
(221, 'Brawler', 'Brawler', 80, 0, 45, 0),
(222, 'DLoader', 'DLoader', 80, 0, 45, 0),
(223, 'Dune', 'Dune', 80, 0, 45, 0),
(224, 'Dune2', 'Dune2', 80, 0, 45, 0),
(225, 'Dune3', 'Dune3', 80, 0, 45, 0),
(226, 'Dune4', 'Dune4', 80, 0, 45, 0),
(227, 'Dune5', 'Dune5', 80, 0, 45, 0),
(228, 'Insurgent', 'Insurgent', 80, 0, 45, 0),
(229, 'Insurgent2', 'Insurgent2', 80, 0, 45, 0),
(230, 'Insurgent3', 'Insurgent3', 80, 0, 45, 0),
(231, 'Kalahari', 'Kalahari', 80, 0, 45, 0),
(232, 'Lguard', 'Lguard', 80, 0, 45, 0),
(233, 'Marshall', 'Marshall', 100, 0, 0, 7),
(234, 'Mesa', 'Mesa', 80, 0, 45, 0),
(235, 'Mesa2', 'Mesa2', 80, 0, 45, 0),
(236, 'Mesa3', 'Mesa3', 80, 0, 45, 0),
(237, 'Monster', 'Monster', 100, 0, 0, 7),
(238, 'Nightshark', 'Nightshark', 80, 0, 45, 0),
(239, 'RancherXL', 'RancherXL', 80, 0, 45, 0),
(240, 'RancherXL2', 'RancherXL2', 80, 0, 45, 0),
(241, 'Rebel', 'Rebel', 80, 0, 45, 0),
(242, 'Rebel2', 'Rebel2', 80, 0, 45, 0),
(243, 'Sandking', 'Sandking', 80, 0, 45, 0),
(244, 'Sandking2', 'Sandking2', 80, 0, 45, 0),
(245, 'Technical', 'Technical', 80, 0, 45, 0),
(246, 'Technical2', 'Technical2', 80, 0, 45, 0),
(247, 'Technical3', 'Technical3', 80, 0, 45, 0),
(248, 'TrophyTruck', 'TrophyTruck', 80, 0, 45, 0),
(249, 'TrophyTruck2', 'TrophyTruck2', 80, 0, 45, 0),
(250, 'AlphaZ1', 'AlphaZ1', 340, 4, 0, 4),
(251, 'Besra', 'Besra', 340, 4, 0, 4),
(252, 'Blimp', 'Blimp', 340, 4, 0, 4),
(253, 'Blimp2', 'Blimp2', 340, 4, 0, 4),
(254, 'Bombushka', 'Bombushka', 340, 4, 0, 4),
(255, 'CargoPlane', 'CargoPlane', 340, 4, 0, 4),
(256, 'Cuban800', 'Cuban800', 340, 4, 0, 4),
(257, 'Dodo', 'Dodo', 340, 4, 0, 4),
(258, 'Duster', 'Duster', 340, 4, 0, 4),
(259, 'Howard', 'Howard', 340, 4, 0, 4),
(260, 'Hydra', 'Hydra', 340, 4, 0, 4),
(261, 'Jet', 'Jet', 340, 4, 0, 4),
(262, 'Lazer', 'Lazer', 340, 4, 0, 4),
(263, 'Luxor', 'Luxor', 340, 4, 0, 4),
(264, 'Luxor2', 'Luxor2', 340, 4, 0, 4),
(265, 'Mammatus', 'Mammatus', 340, 4, 0, 4),
(266, 'Microlight', 'Microlight', 340, 4, 0, 4),
(267, 'Miljet', 'Miljet', 340, 4, 0, 4),
(268, 'Mogul', 'Mogul', 340, 4, 0, 4),
(269, 'Molotok', 'Molotok', 340, 4, 0, 4),
(270, 'Nimbus', 'Nimbus', 340, 4, 0, 4),
(271, 'Nokota', 'Nokota', 340, 4, 0, 4),
(272, 'Pyro', 'Pyro', 340, 4, 0, 4),
(273, 'Rogue', 'Rogue', 340, 4, 0, 4),
(274, 'Seabreeze', 'Seabreeze', 340, 4, 0, 4),
(275, 'Shamal', 'Shamal', 340, 4, 0, 4),
(276, 'Starling', 'Starling', 340, 4, 0, 4),
(277, 'Stunt', 'Stunt', 340, 4, 0, 4),
(278, 'Titan', 'Titan', 340, 4, 0, 4),
(279, 'Tula', 'Tula', 340, 4, 0, 4),
(280, 'Velum', 'Velum', 340, 4, 0, 4),
(281, 'Velum2', 'Velum2', 340, 4, 0, 4),
(282, 'Vestra', 'Vestra', 340, 4, 0, 4),
(283, 'BJXL', 'BJXL', 80, 0, 45, 0),
(284, 'Baller', 'Baller', 80, 0, 45, 0),
(285, 'Baller2', 'Baller2', 80, 0, 45, 0),
(286, 'Baller3', 'Baller3', 80, 0, 45, 0),
(287, 'Baller4', 'Baller4', 80, 0, 45, 0),
(288, 'Baller5', 'Baller5', 80, 0, 45, 0),
(289, 'Baller6', 'Baller6', 80, 0, 45, 0),
(290, 'Cavalcade', 'Cavalcade', 80, 0, 45, 0),
(291, 'Cavalcade2', 'Cavalcade2', 80, 0, 45, 0),
(292, 'Contender', 'Contender', 80, 0, 45, 0),
(293, 'Dubsta', 'Dubsta', 80, 0, 45, 0),
(294, 'Dubsta2', 'Dubsta2', 80, 0, 45, 0),
(295, 'Dubsta3', 'Dubsta3', 80, 0, 45, 0),
(296, 'FQ2', 'FQ2', 80, 0, 45, 0),
(297, 'Granger', 'Granger', 80, 0, 45, 0),
(298, 'Gresley', 'Gresley', 80, 0, 45, 0),
(299, 'Habanero', 'Habanero', 80, 0, 45, 0),
(300, 'Huntley', 'Huntley', 80, 0, 45, 0),
(301, 'Landstalker', 'Landstalker', 80, 0, 45, 0),
(302, 'Patriot', 'Patriot', 80, 0, 45, 0),
(303, 'Radi', 'Radi', 80, 0, 45, 0),
(304, 'Rocoto', 'Rocoto', 80, 0, 45, 0),
(305, 'Seminole', 'Seminole', 80, 0, 45, 0),
(306, 'Serrano', 'Serrano', 80, 0, 45, 0),
(307, 'XLS', 'XLS', 80, 0, 45, 0),
(308, 'XLS2', 'XLS2', 80, 0, 45, 0),
(309, 'Asea', 'Asea', 80, 0, 45, 0),
(310, 'Asea2', 'Asea2', 80, 0, 45, 0),
(311, 'Asterope', 'Asterope', 80, 0, 45, 0),
(312, 'Cog55', 'Cog55', 80, 0, 45, 0),
(313, 'Cog552', 'Cog552', 80, 0, 45, 0),
(314, 'Cognoscenti', 'Cognoscenti', 80, 0, 45, 0),
(315, 'Cognoscenti2', 'Cognoscenti2', 80, 0, 45, 0),
(316, 'Emperor', 'Emperor', 80, 0, 45, 0),
(317, 'Emperor2', 'Emperor2', 80, 0, 45, 0),
(318, 'Emperor3', 'Emperor3', 80, 0, 45, 0),
(319, 'Fugitive', 'Fugitive', 80, 0, 45, 0),
(320, 'Glendale', 'Glendale', 80, 0, 45, 0),
(321, 'Ingot', 'Ingot', 80, 0, 45, 0),
(322, 'Intruder', 'Intruder', 80, 0, 45, 0),
(323, 'Limo2', 'Limo2', 80, 0, 45, 0),
(324, 'Premier', 'Premier', 80, 0, 45, 0),
(325, 'Primo', 'Primo', 80, 0, 45, 0),
(326, 'Primo2', 'Primo2', 80, 0, 45, 0),
(327, 'Regina', 'Regina', 80, 0, 45, 0),
(328, 'Romero', 'Romero', 80, 0, 45, 0),
(329, 'Stanier', 'Stanier', 80, 0, 45, 0),
(330, 'Stratum', 'Stratum', 80, 0, 45, 0),
(331, 'Stretch', 'Stretch', 80, 0, 45, 0),
(332, 'Surge', 'Surge', 80, 0, 45, 0),
(333, 'Tailgater', 'Tailgater', 80, 0, 45, 0),
(334, 'Warrener', 'Warrener', 80, 0, 45, 0),
(335, 'Washington', 'Washington', 80, 0, 45, 0),
(336, 'Airbus', 'Airbus', 140, 1, 100, 1),
(337, 'Brickade', 'Brickade', 140, 1, 100, 1),
(338, 'Bus', 'Bus', 140, 1, 100, 1),
(339, 'Coach', 'Coach', 140, 1, 100, 1),
(340, 'Rallytruck', 'Rallytruck', 140, 1, 100, 1),
(341, 'RentalBus', 'RentalBus', 80, 0, 45, 0),
(342, 'Taxi', 'Taxi', 80, 0, 45, 0),
(343, 'Tourbus', 'Tourbus', 80, 0, 45, 0),
(344, 'Trash', 'Trash', 140, 1, 100, 1),
(345, 'Trash2', 'Trash2', 140, 1, 100, 1),
(346, 'Alpha', 'Alpha', 80, 0, 45, 0),
(347, 'Banshee', 'Banshee', 80, 0, 45, 0),
(348, 'Banshee2', 'Banshee2', 80, 0, 45, 0),
(349, 'BestiaGTS', 'BestiaGTS', 80, 0, 45, 0),
(350, 'Buffalo', 'Buffalo', 80, 0, 45, 0),
(351, 'Buffalo2', 'Buffalo2', 80, 0, 45, 0),
(352, 'Buffalo3', 'Buffalo3', 80, 0, 45, 0),
(353, 'Carbonizzare', 'Carbonizzare', 80, 0, 45, 0),
(354, 'Comet2', 'Comet2', 80, 0, 45, 0),
(355, 'Comet3', 'Comet3', 80, 0, 45, 0),
(356, 'Coquette', 'Coquette', 80, 0, 45, 0),
(357, 'Elegy', 'Elegy', 80, 0, 45, 0),
(358, 'Elegy2', 'Elegy2', 80, 0, 45, 0),
(359, 'Feltzer2', 'Feltzer2', 80, 0, 45, 0),
(360, 'Feltzer3', 'Feltzer3', 80, 0, 45, 0),
(361, 'Furoregt', 'Furoregt', 80, 0, 45, 0),
(362, 'Fusilade', 'Fusilade', 80, 0, 45, 0),
(363, 'Futo', 'Futo', 80, 0, 45, 0),
(364, 'Infernus2', 'Infernus2', 80, 0, 45, 0),
(365, 'Jester', 'Jester', 80, 0, 45, 0),
(366, 'Jester2', 'Jester2', 80, 0, 45, 0),
(367, 'Khamelion', 'Khamelion', 80, 0, 45, 0),
(368, 'Kuruma', 'Kuruma', 80, 0, 45, 0),
(369, 'Kuruma2', 'Kuruma2', 80, 0, 45, 0),
(370, 'Lynx', 'Lynx', 80, 0, 45, 0),
(371, 'Massacro', 'Massacro', 80, 0, 45, 0),
(372, 'Massacro2', 'Massacro2', 80, 0, 45, 0),
(373, 'Ninef', 'Ninef', 80, 0, 45, 0),
(374, 'Ninef2', 'Ninef2', 80, 0, 45, 0),
(375, 'Omnis', 'Omnis', 80, 0, 45, 0),
(376, 'Penumbra', 'Penumbra', 80, 0, 45, 0),
(377, 'RapidGT', 'RapidGT', 80, 0, 45, 0),
(378, 'RapidGT2', 'RapidGT2', 80, 0, 45, 0),
(379, 'Raptor', 'Raptor', 80, 0, 45, 0),
(380, 'Ruston', 'Ruston', 80, 0, 45, 0),
(381, 'Schafter2', 'Schafter2', 80, 0, 45, 0),
(382, 'Schafter3', 'Schafter3', 80, 0, 45, 0),
(383, 'Schafter4', 'Schafter4', 80, 0, 45, 0),
(384, 'Schafter5', 'Schafter5', 80, 0, 45, 0),
(385, 'Schafter6', 'Schafter6', 80, 0, 45, 0),
(386, 'Schwarzer', 'Schwarzer', 80, 0, 45, 0),
(387, 'Seven70', 'Seven70', 80, 0, 45, 0),
(388, 'Specter', 'Specter', 80, 0, 45, 0),
(389, 'Specter2', 'Specter2', 80, 0, 45, 0),
(390, 'Sultan', 'Sultan', 80, 0, 45, 0),
(391, 'Surano', 'Surano', 80, 0, 45, 0),
(392, 'Tampa2', 'Tampa2', 80, 0, 45, 0),
(393, 'Tropos', 'Tropos', 80, 0, 45, 0),
(394, 'Verlierer2', 'Verlierer2', 80, 0, 45, 0),
(395, 'Ardent', 'Ardent', 80, 0, 45, 0),
(396, 'BType', 'BType', 80, 0, 45, 0),
(397, 'BType2', 'BType2', 80, 0, 45, 0),
(398, 'BType3', 'BType3', 80, 0, 45, 0),
(399, 'Casco', 'Casco', 80, 0, 45, 0),
(400, 'Cheetah2', 'Cheetah2', 80, 0, 45, 0),
(401, 'Coquette2', 'Coquette2', 80, 0, 45, 0),
(402, 'Coquette3', 'Coquette3', 80, 0, 45, 0),
(403, 'JB700', 'JB700', 80, 0, 45, 0),
(404, 'Mamba', 'Mamba', 80, 0, 45, 0),
(405, 'Manana', 'Manana', 80, 0, 45, 0),
(406, 'Monroe', 'Monroe', 80, 0, 45, 0),
(407, 'Peyote', 'Peyote', 80, 0, 45, 0),
(408, 'Pigalle', 'Pigalle', 80, 0, 45, 0),
(409, 'RapidGT3', 'RapidGT3', 80, 0, 45, 0),
(410, 'Retinue', 'Retinue', 80, 0, 45, 0),
(411, 'Stinger', 'Stinger', 80, 0, 45, 0),
(412, 'StingerGT', 'StingerGT', 80, 0, 45, 0),
(413, 'Torero', 'Torero', 80, 0, 45, 0),
(414, 'Tornado', 'Tornado', 80, 0, 45, 0),
(415, 'Tornado2', 'Tornado2', 80, 0, 45, 0),
(416, 'Tornado3', 'Tornado3', 80, 0, 45, 0),
(417, 'Tornado4', 'Tornado4', 80, 0, 45, 0),
(418, 'Tornado5', 'Tornado5', 80, 0, 45, 0),
(419, 'Tornado6', 'Tornado6', 80, 0, 45, 0),
(420, 'ZType', 'ZType', 80, 0, 45, 0),
(421, 'Adder', 'Adder', 80, 0, 45, 0),
(422, 'Bullet', 'Bullet', 80, 0, 45, 0),
(423, 'Cheetah', 'Cheetah', 80, 0, 45, 0),
(424, 'Cyclone', 'Cyclone', 80, 0, 45, 0),
(425, 'EntityXF', 'EntityXF', 80, 0, 45, 0),
(426, 'FMJ', 'FMJ', 80, 0, 45, 0),
(427, 'GP1', 'GP1', 80, 0, 45, 0),
(428, 'Infernus', 'Infernus', 80, 0, 45, 0),
(429, 'LE7B', 'LE7B', 80, 0, 45, 0),
(430, 'Nero', 'Nero', 80, 0, 45, 0),
(431, 'Nero2', 'Nero2', 80, 0, 45, 0),
(432, 'Osiris', 'Osiris', 80, 0, 45, 0),
(433, 'Penetrator', 'Penetrator', 80, 0, 45, 0),
(434, 'Pfister811', 'Pfister811', 80, 0, 45, 0),
(435, 'Prototipo', 'Prototipo', 80, 0, 45, 0),
(436, 'Reaper', 'Reaper', 80, 0, 45, 0),
(437, 'Sheava', 'Sheava', 80, 0, 45, 0),
(438, 'SultanRS', 'SultanRS', 80, 0, 45, 0),
(439, 'Superd', 'Superd', 80, 0, 45, 0),
(440, 'T20', 'T20', 80, 0, 45, 0),
(441, 'Tempesta', 'Tempesta', 80, 0, 45, 0),
(442, 'Turismo2', 'Turismo2', 80, 0, 45, 0),
(443, 'Turismor', 'Turismor', 80, 0, 45, 0),
(444, 'Tyrus', 'Tyrus', 80, 0, 45, 0),
(445, 'Vacca', 'Vacca', 80, 0, 45, 0),
(446, 'Vagner', 'Vagner', 80, 0, 45, 0),
(447, 'Vigilante', 'Vigilante', 80, 0, 45, 0),
(448, 'Visione', 'Visione', 80, 0, 45, 0),
(449, 'Voltic', 'Voltic', 80, 0, 45, 0),
(450, 'Voltic2', 'Voltic2', 80, 0, 45, 0),
(451, 'Zentorno', 'Zentorno', 80, 0, 45, 0),
(452, 'Italigtb', 'Italigtb', 80, 0, 45, 0),
(453, 'Italigtb2', 'Italigtb2', 80, 0, 45, 0),
(454, 'XA21', 'XA21', 80, 0, 45, 0),
(455, 'Airtug', 'Airtug', 100, 0, 0, 7),
(456, 'Caddy', 'Caddy', 100, 0, 0, 7),
(457, 'Caddy2', 'Caddy2', 100, 0, 0, 7),
(458, 'Caddy3', 'Caddy3', 100, 0, 0, 7),
(459, 'Docktug', 'Docktug', 100, 0, 0, 7),
(460, 'Forklift', 'Forklift', 100, 0, 0, 7),
(461, 'Mower', 'Mower', 100, 0, 0, 7),
(462, 'Ripley', 'Ripley', 140, 1, 100, 1),
(463, 'Sadler', 'Sadler', 80, 0, 45, 0),
(464, 'Scrap', 'Scrap', 140, 1, 100, 1),
(465, 'TowTruck', 'TowTruck', 140, 1, 100, 1),
(466, 'TowTruck2', 'TowTruck2', 140, 1, 100, 1),
(467, 'Tractor', 'Tractor', 140, 1, 100, 1),
(468, 'Tractor2', 'Tractor2', 140, 1, 100, 1),
(469, 'Tractor3', 'Tractor3', 140, 1, 100, 1),
(470, 'UtilliTruck', 'UtilliTruck', 140, 1, 100, 1),
(471, 'UtilliTruck3', 'UtilliTruck3', 80, 0, 45, 0),
(472, 'UtilliTruck2', 'UtilliTruck2', 140, 1, 100, 1),
(473, 'Bison', 'Bison', 80, 0, 45, 0),
(474, 'Bison2', 'Bison2', 80, 0, 45, 0),
(475, 'Bison3', 'Bison3', 80, 0, 45, 0),
(476, 'BobcatXL', 'BobcatXL', 80, 0, 45, 0),
(477, 'Boxville', 'Boxville', 80, 1, 45, 0),
(478, 'Boxville2', 'Boxville2', 80, 1, 45, 0),
(479, 'Boxville3', 'Boxville3', 80, 1, 45, 0),
(480, 'Boxville4', 'Boxville4', 80, 1, 45, 0),
(481, 'Boxville5', 'Boxville5', 100, 1, 0, 7),
(482, 'Burrito', 'Burrito', 80, 0, 45, 0),
(483, 'Burrito2', 'Burrito2', 80, 0, 45, 0),
(484, 'Burrito3', 'Burrito3', 80, 0, 45, 0),
(485, 'Burrito4', 'Burrito4', 80, 0, 45, 0),
(486, 'Burrito5', 'Burrito5', 80, 0, 45, 0),
(487, 'Camper', 'Camper', 80, 0, 45, 0),
(488, 'GBurrito', 'GBurrito', 80, 0, 45, 0),
(489, 'GBurrito2', 'GBurrito2', 80, 0, 45, 0),
(490, 'Journey', 'Journey', 80, 0, 45, 0),
(491, 'Minivan', 'Minivan', 80, 0, 45, 0),
(492, 'Minivan2', 'Minivan2', 80, 0, 45, 0),
(493, 'Paradise', 'Paradise', 80, 0, 45, 0),
(494, 'Pony', 'Pony', 80, 0, 45, 0),
(495, 'Pony2', 'Pony2', 80, 0, 45, 0),
(496, 'Rumpo', 'Rumpo', 80, 0, 45, 0),
(497, 'Rumpo2', 'Rumpo2', 80, 0, 45, 0),
(498, 'Rumpo3', 'Rumpo3', 80, 0, 45, 0),
(499, 'Speedo', 'Speedo', 80, 0, 45, 0),
(500, 'Speedo2', 'Speedo2', 80, 0, 45, 0),
(501, 'Surfer', 'Surfer', 80, 0, 45, 0),
(502, 'Surfer2', 'Surfer2', 80, 0, 45, 0),
(503, 'Taco', 'Taco', 80, 1, 45, 0),
(504, 'Youga', 'Youga', 80, 0, 45, 0),
(505, 'Youga2', 'Youga2', 80, 0, 45, 0),
(506, 'Blade', 'Blade', 80, 0, 45, 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `vehicleshops`
--

CREATE TABLE IF NOT EXISTS `vehicleshops` (
`Id` int(11) NOT NULL,
  `Position` varchar(1000) DEFAULT NULL,
  `PedHeading` float DEFAULT '0',
  `PreviewPosition` varchar(1000) DEFAULT NULL,
  `PreviewRotation` varchar(1000) DEFAULT NULL,
  `PreviewCamera` varchar(1000) DEFAULT NULL,
  `VehType` int(11) DEFAULT '0',
  `SellingVehicles` varchar(10000) DEFAULT NULL,
  `BlipSprite` int(11) DEFAULT '0',
  `Name` varchar(512) DEFAULT NULL,
  `FactionType` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Daten für Tabelle `vehicleshops`
--

INSERT INTO `vehicleshops` (`Id`, `Position`, `PedHeading`, `PreviewPosition`, `PreviewRotation`, `PreviewCamera`, `VehType`, `SellingVehicles`, `BlipSprite`, `Name`, `FactionType`) VALUES
(1, '{"X":-215.528473,"Y":6218.86328,"Z":31.4915619}', -135.278, '{"X":-217.755112,"Y":6200.064,"Z":30.9862747}', '{"X":-0.1286262,"Y":0.000541980844,"Z":-135.777512}', '{"X":-208.764435,"Y":6197.4873,"Z":33.48564}', 0, '{"Adder":10.0,"XA21":10.0,"Zentorno":10.0}', 225, 'Goldener Hahn', 0),
(2, '{"X":-31.76771,"Y":-1113.531,"Z":26.4223385}', 9.88338, '{"X":-43.3405,"Y":-1095.87683,"Z":25.9185848}', '{"X":-0.0755042657,"Y":0.006221913,"Z":131.440735}', '{"X":-42.42895,"Y":-1100.76685,"Z":28.4223537}', 0, '{"Banshee":10.0,"Alpha":10.0,"BestiaGTS":10.0,"Buffalo":10.0,"Carbonizzare":10.0,"Comet2":10.0,"Coquette":10.0,"Elegy":10.0,"Feltzer2":10.0,"Feltzer3":10.0,"Furoregt":10.0,"Fusilade":10.0,"Futo":10.0,"Infernus2":10.0,"Jester":10.0,"Khamelion":10.0,"Kuruma":10.0,"Massacro":10.0,"Ninef":10.0,"Ninef2":10.0,"Penumbra":10.0,"RapidGT":10.0,"RapidGT2":10.0,"Schafter2":10.0,"Schwarzer":10.0,"Seven70":10.0,"Sultan":10.0,"Surano":10.0,"Verlierer2":10.0}', 225, 'premium', 0),
(3, '{"X":-803.0818,"Y":-223.899078,"Z":37.225193}', 119.58, '{"X":-815.7627,"Y":-238.7447,"Z":36.70217}', '{"X":-0.506301,"Y":0.3108064,"Z":-148.618225}', '{"X":-807.288,"Y":-242.04097,"Z":39.18343}', 0, '{"adder":10.0,"bullet":10.0,"cheetah":10.0,"cyclone":10.0,"entityxf":10.0,"fmj":10.0,"gp1":10.0,"infernus":10.0,"le7b":10.0,"nero":10.0,"nero2":10.0,"osiris":10.0,"penetrator":10.0,"pfister811":10.0,"prototipo":10.0,"reaper":10.0,"sheava":10.0,"sultanrs":10.0,"superd":10.0,"t20":10.0,"tempesta":10.0,"turismo2":10.0,"turismor":10.0,"tyrus":10.0,"vacca":10.0,"vagner":10.0,"visione":10.0,"voltic":10.0,"zentorno":10.0,"italigtb":10.0,"italigtb2":10.0,"xa21":10.0}', 225, 'luxury', 0),
(4, '{"X":452.5385,"Y":-988.3308,"Z":26.67423}', -1.16462, '{"X":426.41864,"Y":-977.4008,"Z":30.2079716}', '{"X":-0.148375556,"Y":-0.0124618364,"Z":179.7591}', '{"X":430.7453,"Y":-983.0298,"Z":32.710434}', 0, '{"Police":10.0,"Police2":10.0,"Police3":10.0,"Police4":10.0,"PoliceT":10.0,"Policeb":10.0,"Polmav":10.0,"Pranger":10.0,"Riot":10.0,"Sheriff":10.0,"Sheriff2":10.0}', 225, 'MissionRow', 1),
(5, '{"X":-497.3525,"Y":-325.0868,"Z":34.50161}', -149.494, '{"X":-478.949463,"Y":-338.0574,"Z":33.8826447}', '{"X":0.00798739,"Y":-0.0573234819,"Z":170.656281}', '{"X":-484.8601,"Y":-345.080444,"Z":36.3777466}', 0, '{"Ambulance":5.0}', 225, 'EMS', 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `whitelist`
--

CREATE TABLE IF NOT EXISTS `whitelist` (
`Id` int(11) NOT NULL,
  `SocialClubName` varchar(512) NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `accounts`
--
ALTER TABLE `accounts`
 ADD PRIMARY KEY (`Id`), ADD KEY `Id` (`Id`);

--
-- Indizes für die Tabelle `atms`
--
ALTER TABLE `atms`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `characters`
--
ALTER TABLE `characters`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `clothes_feets`
--
ALTER TABLE `clothes_feets`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `clothes_legs`
--
ALTER TABLE `clothes_legs`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `clothes_outfits`
--
ALTER TABLE `clothes_outfits`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `clothes_tops`
--
ALTER TABLE `clothes_tops`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `clothingshops`
--
ALTER TABLE `clothingshops`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `custom_blips`
--
ALTER TABLE `custom_blips`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `doors`
--
ALTER TABLE `doors`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `garages`
--
ALTER TABLE `garages`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `gasstations`
--
ALTER TABLE `gasstations`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `items`
--
ALTER TABLE `items`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `ownedvehicles`
--
ALTER TABLE `ownedvehicles`
 ADD PRIMARY KEY (`ID`);

--
-- Indizes für die Tabelle `shops`
--
ALTER TABLE `shops`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `vehicleinfo`
--
ALTER TABLE `vehicleinfo`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `vehicleshops`
--
ALTER TABLE `vehicleshops`
 ADD PRIMARY KEY (`Id`);

--
-- Indizes für die Tabelle `whitelist`
--
ALTER TABLE `whitelist`
 ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `accounts`
--
ALTER TABLE `accounts`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=1;
--
-- AUTO_INCREMENT für Tabelle `atms`
--
ALTER TABLE `atms`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=83;
--
-- AUTO_INCREMENT für Tabelle `characters`
--
ALTER TABLE `characters`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=1;
--
-- AUTO_INCREMENT für Tabelle `clothes_feets`
--
ALTER TABLE `clothes_feets`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT für Tabelle `clothes_legs`
--
ALTER TABLE `clothes_legs`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT für Tabelle `clothes_outfits`
--
ALTER TABLE `clothes_outfits`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT für Tabelle `clothes_tops`
--
ALTER TABLE `clothes_tops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=219;
--
-- AUTO_INCREMENT für Tabelle `clothingshops`
--
ALTER TABLE `clothingshops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT für Tabelle `custom_blips`
--
ALTER TABLE `custom_blips`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `doors`
--
ALTER TABLE `doors`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=28;
--
-- AUTO_INCREMENT für Tabelle `garages`
--
ALTER TABLE `garages`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT für Tabelle `gasstations`
--
ALTER TABLE `gasstations`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT für Tabelle `items`
--
ALTER TABLE `items`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT für Tabelle `ownedvehicles`
--
ALTER TABLE `ownedvehicles`
MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=1;
--
-- AUTO_INCREMENT für Tabelle `shops`
--
ALTER TABLE `shops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT für Tabelle `vehicleinfo`
--
ALTER TABLE `vehicleinfo`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=507;
--
-- AUTO_INCREMENT für Tabelle `vehicleshops`
--
ALTER TABLE `vehicleshops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT für Tabelle `whitelist`
--
ALTER TABLE `whitelist`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=1;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
