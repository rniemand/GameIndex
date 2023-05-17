using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId);
  Task<List<GameImageDto>> GetImagesAsync(long gameId);
  Task<List<GameLocationDto>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationId);
  Task<int> UpdateGameInfoAsync(BasicGameInfoDto gameInfo);
}

public class GamesService : IGamesService
{
  private readonly IGamesRepo _gamesRepo;
  private readonly IGamReceiptRepo _gamReceiptRepo;
  private readonly IGameImagesRepo _gameImagesRepo;
  private readonly IGameLocationRepo _gameLocationRepo;

  public GamesService(IGamesRepo gamesRepo,
    IGamReceiptRepo gamReceiptRepo,
    IGameImagesRepo gameImagesRepo,
    IGameLocationRepo gameLocationRepo)
  {
    _gamesRepo = gamesRepo;
    _gamReceiptRepo = gamReceiptRepo;
    _gameImagesRepo = gameImagesRepo;
    _gameLocationRepo = gameLocationRepo;
  }

  public async Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId) =>
    (await _gamesRepo.GetAllAsync(platformId)).Select(BasicGameInfoDto.FromEntity).ToList();

  public async Task<List<GameImageDto>> GetImagesAsync(long gameId)
  {
    var dbImages = await _gameImagesRepo.GetGameImagesAsync(gameId);
    return dbImages.Count == 0 ? new List<GameImageDto>() : dbImages.Select(GameImageDto.FromEntity).ToList();
  }

  public async Task<List<GameLocationDto>> GetLocationsAsync(int platformId)
  {
    var dbLocations = await _gameLocationRepo.GetLocationsAsync(platformId);
    return dbLocations.Count == 0 ? new List<GameLocationDto>() : dbLocations.Select(GameLocationDto.FromEntity).ToList();
  }

  public async Task<int> SetGameLocationAsync(long gameId, int locationId) =>
    await _gameLocationRepo.SetGameLocationAsync(gameId, locationId);

  public async Task<int> UpdateGameInfoAsync(BasicGameInfoDto gameInfo) =>
    await _gamesRepo.UpdateGameInfoAsync(gameInfo.ToEntity());
}
