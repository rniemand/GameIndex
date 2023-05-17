using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IPlatformsRepo
{
  Task<List<PlatformEntity>> GetAllPlatformsAsync();
}

public class PlatformsRepo : IPlatformsRepo
{
  public const string TableName = "Platforms";
  private readonly IConnectionHelper _connectionHelper;

  public PlatformsRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<PlatformEntity>> GetAllPlatformsAsync()
  {
    const string query = $@"SELECT
	    p.PlatformID,
	    p.PlatformName
    FROM `{TableName}` p";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<PlatformEntity>(query)).AsList();
  }
}
