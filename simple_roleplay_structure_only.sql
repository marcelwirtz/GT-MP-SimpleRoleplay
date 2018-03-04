-- phpMyAdmin SQL Dump
-- version 4.2.12deb2+deb8u2
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Erstellungszeit: 22. Nov 2017 um 00:36
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

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `clothes_outfits`
--

CREATE TABLE IF NOT EXISTS `clothes_outfits` (
`Id` int(11) NOT NULL,
  `Outfit` varchar(2000) NOT NULL DEFAULT '{}'
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

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
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `atms`
--
ALTER TABLE `atms`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `characters`
--
ALTER TABLE `characters`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `clothes_feets`
--
ALTER TABLE `clothes_feets`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `clothes_legs`
--
ALTER TABLE `clothes_legs`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `clothes_outfits`
--
ALTER TABLE `clothes_outfits`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `clothes_tops`
--
ALTER TABLE `clothes_tops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `clothingshops`
--
ALTER TABLE `clothingshops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `custom_blips`
--
ALTER TABLE `custom_blips`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `doors`
--
ALTER TABLE `doors`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `garages`
--
ALTER TABLE `garages`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `gasstations`
--
ALTER TABLE `gasstations`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `items`
--
ALTER TABLE `items`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `ownedvehicles`
--
ALTER TABLE `ownedvehicles`
MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `shops`
--
ALTER TABLE `shops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `vehicleinfo`
--
ALTER TABLE `vehicleinfo`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `vehicleshops`
--
ALTER TABLE `vehicleshops`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `whitelist`
--
ALTER TABLE `whitelist`
MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
