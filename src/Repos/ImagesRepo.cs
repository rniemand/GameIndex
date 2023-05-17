using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IImagesRepo
{
  Task<ImageEntity?> GetGameCoverImageAsync(long gameId);
  Task<List<ImageEntity>> GetGameImagesAsync(long gameId);
}

public class ImagesRepo : IImagesRepo
{
  public const string TableName = "Images";
  private readonly IConnectionHelper _connectionHelper;

  public ImagesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<ImageEntity?> GetGameCoverImageAsync(long gameId)
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
    return await connection.QuerySingleOrDefaultAsync<ImageEntity>(query, new { GameID = gameId });
  }

  public async Task<List<ImageEntity>> GetGameImagesAsync(long gameId)
  {
    const string query = $@"SELECT
	    gi.GameID,
	    gi.ImageType,
	    gi.ImageOrder,
	    gi.ImagePath
    FROM `{TableName}` gi
    WHERE gi.GameID = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<ImageEntity>(query, new { GameID = gameId })).AsList();
  }
}
