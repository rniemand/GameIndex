using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamReceiptRepo
{
  Task<GameReceiptEntity?> GetOrderInfoAsync(int receiptId);
  Task<int> ToggleReceiptScannedAsync(int receiptId);
  Task<int> SetReceiptLocationAsync(long gameId, string location);
  Task<int> SetGameOrderUrlAsync(long gameId, string orderUrl);
  Task<int> SetGameOrderNumberAsync(long gameId, string orderNumber);
  Task<int> SetGameOrderDateAsync(long gameId, string orderDate);
}

public class GamReceiptRepo : IGamReceiptRepo
{
  public const string TableName = "GameReceipts";
  private readonly IConnectionHelper _connectionHelper;

  public GamReceiptRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<GameReceiptEntity?> GetOrderInfoAsync(int receiptId)
  {
    const string query = @$"SELECT
	    o.ReceiptID,
	    o.Store,
	    o.ReceiptNumber,
	    o.ReceiptDate,
      o.ReceiptName,
      o.ReceiptUrl,
      o.ReceiptScanned
    FROM `{TableName}` o
    WHERE o.ReceiptID = @ReceiptID
    LIMIT 1";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.QuerySingleOrDefaultAsync<GameReceiptEntity>(query, new { ReceiptID = receiptId });
  }
  
  public async Task<int> ToggleReceiptScannedAsync(int receiptId)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptScanned` = !`ReceiptScanned`
    WHERE `ReceiptID` = @ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { ReceiptID = receiptId });
  }
  
  public async Task<int> SetReceiptLocationAsync(long gameId, string location)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptName` = @ReceiptName
    WHERE `GameID` = @GameID
      OR `ReceiptNumber` = (
        SELECT ReceiptNumber
        FROM `{TableName}`
        WHERE `GameID` = @GameID
      )";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, ReceiptName = location });
  }
  
  public async Task<int> SetGameOrderUrlAsync(long gameId, string orderUrl)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptUrl` = @ReceiptUrl
    WHERE `GameID` = @GameID
      OR `ReceiptNumber` = (
        SELECT ReceiptNumber
        FROM `{TableName}`
        WHERE `GameID` = @GameID
      )";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, ReceiptUrl = orderUrl });
  }

  public async Task<int> SetGameOrderNumberAsync(long gameId, string orderNumber)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptNumber` = @ReceiptNumber
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, ReceiptNumber = orderNumber });
  }

  public async Task<int> SetGameOrderDateAsync(long gameId, string orderDate)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptDate` = @ReceiptDate
    WHERE `GameID` = @GameID
      OR `ReceiptNumber` = (
        SELECT ReceiptNumber
        FROM `{TableName}`
        WHERE `GameID` = @GameID
      )";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, ReceiptDate = orderDate });
  }
}
