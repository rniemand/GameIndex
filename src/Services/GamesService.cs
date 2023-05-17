using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId);
  Task<List<GameImageDto>> GetImagesAsync(long gameId);
  Task<List<LocationDto>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationId);
  Task<BasicGameInfoDto?> UpdateGameInfoAsync(BasicGameInfoDto gameInfo);
}

public class GamesService : IGamesService
{
  private readonly IGamesRepo _gamesRepo;
  private readonly IReceiptRepo _receiptRepo;
  private readonly IGameImagesRepo _gameImagesRepo;
  private readonly ILocationRepo _locationRepo;

  public GamesService(IGamesRepo gamesRepo,
    IReceiptRepo receiptRepo,
    IGameImagesRepo gameImagesRepo,
    ILocationRepo locationRepo)
  {
    _gamesRepo = gamesRepo;
    _receiptRepo = receiptRepo;
    _gameImagesRepo = gameImagesRepo;
    _locationRepo = locationRepo;
  }

  public async Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId) =>
    (await _gamesRepo.GetAllAsync(platformId)).Select(BasicGameInfoDto.FromEntity).ToList();

  public async Task<List<GameImageDto>> GetImagesAsync(long gameId)
  {
    var dbImages = await _gameImagesRepo.GetGameImagesAsync(gameId);
    return dbImages.Count == 0 ? new List<GameImageDto>() : dbImages.Select(GameImageDto.FromEntity).ToList();
  }

  public async Task<List<LocationDto>> GetLocationsAsync(int platformId)
  {
    var dbLocations = await _locationRepo.GetLocationsAsync(platformId);
    return dbLocations.Count == 0 ? new List<LocationDto>() : dbLocations.Select(LocationDto.FromEntity).ToList();
  }

  public async Task<int> SetGameLocationAsync(long gameId, int locationId) =>
    await _locationRepo.SetGameLocationAsync(gameId, locationId);

  public async Task<BasicGameInfoDto?> UpdateGameInfoAsync(BasicGameInfoDto gameInfo)
  {
    await _gamesRepo.UpdateGameInfoAsync(gameInfo.ToEntity());
    var dbGame = await _gamesRepo.GetByIDAsync(gameInfo.GameID);
    return dbGame is null ? null : BasicGameInfoDto.FromEntity(dbGame);
  }
}
