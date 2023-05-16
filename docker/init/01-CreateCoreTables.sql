CREATE TABLE `GameImages` (
	`GameID` BIGINT(20) NOT NULL,
	`ImageType` VARCHAR(128) NOT NULL COLLATE 'utf8mb4_general_ci',
	`ImageOrder` SMALLINT(6) NOT NULL DEFAULT '256',
	`ImagePath` VARCHAR(512) NOT NULL COLLATE 'utf8mb4_general_ci'
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB;

CREATE TABLE `GameLocations` (
	`LocationID` INT(11) NOT NULL AUTO_INCREMENT,
	`PlatformID` INT(11) NOT NULL,
	`LocationName` VARCHAR(256) NOT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`LocationID`) USING BTREE,
	INDEX `PlatformID` (`PlatformID`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB;

CREATE TABLE `GamePlatforms` (
	`PlatformID` INT(11) NOT NULL AUTO_INCREMENT,
	`PlatformName` VARCHAR(128) NOT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`PlatformID`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB;

CREATE TABLE `GameReceipts` (
	`ReceiptID` BIGINT(20) NOT NULL AUTO_INCREMENT,
	`Store` VARCHAR(256) NOT NULL COLLATE 'utf8mb4_general_ci',
	`ReceiptNumber` VARCHAR(64) NOT NULL COLLATE 'utf8mb4_general_ci',
	`ReceiptDate` DATE NULL DEFAULT NULL,
	`ReceiptName` VARCHAR(128) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`ReceiptUrl` VARCHAR(512) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`ReceiptScanned` BIT(1) NOT NULL DEFAULT b'0',
	PRIMARY KEY (`ReceiptID`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB;

CREATE TABLE `Games` (
	`GameID` BIGINT(20) NOT NULL AUTO_INCREMENT,
	`ReceiptID` INT(11) NULL DEFAULT NULL,
	`PlatformID` INT(11) NOT NULL,
	`LocationID` INT(11) NOT NULL,
	`HasGameBox` BIT(1) NOT NULL DEFAULT b'0',
	`HasProtection` BIT(1) NOT NULL DEFAULT b'0',
	`GameRating` TINYINT(4) NOT NULL DEFAULT '0',
	`GamePrice` DOUBLE NOT NULL DEFAULT '0',
	`GameName` VARCHAR(256) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`GameCaseLocation` VARCHAR(32) NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`GameID`) USING BTREE,
	INDEX `PlatformID` (`PlatformID`) USING BTREE,
	INDEX `LocationID` (`LocationID`) USING BTREE,
	INDEX `ReceiptID` (`ReceiptID`) USING BTREE
)
COLLATE='utf8mb4_general_ci'
ENGINE=InnoDB;

CREATE TABLE `GameSales` (
	`GameID` BIGINT(20) NOT NULL,
	`SaleDate` DATE NOT NULL,
	`SaleAmount` DOUBLE NOT NULL DEFAULT '0',
	INDEX `GameID` (`GameID`) USING BTREE
)
COLLATE='utf8mb4_general_ci';
