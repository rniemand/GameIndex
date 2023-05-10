using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGameLocationRepo
{
  Task<List<GameLocationEntity>> GetLocationsAsync(int platformId);
}

public class GameLocationRepo : IGameLocationRepo
{
  private readonly IConnectionHelper _connectionHelper;

  public GameLocationRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<GameLocationEntity>> GetLocationsAsync(int platformId)
  {
    const string query = @"SELECT
	    l.LocationID,
	    l.PlatformID,
	    l.LocationName
    FROM `GameLocations` l
    WHERE l.PlatformID = @PlatformID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<GameLocationEntity>(query, new { PlatformID = platformId })).AsList();
  }
}
