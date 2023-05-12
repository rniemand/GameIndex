-- =======================================================================================
-- Game Platforms
-- =======================================================================================
INSERT INTO `GamePlatforms`
    (`PlatformName`)
VALUES
    ('Switch'), -- 1,
    ('XBox'), -- 2,
    ('PS5'), -- 3,
    ('PS4') -- 4
;

-- =======================================================================================
-- GameLocations
-- =======================================================================================
/*
TRUNCATE TABLE `GameLocations`;
*/
INSERT INTO `GameLocations`
    (`PlatformID`, `LocationName`)
VALUES
    (1, 'Home'),
    (1, 'Richard Switch'),
    (1, 'Kelsies Switch'),
    (1, 'Nanas Switch'),
    (1, 'Sams Switch'),
    (1, 'Micheal Switch'),
    (1, 'Erica Switch'),
    (1, 'Sean Switch');

/*
TRUNCATE TABLE `GameImages`;
TRUNCATE TABLE `GameOrderInfo`;
*/
