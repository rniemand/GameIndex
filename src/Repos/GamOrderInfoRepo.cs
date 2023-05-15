using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamOrderInfoRepo
{
  Task<GameOrderInfoEntity?> GetOrderInfoAsync(long gameId);
  Task<int> ToggleHasProtectionAsync(long gameId);
  Task<int> ToggleHasReceiptAsync(long gameId);
  Task<int> SetReceiptLocationAsync(long gameId, string location);
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
	    o.PurchaseDate,
      o.HaveReceipt,
      o.ReceiptLocation
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
    return await connection.ExecuteAsync(query, new { GameID = gameId });
  }

  public async Task<int> ToggleHasReceiptAsync(long gameId)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `HaveReceipt` = !`HaveReceipt`
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId });
  }

  public async Task<int> SetReceiptLocationAsync(long gameId, string location)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `ReceiptLocation` = @ReceiptLocation
    WHERE `GameID` = @GameID
      OR `OrderNumber` = (
        SELECT OrderNumber
        FROM `GameOrderInfo`
        WHERE `GameID` = @GameID
      )";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, ReceiptLocation = location });
  }
}
