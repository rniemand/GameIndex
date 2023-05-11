-- =======================================================================================
-- Game Platforms
-- =======================================================================================
INSERT INTO `GamePlatforms`
    (`PlatformName`)
VALUES
    ('Switch'),
    ('XBox');

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

-- =======================================================================================
-- GameLocations
-- =======================================================================================
INSERT INTO `Games`
    (`PlatformID`, `LocationID`, `HasCover`, `Rating`, `GameCase`, `GameName`)
VALUES
    (1, 1, TRUE, 0, '01-C4', 'Civilization VI'), -- 1
    (1, 1, TRUE, 0, '01-D5', 'Hello Neighbor'), -- 2
    (1, 1, TRUE, 0, '03-A2', 'Super Mario 3D World + Bowsers Fury'), -- 3
    (1, 1, TRUE, 0, '01-D1', 'Lego Jurassic World'), -- 4
    (1, 1, TRUE, 0, '02-C2', 'Nickelodeon All-Star Brawl'), -- 5
    (1, 1, TRUE, 0, '01-B6', 'The LEGO Movie 2 Videogame'), -- 6
    (1, 1, TRUE, 0, '02-B3', 'Pokémon Sword'), -- 7
    (1, 1, TRUE, 0, '02-B2', 'The Legend of Zelda: Breath of the Wild'), -- 8
    (1, 1, TRUE, 0, '02-D3', 'Paper Mario: The Origami King'), -- 9
    (1, 1, TRUE, 0, '02-D6', 'Minecraft'), -- 10
    (1, 1, TRUE, 0, '02-A4', 'Mario + Rabbids Kingdom Battle'), -- 11
    (1, 1, TRUE, 0, '02-B6', 'Animal Crossing') -- 12
;

-- =======================================================================================
-- GameLocations
-- =======================================================================================
INSERT INTO `GameImages`
    (`GameID`, `ImageOrder`, `ImageType`, `ImagePath`)
VALUES
    (1, 1, 'cover', 'covers/switch/c/civ-vi.jpg'),
    (2, 1, 'cover', 'covers/switch/h/hello-neighbor.jpg'),
    (3, 1, 'cover', 'covers/switch/m/mario-bowser-fury.jpg'),
    (4, 1, 'cover', 'covers/switch/l/lego-jurassic-world.jpg'),
    (5, 1, 'cover', 'covers/switch/n/nic-allstar-brawl.jpg'),
    (6, 1, 'cover', 'covers/switch/l/lego-movie-2.jpg'),
    (7, 1, 'cover', 'covers/switch/p/pokemon-sword.jpg'),
    (8, 1, 'cover', 'covers/switch/z/zelda-botw.jpg'),
    (9, 1, 'cover', 'covers/switch/p/paper-mario.jpg'),
    (10, 1, 'cover', 'covers/switch/m/minecraft.jpg'),
    (11, 1, 'cover', 'covers/switch/m/mario-rabbits-kingdom.jpg'),
    (12, 1, 'cover', 'covers/switch/a/animal-crossing.jpg');

-- =======================================================================================
-- GameLocations
-- =======================================================================================
INSERT INTO `GameOrderInfo`
	(`GameID`, `HasProtection`, `Seller`, `OrderNumber`, `Cost`, `PurchaseDate`)
VALUES
	(1, FALSE, 'GameStop', '44867472', 24.99, '2022-10-13'),
    (2, FALSE, 'GameStop', '44869704', 24.99, '2022-10-14'),
    (3, TRUE,  'GameStop', '46880684', 65.99, '2023-03-22'),
    (5, TRUE, 'GameStop', '46821750', 33.99, '2023-03-16'),
    (6, FALSE, 'GameStop', '44669886', 24.99, '2022-09-23'),
    (7, FALSE, 'GameStop', '45550213', 65.99, '2022-11-30'),
    (9, FALSE, 'GameStop', '45439390', 65.99, '2022-11-23'),
    (11, FALSE, 'GameStop', '45550213', 22.49, '2022-11-30');

-- Fin.
