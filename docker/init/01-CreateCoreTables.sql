CREATE TABLE IF NOT EXISTS `Games` (
  `GameID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ReceiptID` int(11) DEFAULT NULL,
  `PlatformID` int(11) NOT NULL,
  `LocationID` int(11) NOT NULL,
  `HasGameBox` bit(1) NOT NULL DEFAULT b'0',
  `HasProtection` bit(1) NOT NULL DEFAULT b'0',
  `GameRating` tinyint(4) NOT NULL DEFAULT 0,
  `GamePrice` double NOT NULL DEFAULT 0,
  `GameName` varchar(256) DEFAULT NULL,
  `GameCaseLocation` varchar(32) DEFAULT '',
  PRIMARY KEY (`GameID`) USING BTREE,
  KEY `PlatformID` (`PlatformID`) USING BTREE,
  KEY `ReceiptID` (`ReceiptID`),
  KEY `LocationID` (`LocationID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Images` (
  `GameID` bigint(20) NOT NULL,
  `ImageType` varchar(128) NOT NULL,
  `ImageOrder` smallint(6) NOT NULL DEFAULT 256,
  `ImagePath` varchar(512) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Locations` (
  `LocationID` int(11) NOT NULL AUTO_INCREMENT,
  `PlatformID` int(11) NOT NULL,
  `LocationName` varchar(256) NOT NULL,
  PRIMARY KEY (`LocationID`) USING BTREE,
  KEY `PlatformID` (`PlatformID`) USING BTREE
) ENGINE=InnoDB CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Platforms` (
  `PlatformID` int(11) NOT NULL AUTO_INCREMENT,
  `PlatformName` varchar(128) NOT NULL,
  PRIMARY KEY (`PlatformID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `Receipts` (
	`ReceiptID` INT(11) NOT NULL AUTO_INCREMENT,
	`HaveReceipt` BIT(1) NOT NULL DEFAULT b'0',
	`ReceiptScanned` BIT(1) NOT NULL DEFAULT b'0',
	`ReceiptAssociated` BIT(1) NOT NULL DEFAULT b'0',
	`ReceiptDate` DATE NULL DEFAULT NULL,
	`Store` VARCHAR(256) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`ReceiptNumber` VARCHAR(64) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`ReceiptUrl` VARCHAR(512) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	`ReceiptName` VARCHAR(32) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',
	PRIMARY KEY (`ReceiptID`) USING BTREE
)
COLLATE='utf8mb4_general_ci';

CREATE TABLE IF NOT EXISTS `Sales` (
  `GameID` bigint(20) NOT NULL,
  `SaleDate` date NOT NULL,
  `SaleAmount` double NOT NULL DEFAULT 0,
  KEY `GameID` (`GameID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

