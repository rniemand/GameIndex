using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamesRepo
{
  Task<List<GameEntity>> GetAllAsync();
}

public class GamesRepo : IGamesRepo
{
  private readonly IConnectionHelper _connectionHelper;

  public GamesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<GameEntity>> GetAllAsync()
  {
    const string query = @"SELECT
	    `GameId` AS `GameID`,
	    `GameName`
    FROM `Games`";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<GameEntity>(query)).ToList();
  }
}