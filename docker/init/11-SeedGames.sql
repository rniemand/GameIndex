-- TRUNCATE TABLE `Games`;

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
    (1, 1, TRUE, 0, '01-D3', 'LEGO Marvel Super Heroes'), -- 30
    (1, 1, TRUE, 0, '01-B2', 'Spyro Reignighted'), -- 31
    (1, 1, TRUE, 0, '01-D2', 'LEGO Marvel Super Heroes 2'), -- 32
    (1, 1, TRUE, 0, '01-B4', 'Crash Bandicoot N.Sane Trilogy'), -- 33
    (1, 1, TRUE, 0, '03-A3', 'Donkey Kong Country Tropical Freeze'), -- 34
    (1, 1, TRUE, 0, '', 'Super Mario Odysee'), -- 35
    (1, 1, TRUE, 0, '02-A6', 'Luigis Mansion 3'), -- 36
    (1, 1, TRUE, 0, '01-D6', 'Disgaea 1 Complete'), -- 37
    (1, 1, TRUE, 0, '02-C6', 'Pokemon Legends: Arceus'), -- 38
    (1, 1, TRUE, 0, '02-C3', 'Pokémon Violet'), -- 39
    (1, 1, TRUE, 0, '02-C1', 'Pokémon Shining Pearl'), -- 40
    (1, 1, TRUE, 0, '01-C1', 'LEGO Harry Potter Collection'), -- 41
    (1, 1, TRUE, 0, '01-C2', 'LEGO DC Super Villians'), -- 42
    (1, 1, TRUE, 0, '02-A5', 'Pokémon Shield'), -- 43
    (1, 1, TRUE, 0, '02-B4', 'Pokémon Brilliant Diamond'), -- 44
    (1, 1, TRUE, 0, '01-A1', 'Ice Age Scrats Nutty Adventure'), -- 45
    (1, 1, TRUE, 0, '01-B5', 'Paw Patrol Grand Prix'), -- 46
    (1, 1, TRUE, 0, '01-A4', 'Cars 3 Driven to Win'), -- 47
    (1, 1, TRUE, 0, '02-D4', 'Mario Kart 8 Deluxe'), -- 48
    (1, 1, TRUE, 0, '02-D5', 'Disney Classic Games: Aladdin and The Lion King'), -- 49
    (1, 1, TRUE, 0, '01-A3', 'Rayman Legends Definitive Edition'), -- 50
    (1, 1, TRUE, 0, '02-D1', 'Scribblenauts Mega Pack'), -- 51
    (1, 1, TRUE, 0, '02-D2', 'Kaze and the Wild Masks'), -- 52
    (3, 1, TRUE, 0, '', 'Overcooked: All you can Eat'), -- 53
    (4, 1, TRUE, 0, '', 'God of War 3 Remastered'), -- 54
    (4, 1, TRUE, 0, '', 'God of War (PS Hits)'), -- 55
    (4, 1, TRUE, 0, '', 'Injustice Gods Amoung Us'), -- 56
    (4, 1, TRUE, 0, '', 'Batman Arkam Knight'), -- 57
    (4, 1, TRUE, 0, '', 'Marvel Avengers'), -- 58
    (4, 1, TRUE, 0, '', 'Red Dead Redemption 2'), -- 59
    (4, 1, TRUE, 0, '', 'Uncharted 4 A Thiefs End (PS Hits)'), -- 60
    (3, 1, TRUE, 0, '', 'The Last of Us Part 1'), -- 61
    (3, 1, TRUE, 0, '', 'Forspoken'), -- 62
    (4, 1, TRUE, 0, '', 'Witcher 3 Wild Hunt'), -- 63
    (2, 1, TRUE, 0, '', 'Hogwarts Legacy'), -- 64
    (1, 1, FALSE, 0, '', 'Katamari Damacy Reroll'), -- 65
    (1, 1, FALSE, 0, '', 'Baldurs GATE & Baldurs GATE 2 Enhanced Edition'), -- 66
    (1, 1, FALSE, 0, '', 'Kingdom Hearts: Melody of Memory'), -- 67
    (3, 1, FALSE, 0, '', 'Road 96'), -- 68
    (4, 1, TRUE, 0, '', 'Kingdom Hearts 3'), -- 69
    (4, 1, TRUE, 0, '', 'Ratchet & Clank'), -- 70
    (4, 1, TRUE, 0, '', 'Infamous Second Son'), -- 71
    (3, 1, TRUE, 0, '', 'Godfall'), -- 72
    (2, 1, TRUE, 0, '', 'Metal Gear Solid V Ground Zeroes'), -- 73
    (2, 1, TRUE, 0, '', 'Thief 4'), -- 74
    (2, 1, TRUE, 0, '', 'Assassins Creed: Unity'), -- 75
    (4, 1, TRUE, 0, '', 'Kalypso - Dungeons 3'), -- 76
    (1, 1, TRUE, 0, '', 'Digimon Survive'), -- 77
    (2, 1, TRUE, 0, '', 'Bleeding Edge'), -- 78
    (1, 1, TRUE, 0, '', 'Diablo III Eternal Collection'), -- 79
    (2, 1, TRUE, 0, '', 'Elder Scrolls Online'), -- 80
    (4, 1, TRUE, 0, '', 'THE ELDER SCROLLS V : SKYRIM SPECIAL EDITION'), -- 81
    (2, 1, TRUE, 0, '', 'DARKSIDERS 3'), -- 82
    (4, 1, TRUE, 0, '', 'Sonic Mania Plus'), -- 83
    (1, 1, TRUE, 0, '03-A4', 'Hotel Transylvania Scary Tale Adventure'), -- 84
    (1, 1, TRUE, 0, '03-A5', 'Power Rangers: Battle for the Grid Super Edition'), -- 85
    (1, 1, TRUE, 0, '03-B1', 'DC Super Pets'), -- 86
    (1, 1, TRUE, 0, '03-A6', 'Ghost Parade'), -- 87
    (1, 1, TRUE, 0, '03-B2', 'Paw Patrol The Movie Adventure City Calls'), -- 88
    (1, 1, TRUE, 0, '03-B3', 'Dredge'), -- 89
    (1, 1, TRUE, 0, '03-B4', 'Cult of the Lamb'), -- 90
    (1, 1, TRUE, 0, '', 'Star Wars Racer and Commando Combo'), -- 91
    (1, 1, TRUE, 0, '', 'The Legend of Zelda: Tears of the Kingdom'), -- 92
    (1, 1, TRUE, 0, '', 'It Takes Two') -- 93
;
