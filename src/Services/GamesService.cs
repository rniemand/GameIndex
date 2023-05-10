using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGamesService
{
  Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId);
}

public class GamesService : IGamesService
{
  private readonly IGamesRepo _gamesRepo;

  public GamesService(IGamesRepo gamesRepo)
  {
    _gamesRepo = gamesRepo;
  }

  public async Task<List<BasicGameInfoDto>> ListAllGamesAsync(int platformId) => 
    (await _gamesRepo.GetAllAsync(platformId)).Select(BasicGameInfoDto.FromEntity).ToList();
}
