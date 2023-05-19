using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> GetPlatformGamesAsync(int platformId);
  Task<BasicGameInfoDto?> UpdateGameInfoAsync(BasicGameInfoDto gameInfo);
  Task<bool> AddGameAsync(BasicGameInfoDto gameInfo);
}

public class GamesService : IGamesService
{
  private readonly IGamesRepo _gamesRepo;

  public GamesService(IGamesRepo gamesRepo)
  {
    _gamesRepo = gamesRepo;
  }

  public async Task<List<BasicGameInfoDto>> GetPlatformGamesAsync(int platformId) =>
    (await _gamesRepo.GetAllAsync(platformId)).Select(BasicGameInfoDto.FromEntity).ToList();

  public async Task<BasicGameInfoDto?> UpdateGameInfoAsync(BasicGameInfoDto gameInfo)
  {
    await _gamesRepo.UpdateAsync(gameInfo.ToEntity());
    var dbGame = await _gamesRepo.GetByIDAsync(gameInfo.GameID);
    return dbGame is null ? null : BasicGameInfoDto.FromEntity(dbGame);
  }

  public async Task<bool> AddGameAsync(BasicGameInfoDto gameInfo)
  {
    // TODO: [VALIDATION] (GamesService.AddGameAsync) Add better validation
    if (gameInfo.PlatformID <= 0) throw new Exception("You need to provide a platform");
    if (gameInfo.LocationID <= 0) throw new Exception("You need to provide a location");
    if (string.IsNullOrWhiteSpace(gameInfo.GameName)) throw new Exception("You need to provide a name");

    var rowCount = await _gamesRepo.AddGameAsync(gameInfo.ToEntity());
    if (rowCount == 0) throw new Exception("Failed to add game!");
    return true;
  }
}
