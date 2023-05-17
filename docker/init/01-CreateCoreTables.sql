CREATE TABLE IF NOT EXISTS `Platforms` (
  `PlatformID` int(11) NOT NULL AUTO_INCREMENT,
  `PlatformName` varchar(128) NOT NULL,
  PRIMARY KEY (`PlatformID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Locations` (
  `LocationID` int(11) NOT NULL AUTO_INCREMENT,
  `PlatformID` int(11) NOT NULL,
  `LocationName` varchar(256) NOT NULL,
  PRIMARY KEY (`LocationID`) USING BTREE,
  KEY `PlatformID` (`PlatformID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Receipts` (
  `ReceiptID` int(11) NOT NULL AUTO_INCREMENT,
  `HaveReceipt` bit(1) NOT NULL DEFAULT b'0',
  `ReceiptScanned` bit(1) NOT NULL DEFAULT b'0',
  `ReceiptAssociated` bit(1) NOT NULL DEFAULT b'0',
  `ReceiptDate` date DEFAULT NULL,
  `Store` varchar(256) DEFAULT NULL,
  `ReceiptNumber` varchar(64) DEFAULT NULL,
  `ReceiptUrl` varchar(512) DEFAULT NULL,
  `ReceiptName` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`ReceiptID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Games` (
  `GameID` bigint(20) NOT NULL AUTO_INCREMENT,
  `ReceiptID` int(11) DEFAULT NULL,
  `SaleReceiptID` int(11) DEFAULT NULL,
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
  KEY `LocationID` (`LocationID`) USING BTREE,
  KEY `SaleReceiptID` (`SaleReceiptID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Images` (
  `GameID` bigint(20) NOT NULL,
  `ImageType` varchar(128) NOT NULL,
  `ImageOrder` smallint(6) NOT NULL DEFAULT 256,
  `ImagePath` varchar(512) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE IF NOT EXISTS `Sales` (
  `GameID` bigint(20) NOT NULL,
  `SaleDate` date NOT NULL,
  `SaleAmount` double NOT NULL DEFAULT 0,
  KEY `GameID` (`GameID`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
