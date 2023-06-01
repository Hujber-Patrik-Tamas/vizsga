create database futoverseny;

use futoverseny;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `TavolsagModel` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_TavolsagModel` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Versenyzok` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Rajtszam` int NOT NULL,
    `Nev` longtext CHARACTER SET utf8mb4 NOT NULL,
    `SzuletesiDatum` datetime(6) NULL,
    `Neme` longtext CHARACTER SET utf8mb4 NOT NULL,
    `TavolsagId` int NOT NULL,
    `Korosztaly` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Versenyzok` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Versenyzok_TavolsagModel_TavolsagId` FOREIGN KEY (`TavolsagId`) REFERENCES `TavolsagModel` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

INSERT INTO `TavolsagModel` (`Id`, `Name`)
VALUES (1, '5 km');
INSERT INTO `TavolsagModel` (`Id`, `Name`)
VALUES (2, '10 km');
INSERT INTO `TavolsagModel` (`Id`, `Name`)
VALUES (3, 'félmaraton');
INSERT INTO `TavolsagModel` (`Id`, `Name`)
VALUES (4, 'maraton');

INSERT INTO `Versenyzok` (`Id`, `Korosztaly`, `Neme`, `Nev`, `Rajtszam`, `SzuletesiDatum`, `TavolsagId`)
VALUES (1, 'senior', 'ffi', 'Béla', 5, NULL, 4);

INSERT INTO `Versenyzok` (`Id`, `Korosztaly`, `Neme`, `Nev`, `Rajtszam`, `SzuletesiDatum`, `TavolsagId`)
VALUES (2, 'junior', 'nő', 'Tünde', 7, NULL, 1);

CREATE UNIQUE INDEX `IX_TavolsagModel_Name` ON `TavolsagModel` (`Name`);

CREATE UNIQUE INDEX `IX_Versenyzok_Rajtszam` ON `Versenyzok` (`Rajtszam`);

CREATE INDEX `IX_Versenyzok_TavolsagId` ON `Versenyzok` (`TavolsagId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20230328063522_init', '6.0.7');

COMMIT;

