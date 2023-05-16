-- =======================================================================================
-- Game Platforms
-- =======================================================================================
-- TRUNCATE TABLE `GamePlatforms`;
INSERT INTO `GamePlatforms`
    (`PlatformName`)
VALUES
	('Switch'),
	('XBox'),
	('PS5'),
	('PS4');

-- =======================================================================================
-- GameLocations
-- =======================================================================================
-- TRUNCATE TABLE `GameLocations`;
INSERT INTO `GameLocations`
    (`LocationID`, `PlatformID`, `LocationName`)
VALUES
	(1, 1, 'Home'),
	(2, 1, 'Richard Switch'),
	(3, 1, 'Kelsies Switch'),
	(4, 1, 'Nanas Switch'),
	(5, 1, 'Sams Switch'),
	(6, 1, 'Micheal Switch'),
	(7, 1, 'Erica Switch'),
	(8, 1, 'Sean Switch');


-- =======================================================================================
-- GameSales
-- =======================================================================================
-- TRUNCATE TABLE `GameSales`;
INSERT INTO `GameSales`
    (`GameID`, `SaleDate`, `SaleAmount`)
VALUES
	(66, '2023-02-19', 16),
	(69, '2023-02-18', 17.99),
	(70, '2023-02-18', 15.29),
	(71, '2023-02-18', 14.99),
	(77, '2023-02-19', 22),
	(78, '2023-02-19', 0.5),
	(80, '2023-02-18', 7.99),
	(81, '2023-02-18', 31.49),
	(82, '2023-02-18', 14.99);