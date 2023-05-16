using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGameImagesRepo
{
  Task<GameImageEntity?> GetGameCoverImageAsync(long gameId);
  Task<List<GameImageEntity>> GetGameImagesAsync(long gameId);
}

public class GameImagesRepo : IGameImagesRepo
{
  public const string TableName = "GameImages";
  private readonly IConnectionHelper _connectionHelper;

  public GameImagesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<GameImageEntity?> GetGameCoverImageAsync(long gameId)
  {
    const string query = @$"SELECT
	    gi.GameID,
	    gi.ImageType,
	    gi.ImageOrder,
	    gi.ImagePath
    FROM `{TableName}` gi
    WHERE gi.GameID = @GameID
	    AND gi.ImageType = 'cover'
    LIMIT 1";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.QuerySingleOrDefaultAsync<GameImageEntity>(query, new { GameID = gameId });
  }

  public async Task<List<GameImageEntity>> GetGameImagesAsync(long gameId)
  {
    const string query = $@"SELECT
	    gi.GameID,
	    gi.ImageType,
	    gi.ImageOrder,
	    gi.ImagePath
    FROM `{TableName}` gi
    WHERE gi.GameID = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<GameImageEntity>(query, new { GameID = gameId })).AsList();
  }
}
