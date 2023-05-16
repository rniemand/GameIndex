using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamOrderInfoRepo
{
  Task<GameOrderInfoEntity?> GetOrderInfoAsync(long gameId);
  Task<int> ToggleHasProtectionAsync(long gameId);
  Task<int> ToggleReceiptScannedAsync(long gameId);
  Task<int> ToggleHasReceiptAsync(long gameId);
  Task<int> SetReceiptLocationAsync(long gameId, string location);
  Task<int> SetGamePriceAsync(long gameId, double price);
  Task<int> SetGameOrderUrlAsync(long gameId, string orderUrl);
  Task<int> SetGameOrderNumberAsync(long gameId, string orderNumber);
  Task<int> SetGameOrderDateAsync(long gameId, string orderDate);
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
      o.ReceiptLocation,
      o.OrderUrl,
      o.ReceiptScanned
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

  public async Task<int> ToggleReceiptScannedAsync(long gameId)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `ReceiptScanned` = !`ReceiptScanned`
    WHERE `GameID` = @GameID
      OR `ReceiptLocation` = (
        SELECT ReceiptLocation
        FROM `GameOrderInfo`
        WHERE `GameID` = @GameID
      )";
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

  public async Task<int> SetGamePriceAsync(long gameId, double price)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `Cost` = @Cost
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, Cost = price });
  }

  public async Task<int> SetGameOrderUrlAsync(long gameId, string orderUrl)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `OrderUrl` = @OrderUrl
    WHERE `GameID` = @GameID
      OR `OrderNumber` = (
        SELECT OrderNumber
        FROM `GameOrderInfo`
        WHERE `GameID` = @GameID
      )";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, OrderUrl = orderUrl });
  }

  public async Task<int> SetGameOrderNumberAsync(long gameId, string orderNumber)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `OrderNumber` = @OrderNumber
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, OrderNumber = orderNumber });
  }

  public async Task<int> SetGameOrderDateAsync(long gameId, string orderDate)
  {
    const string query = @"UPDATE `GameOrderInfo`
    SET
      `PurchaseDate` = @PurchaseDate
    WHERE `GameID` = @GameID
      OR `OrderNumber` = (
        SELECT OrderNumber
        FROM `GameOrderInfo`
        WHERE `GameID` = @GameID
      )";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, PurchaseDate = orderDate });
  }
}
