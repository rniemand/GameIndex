using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamesRepo
{
  Task<List<GameEntity>> GetAllAsync(int platformId);
}

public class GamesRepo : IGamesRepo
{
  private readonly IConnectionHelper _connectionHelper;

  public GamesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<GameEntity>> GetAllAsync(int platformId)
  {
    const string query = @"SELECT
	    g.GameID,
	    g.GameName,
	    g.PlatformID,
	    g.LocationID,
	    g.GameCase,
	    g.HasCover,
	    g.Rating
    FROM `Games` g
    WHERE g.PlatformID = @PlatformID
    ORDER BY g.GameName";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<GameEntity>(query, new { PlatformID = platformId })).ToList();
  }
}