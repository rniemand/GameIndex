using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId);
  Task<GameOrderInfoDto?> GetOrderInfoAsync(long gameId);
  Task<List<GameImageDto>> GetImagesAsync(long gameId);
  Task<List<GameLocationDto>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationId);
}

public class GamesService : IGamesService
{
  private readonly IGamesRepo _gamesRepo;
  private readonly IGamOrderInfoRepo _gamOrderInfoRepo;
  private readonly IGameImagesRepo _gameImagesRepo;
  private readonly IGameLocationRepo _gameLocationRepo;

  public GamesService(IGamesRepo gamesRepo,
    IGamOrderInfoRepo gamOrderInfoRepo,
    IGameImagesRepo gameImagesRepo,
    IGameLocationRepo gameLocationRepo)
  {
    _gamesRepo = gamesRepo;
    _gamOrderInfoRepo = gamOrderInfoRepo;
    _gameImagesRepo = gameImagesRepo;
    _gameLocationRepo = gameLocationRepo;
  }

  public async Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId) =>
    (await _gamesRepo.GetAllAsync(platformId)).Select(BasicGameInfoDto.FromEntity).ToList();

  public async Task<GameOrderInfoDto?> GetOrderInfoAsync(long gameId)
  {
    var gameOrderInfoEntity = await _gamOrderInfoRepo.GetOrderInfoAsync(gameId);
    return gameOrderInfoEntity is null ? null : GameOrderInfoDto.FromEntity(gameOrderInfoEntity);
  }

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
}
