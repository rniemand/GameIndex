using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface ILocationRepo
{
  Task<List<LocationEntity>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int locationID);
}

public class LocationRepo : ILocationRepo
{
  public const string TableName = "Locations";
  private readonly IConnectionHelper _connectionHelper;

  public LocationRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<LocationEntity>> GetLocationsAsync(int platformId)
  {
    const string query = $@"SELECT
	    l.LocationID,
	    l.PlatformID,
	    l.LocationName
    FROM `{TableName}` l
    WHERE l.PlatformID = @PlatformID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<LocationEntity>(query, new { PlatformID = platformId })).AsList();
  }

  public async Task<int> SetGameLocationAsync(long gameId, int locationID)
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
      LocationID = locationID,
    });
  }
}
