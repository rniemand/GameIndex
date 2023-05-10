-- =======================================================================================
-- Game Platforms
-- =======================================================================================
INSERT INTO `GamePlatforms`
    (`PlatformName`)
VALUES
    ('Switch');

-- =======================================================================================
-- GameLocations
-- =======================================================================================
INSERT INTO `GameLocations`
    (`PlatformID`, `LocationName`)
VALUES
    (1, 'Home'),
    (1, 'Richard Switch');

-- =======================================================================================
-- GameLocations
-- =======================================================================================
INSERT INTO `Games`
    (`PlatformID`, `LocationID`, `HasCover`, `Rating`, `GameCase`, `GameName`)
VALUES
    (1, 1, TRUE, 0, '01-C4', 'Civilization VI'), -- 1
    (1, 1, TRUE, 0, '01-D5', 'Hello Neighbor'), -- 2
    (1, 1, TRUE, 0, '03-A2', 'Super Mario 3D World + Bowsers Fury'), -- 3
    (1, 1, TRUE, 0, '01-D1', 'Lego Jurassic World') -- 4
;

-- =======================================================================================
-- GameLocations
-- =======================================================================================
INSERT INTO `GameImages`
    (`GameID`, `ImageOrder`, `ImageType`, `ImagePath`)
VALUES
    (1, 1, 'cover', 'covers/switch/c/civ-vi.jpg'),
    (2, 1, 'cover', 'covers/switch/h/hello-neighbor.png'),
    (3, 1, 'cover', 'covers/switch/m/mario-bowser-fury.png'),
    (4, 1, 'cover', 'covers/switch/l/lego-jurassic-world.png');

-- =======================================================================================
-- GameLocations
-- =======================================================================================
INSERT INTO `GameOrderInfo`
	(`GameID`, `HasProtection`, `Seller`, `OrderNumber`, `Cost`, `PurchaseDate`)
VALUES
	(1, FALSE, 'GameStop', '44867472', 24.99, '2022-10-13'),
    (2, FALSE, 'GameStop', '44869704', 24.99, '2022-10-14'),
    (3, TRUE,  'GameStop', '46880684', 65.99, '2023-03-22'),
    (4, FALSE, 'GameStop', '', 0, NULL);