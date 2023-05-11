using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId);
  Task<GameOrderInfoDto?> GetOrderInfoAsync(long gameId);
  Task<List<GameImageDto>> GetImagesAsync(long gameId);
}

public class GamesService : IGamesService
{
  private readonly IGamesRepo _gamesRepo;
  private readonly IGamOrderInfoRepo _gamOrderInfoRepo;
  private readonly IGameImagesRepo _gameImagesRepo;

  public GamesService(IGamesRepo gamesRepo,
    IGamOrderInfoRepo gamOrderInfoRepo,
    IGameImagesRepo gameImagesRepo)
  {
    _gamesRepo = gamesRepo;
    _gamOrderInfoRepo = gamOrderInfoRepo;
    _gameImagesRepo = gameImagesRepo;
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
}
