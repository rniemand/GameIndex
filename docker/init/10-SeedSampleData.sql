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
