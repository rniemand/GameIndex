using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamOrderInfoRepo
{
  Task<GameOrderInfoEntity?> GetOrderInfoAsync(long gameId);
  Task<int> ToggleHasProtectionAsync(long gameId);
}

public class GamOrderInfoRepo : IGamOrderInfoRepo
{
  private readonly IConnectionHelper _connectionHelper;

  public GamOrderInfoRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<GameOrderInfoEntity?> GetOrderInfoAsync(long gameId)
  {
    const string query = @"SELECT
	    o.GameID,
	    o.HasProtection,
	    o.Seller,
	    o.OrderNumber,
	    o.Cost,
	    o.PurchaseDate
    FROM `GameOrderInfo` o
    WHERE o.GameID = @GameID
    LIMIT 1";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.QuerySingleOrDefaultAsync<GameOrderInfoEntity>(query, new { GameID = gameId });
  }

  public async Task<int> ToggleHasProtectionAsync(long gameId)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `HasProtection` = !`HasProtection`
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId});
  }
}
