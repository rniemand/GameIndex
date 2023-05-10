using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamesRepo
{
  Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId);
}

public class GamesRepo : IGamesRepo
{
  private readonly IConnectionHelper _connectionHelper;

  public GamesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId)
  {
    const string query = @"SELECT
	    g.GameID,
	    g.GameName,
	    g.PlatformID,
	    g.LocationID,
	    g.GameCase,
	    g.HasCover,
	    g.Rating,
	    l.LocationName,
	    p.PlatformName,
	    i.ImagePath
    FROM `Games` g
	    INNER JOIN `GamePlatforms` p ON p.PlatformID = g.PlatformID
	    INNER JOIN `GameLocations` l ON l.LocationID = g.LocationID
	    LEFT JOIN `GameImages` i ON i.GameID = g.GameID AND i.ImageType = 'cover'
    WHERE g.PlatformID = @PlatformID
    ORDER BY g.GameName";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<BasicGameInfoEntity>(query, new { PlatformID = platformId })).ToList();
  }
}