using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGameLocationRepo
{
  Task<List<GameLocationEntity>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationId);
}

public class GameLocationRepo : IGameLocationRepo
{
  public const string TableName = "GameLocations";
  private readonly IConnectionHelper _connectionHelper;

  public GameLocationRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<GameLocationEntity>> GetLocationsAsync(int platformId)
  {
    const string query = $@"SELECT
	    l.LocationID,
	    l.PlatformID,
	    l.LocationName
    FROM `{TableName}` l
    WHERE l.PlatformID = @PlatformID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<GameLocationEntity>(query, new { PlatformID = platformId })).AsList();
  }

  public async Task<int> SetGameLocationAsync(long gameId, int locationId)
  {
    const string query = $@"UPDATE `{GamesRepo.TableName}`
    SET `LocationID` = (
	    SELECT `LocationID`
	    FROM `{TableName}`
	    WHERE `PlatformID` = (
		    SELECT `PlatformID`
		    FROM `{GamesRepo.TableName}`
		    WHERE `GameID` = @GameID
	    )
	    AND `LocationName` = 'Home'
    )
    WHERE `LocationID` = @LocationID;
    UPDATE `{GamesRepo.TableName}`
    SET `LocationID` = @LocationID
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new
    {
      GameID = gameId,
      LocationID = locationId,
    });
  }
}
