SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for adminmenus
-- ----------------------------
DROP TABLE IF EXISTS `adminmenus`;
CREATE TABLE `adminmenus` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ParentId` int(11) NOT NULL,
  `Name` varchar(64) DEFAULT NULL,
  `Url` varchar(64) DEFAULT NULL,
  `Action` varchar(64) DEFAULT NULL,
  `Controller` varchar(64) DEFAULT NULL,
  `Discretion` varchar(512) DEFAULT NULL,
  `Icon` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for articles
-- ----------------------------
DROP TABLE IF EXISTS `articles`;
CREATE TABLE `articles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(512) DEFAULT NULL,
  `Publisher` varchar(128) DEFAULT NULL,
  `PublisherDateTime` datetime NOT NULL,
  `UpdateDateTime` datetime NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `OriginArticlesType` int(11) NOT NULL,
  `Content` longtext,
  `ContentTyepId` int(11) NOT NULL,
  `Tag` varchar(256) DEFAULT NULL,
  `ImgUrl` varchar(1024) DEFAULT NULL,
  `ThumbnailUrl` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ContentTyepId` (`ContentTyepId`) USING HASH,
  CONSTRAINT `FK_articles_ContentTypes_ContentTyepId` FOREIGN KEY (`ContentTyepId`) REFERENCES `contenttypes` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for basicinfoes
-- ----------------------------
DROP TABLE IF EXISTS `basicinfoes`;
CREATE TABLE `basicinfoes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Value` longtext,
  `Key` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for contenttypes
-- ----------------------------
DROP TABLE IF EXISTS `contenttypes`;
CREATE TABLE `contenttypes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(64) DEFAULT NULL,
  `Description` varchar(128) DEFAULT NULL,
  `PrentId` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for contracts
-- ----------------------------
DROP TABLE IF EXISTS `contracts`;
CREATE TABLE `contracts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(256) DEFAULT NULL,
  `CustomerId` int(11) NOT NULL,
  `Prepayments` decimal(18,2) NOT NULL,
  `Status` int(11) NOT NULL,
  `CreateTime` datetime NOT NULL,
  `SignedTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CustomerId` (`CustomerId`) USING HASH,
  CONSTRAINT `FK_Contracts_Customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for customers
-- ----------------------------
DROP TABLE IF EXISTS `customers`;
CREATE TABLE `customers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Number` int(11) NOT NULL,
  `IPAddress` varchar(32) DEFAULT NULL,
  `CreateTime` datetime NOT NULL,
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for feedbacks
-- ----------------------------
DROP TABLE IF EXISTS `feedbacks`;
CREATE TABLE `feedbacks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Content` varchar(1024) DEFAULT NULL,
  `FeedbackType` int(11) NOT NULL,
  `CustomerId` int(11) NOT NULL,
  `Mobile` varchar(32) DEFAULT NULL,
  `CreateTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_CustomerId` (`CustomerId`) USING HASH,
  CONSTRAINT `FK_Feedbacks_Customers_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customers` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) DEFAULT NULL,
  `ImageUrl` varchar(1024) DEFAULT NULL,
  `ThumbnailUrl` varchar(1024) DEFAULT NULL,
  `Description` longtext,
  `ProductTypeId` int(11) NOT NULL,
  `CreateTime` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ProductTypeId` (`ProductTypeId`) USING HASH,
  CONSTRAINT `FK_Products_ProductTypes_ProductTypeId` FOREIGN KEY (`ProductTypeId`) REFERENCES `producttypes` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for producttypes
-- ----------------------------
DROP TABLE IF EXISTS `producttypes`;
CREATE TABLE `producttypes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TypeName` varchar(100) DEFAULT NULL,
  `ParentId` int(11) NOT NULL,
  `CreateUser` varchar(32) DEFAULT NULL,
  `CreateDateTime` datetime NOT NULL,
  `Level` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



-- ----------------------------
-- Table structure for recruitments
-- ----------------------------
DROP TABLE IF EXISTS `recruitments`;
CREATE TABLE `recruitments` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) DEFAULT NULL,
  `Description` longtext,
  `Requirement` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for userinfoes
-- ----------------------------
DROP TABLE IF EXISTS `userinfoes`;
CREATE TABLE `userinfoes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(32) DEFAULT NULL,
  `Email` varchar(64) DEFAULT NULL,
  `Password` varchar(64) DEFAULT NULL,
  `CreateDateTime` datetime NOT NULL,
  `LastLoginDateTime` datetime NOT NULL,
  `Mobile` varchar(64) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `LoginErrorCount` int(11) NOT NULL,
  `AuthorityUrl` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8;


-- ----------------------------
-- Table structure for visitlogs
-- ----------------------------
DROP TABLE IF EXISTS `visitlogs`;
CREATE TABLE `visitlogs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IpAddress` varchar(128) DEFAULT NULL,
  `VisitorName` varchar(64) DEFAULT NULL,
  `IsSendToMail` tinyint(1) NOT NULL,
  `IsSendToSms` tinyint(1) NOT NULL,
  `MailTo` varchar(512) DEFAULT NULL,
  `SmsTo` varchar(512) DEFAULT NULL,
  `VisitorMail` varchar(256) DEFAULT NULL,
  `VisitorPhone` varchar(256) DEFAULT NULL,
  `Message` longtext,
  `ProductId` int(11) NOT NULL,
  `VisitDateTime` datetime NOT NULL,
  `Country` longtext,
  `Area` longtext,
  `Province` longtext,
  `City` longtext,
  `District` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_ProductId` (`ProductId`) USING HASH,
  CONSTRAINT `FK_VisitLogs_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for __migrationhistory
-- ----------------------------
DROP TABLE IF EXISTS `__migrationhistory`;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ContextKey` varchar(300) NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
