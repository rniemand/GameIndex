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
INSERT INTO `GameLocations`
    (`PlatformID`, `LocationName`)
VALUES
    (1, 'Home'),
    (1, 'Richard Switch');

/*
TRUNCATE TABLE `Games`;
TRUNCATE TABLE `GameImages`;
TRUNCATE TABLE `GameOrderInfo`;
*/
