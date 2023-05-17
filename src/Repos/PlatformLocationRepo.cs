using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IPlatformLocationRepo
{
  Task<List<PlatformLocationEntity>> GetLocationsAsync(int platformId);
  Task<int> SetGameLocationAsync(long gameId, int platformLocationID);
}

public class PlatformLocationRepo : IPlatformLocationRepo
{
  public const string TableName = "PlatformLocations";
  private readonly IConnectionHelper _connectionHelper;

  public PlatformLocationRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<PlatformLocationEntity>> GetLocationsAsync(int platformId)
  {
    const string query = $@"SELECT
	    l.PlatformLocationID,
	    l.PlatformID,
	    l.LocationName
    FROM `{TableName}` l
    WHERE l.PlatformID = @PlatformID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<PlatformLocationEntity>(query, new { PlatformID = platformId })).AsList();
  }

  public async Task<int> SetGameLocationAsync(long gameId, int platformLocationID)
  {
    const string query = $@"UPDATE `{GamesRepo.TableName}`
    SET `PlatformLocationID` = (
	    SELECT `PlatformLocationID`
	    FROM `{TableName}`
	    WHERE `PlatformID` = (
		    SELECT `PlatformID`
		    FROM `{GamesRepo.TableName}`
		    WHERE `GameID` = @GameID
	    )
	    AND `LocationName` = 'Home'
    )
    WHERE `PlatformLocationID` = @PlatformLocationID;
    UPDATE `{GamesRepo.TableName}`
    SET `PlatformLocationID` = @PlatformLocationID
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new
    {
      GameID = gameId,
      PlatformLocationID = platformLocationID,
    });
  }
}
