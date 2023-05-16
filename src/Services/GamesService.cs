using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId);
  Task<GameReceiptDto?> GetOrderInfoAsync(long gameId);
  Task<List<GameImageDto>> GetImagesAsync(long gameId);
  Task<List<GameLocationDto>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationId);
  Task<int> UpdateGameInfoAsync(BasicGameInfoDto gameInfo);
  Task<GameReceiptDto?> ToggleGameProtectionAsync(long gameId);
  Task<GameReceiptDto?> ToggleReceiptScannedAsync(long gameId);
  Task<GameReceiptDto?> SetReceiptLocationAsync(long gameId, string location);
  Task<GameReceiptDto?> SetGamePriceAsync(long gameId, double price);
  Task<GameReceiptDto?> SetGameOrderUrlAsync(long gameId, string orderUrl);
  Task<GameReceiptDto?> SetGameOrderNumberAsync(long gameId, string orderNumber);
  Task<GameReceiptDto?> SetGameOrderDateAsync(long gameId, string orderDate);
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

  public async Task<GameReceiptDto?> GetOrderInfoAsync(long gameId)
  {
    var gameOrderInfoEntity = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return gameOrderInfoEntity is null ? null : GameReceiptDto.FromEntity(gameOrderInfoEntity);
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

  public async Task<int> UpdateGameInfoAsync(BasicGameInfoDto gameInfo) =>
    await _gamesRepo.UpdateGameInfoAsync(gameInfo.ToEntity());

  public async Task<GameReceiptDto?> ToggleGameProtectionAsync(long gameId)
  {
    await _gamReceiptRepo.ToggleHasProtectionAsync(gameId);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> ToggleReceiptScannedAsync(long gameId)
  {
    await _gamReceiptRepo.ToggleReceiptScannedAsync(gameId);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }
  
  public async Task<GameReceiptDto?> SetReceiptLocationAsync(long gameId, string location)
  {
    await _gamReceiptRepo.SetReceiptLocationAsync(gameId, location);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetGamePriceAsync(long gameId, double price)
  {
    await _gamReceiptRepo.SetGamePriceAsync(gameId, price);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetGameOrderUrlAsync(long gameId, string orderUrl)
  {
    await _gamReceiptRepo.SetGameOrderUrlAsync(gameId, orderUrl);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetGameOrderNumberAsync(long gameId, string orderNumber)
  {
    await _gamReceiptRepo.SetGameOrderNumberAsync(gameId, orderNumber);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetGameOrderDateAsync(long gameId, string orderDate)
  {
    await _gamReceiptRepo.SetGameOrderDateAsync(gameId, orderDate);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(gameId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }
}
