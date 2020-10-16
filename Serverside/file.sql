-- Erstellungszeit: 16. Okt 2020 um 19:39
-- Server-Version: 10.4.11-MariaDB

-- CREATE DATABASE IF NOT EXISTS `steuer`;
-- USE `steuer`;

DROP TABLE IF EXISTS `werte`;

CREATE TABLE `werte` (
  `id` int(8) NOT NULL PRIMARY KEY,
  `percent` double(8,2) DEFAULT NULL
);

INSERT INTO `werte` (`id`, `percent`) VALUES
(1, 0.19),
(2, 0.16),
(3, 0.07),
(4, 0.05);