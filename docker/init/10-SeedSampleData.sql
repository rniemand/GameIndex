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
-- Games
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
    (1, 1, TRUE, 0, '02-B6', 'Animal Crossing'), -- 12
    (1, 1, TRUE, 0, '02-A3', 'Mario + Rabbids Sparks of Hope'), -- 13
    (1, 1, TRUE, 0, '02-A1', 'Indivisible'), -- 14
    (1, 1, TRUE, 0, '01-A5', 'New Super Mario Bros. U Deluxe'), -- 15
    (1, 1, TRUE, 0, '01-B1', 'South Park: The Fractured But Whole'), -- 16
    (1, 1, TRUE, 0, '02-B5', 'Pokémon Scarlet'), -- 17
    (1, 1, TRUE, 0, '01-B3', 'Astroneer'), -- 18
    (1, 1, TRUE, 0, '02-C5', 'Pokémon: Lets Go, Pikachu!'), -- 19
    (1, 1, TRUE, 0, '01-C6', 'Borderlands Legendary Collection'), -- 20
    (1, 1, TRUE, 0, '03-A1', 'LEGO The Incredibles'), -- 21
    (1, 1, TRUE, 0, '01-A6', 'Harvest Moon Light of Hope'), -- 22
    (1, 1, TRUE, 0, '02-B1', 'Captain Toad: Treasure Tracker'), -- 23
    (1, 1, TRUE, 0, '01-D4', 'Assassins Creed The Ezio Collection'), -- 24
    (1, 1, TRUE, 0, '02-A2', 'Dragons: Dawn of the New Riders'), -- 25
    (1, 1, TRUE, 0, '01-C3', 'Autonauts'), -- 26
    (1, 1, TRUE, 0, '01-C5', 'Minecraft Dungeons Ultimate Edition'), -- 27
    (1, 1, TRUE, 0, '02-C4', 'Legend of Zelda Links Awakening'), -- 28
    (1, 1, TRUE, 0, '01-A2', 'Hot Wheels Unleashed'), -- 29
    (1, 1, TRUE, 0, '01-D3', 'LEGO Marvel Super Heroes') -- 30
;

-- =======================================================================================
-- GameImages
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
    (12, 1, 'cover', 'covers/switch/a/animal-crossing.jpg'),
    (13, 1, 'cover', 'covers/switch/m/mario-rabbits-sparks.jpg'),
    (14, 1, 'cover', 'covers/switch/i/indivisible.jpg'),
    (15, 1, 'cover', 'covers/switch/n/new-mario-super-deluxe.jpg'),
    (16, 1, 'cover', 'covers/switch/s/sp-fractured-bh.jpg'),
    (17, 1, 'cover', 'covers/switch/p/pokemon-scarlet.jpg'),
    (18, 1, 'cover', 'covers/switch/a/astroneer.jpg'),
    (19, 1, 'cover', 'covers/switch/p/pokemon-lets-go-pika.jpg'),
    (20, 1, 'cover', 'covers/switch/b/borderlands-legendary-collection.jpg'),
    (21, 1, 'cover', 'covers/switch/l/lego-incredibles.jpg'),
    (22, 1, 'cover', 'covers/switch/h/harvest-moon-light-of-hope.jpg'),
    (23, 1, 'cover', 'covers/switch/c/cpt-toad-treasure-tracker.jpg'),
    (24, 1, 'cover', 'covers/switch/a/assassins-creed-ezio.jpg'),
    (25, 1, 'cover', 'covers/switch/d/dragons-dawn-of-new-riders.jpg'),
    (26, 1, 'cover', 'covers/switch/a/autonauts.jpg'),
    (27, 1, 'cover', 'covers/switch/m/minecraft-dungeons.jpg'),
    (28, 1, 'cover', 'covers/switch/z/zelda-links-awakening.jpg'),
    (29, 1, 'cover', 'covers/switch/h/hotwheels-unleashed.jpg'),
    (30, 1, 'cover', 'covers/switch/l/lego-marvel-super-heroes.jpg');

-- =======================================================================================
-- GameOrderInfo
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
    (11, FALSE, 'GameStop', '45550213', 22.49, '2022-11-30'),
    (14, TRUE, 'GameStop', '46112401', 32.99, '2023-01-01'),
    (15, FALSE, 'GameStop', '45383141', 65.99, '2022-11-19'),
    (17, TRUE, 'GameStop', '45502178', 79.99, '2022-11-26'),
    (20, FALSE, 'GameStop', '45550213', 13.49, '2022-11-30'),
    (20, FALSE, 'GameStop', '46661680', 24.99, '2023-02-26'),
    (23, FALSE, 'GameStop', '45592204', 39.99, '2022-12-03'),
    (26, FALSE, 'Amazon', '702-0994886-4812251', 41.99, '2022-11-19'),
    (28, FALSE, 'GameStop', '44645315', 65.99, '2022-09-21'),
    (29, FALSE, 'GameStop', '44869704', 29.99, '2022-10-14'),
    (30, TRUE, 'GameStop', '46664125', 39.99, '2023-02-26');

-- Fin.
