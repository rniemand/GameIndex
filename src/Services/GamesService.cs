using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId);
  Task<GameOrderInfoDto?> GetOrderInfoAsync(long gameId);
}

public class GamesService : IGamesService
{
  private readonly IGamesRepo _gamesRepo;
  private readonly IGamOrderInfoRepo _gamOrderInfoRepo;

  public GamesService(IGamesRepo gamesRepo,
    IGamOrderInfoRepo gamOrderInfoRepo)
  {
    _gamesRepo = gamesRepo;
    _gamOrderInfoRepo = gamOrderInfoRepo;
  }

  public async Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId) =>
    (await _gamesRepo.GetAllAsync(platformId)).Select(BasicGameInfoDto.FromEntity).ToList();

  public async Task<GameOrderInfoDto?> GetOrderInfoAsync(long gameId)
  {
    var gameOrderInfoEntity = await _gamOrderInfoRepo.GetOrderInfoAsync(gameId);
    return gameOrderInfoEntity is null ? null : GameOrderInfoDto.FromEntity(gameOrderInfoEntity);
  }
}
