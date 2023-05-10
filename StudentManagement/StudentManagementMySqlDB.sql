-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.20-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping structure for table studentmanagement.marks
DROP TABLE IF EXISTS `marks`;
CREATE TABLE IF NOT EXISTS `marks` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `studentId` int(11) NOT NULL,
  `TermId` int(11) NOT NULL,
  `English` int(11) NOT NULL,
  `Tamil` int(11) NOT NULL,
  `Maths` int(11) NOT NULL,
  `physics` int(11) NOT NULL,
  `Chemistry` int(11) NOT NULL,
  `ComputerScience` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Marks_studentId` (`studentId`),
  KEY `IX_Marks_TermId` (`TermId`),
  CONSTRAINT `FK_Marks_Students_studentId` FOREIGN KEY (`studentId`) REFERENCES `students` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Marks_Term_TermId` FOREIGN KEY (`TermId`) REFERENCES `term` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- Dumping data for table studentmanagement.marks: ~11 rows (approximately)
INSERT INTO `marks` (`Id`, `studentId`, `TermId`, `English`, `Tamil`, `Maths`, `physics`, `Chemistry`, `ComputerScience`) VALUES
	(1, 1, 1, 80, 80, 85, 90, 95, 100),
	(2, 1, 2, 83, 85, 80, 80, 85, 90),
	(3, 1, 3, 50, 45, 40, 40, 45, 40),
	(4, 1, 4, 50, 50, 40, 80, 45, 80),
	(5, 1, 5, 80, 80, 80, 80, 85, 80),
	(6, 1, 6, 80, 89, 87, 80, 85, 100),
	(7, 2, 1, 86, 85, 87, 80, 90, 100),
	(8, 2, 2, 86, 85, 87, 80, 90, 100),
	(9, 2, 3, 80, 89, 87, 87, 80, 90),
	(10, 2, 4, 60, 65, 80, 76, 75, 70),
	(11, 2, 5, 80, 85, 88, 80, 85, 80),
	(12, 2, 6, 50, 55, 68, 60, 65, 60);

-- Dumping structure for table studentmanagement.students
DROP TABLE IF EXISTS `students`;
CREATE TABLE IF NOT EXISTS `students` (
  `Id` int(11) NOT NULL,
  `RollNo` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL DEFAULT '',
  `standard` int(11) NOT NULL,
  `Academic_Year` int(11) NOT NULL,
  `Gender` char(1) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RollNo` (`RollNo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table studentmanagement.students: ~4 rows (approximately)
INSERT INTO `students` (`Id`, `RollNo`, `Name`, `standard`, `Academic_Year`, `Gender`) VALUES
	(1, 1, 'kalai', 12, 2023, 'F'),
	(2, 2, 'Moni', 12, 2023, 'F'),
	(3, 3, 'Raju', 12, 2023, 'M'),
	(4, 4, 'Ramu', 12, 2023, 'M');

-- Dumping structure for table studentmanagement.term
DROP TABLE IF EXISTS `term`;
CREATE TABLE IF NOT EXISTS `term` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TermName` longtext NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- Dumping data for table studentmanagement.term: ~6 rows (approximately)
INSERT INTO `term` (`id`, `TermName`) VALUES
	(1, '1st Mid-Term'),
	(2, 'Quaterly'),
	(3, '2nd Mid-Term'),
	(4, 'Half-Yearly'),
	(5, '3rd Mid-Term'),
	(6, 'Annual');

-- Dumping structure for table studentmanagement.__efmigrationshistory
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table studentmanagement.__efmigrationshistory: ~0 rows (approximately)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20230504092908_MyStudentManagementDb', '6.0.15');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
