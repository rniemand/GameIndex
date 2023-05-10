using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamePlatformsRepo
{
  Task<List<GamePlatformEntity>> GetAllPlatformsAsync();
}

public class GamePlatformsRepo : IGamePlatformsRepo
{
  private readonly IConnectionHelper _connectionHelper;

  public GamePlatformsRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<GamePlatformEntity>> GetAllPlatformsAsync()
  {
    const string query = @"SELECT
	    p.PlatformID,
	    p.PlatformName
    FROM `GamePlatforms` p";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<GamePlatformEntity>(query)).AsList();
  }
}
