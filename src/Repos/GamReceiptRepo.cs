using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamReceiptRepo
{
  // TODO: (IGamReceiptRepo.IGamReceiptRepo) [RENAME] Rename this
  Task<GameReceiptEntity?> GetOrderInfoAsync(int receiptId);
  Task<int> ToggleReceiptScannedAsync(int receiptId);
  // TODO: (IGamReceiptRepo.IGamReceiptRepo) [RENAME] rename this
  Task<int> SetReceiptLocationAsync(int receiptId, string receiptName);
  // TODO: (IGamReceiptRepo.IGamReceiptRepo) [RENAME] Rename this
  Task<int> SetGameOrderUrlAsync(int receiptId, string receiptUrl);
  // TODO: (IGamReceiptRepo.IGamReceiptRepo) [RENAME] Rename this
  Task<int> SetGameOrderNumberAsync(int receiptId, string recNumber);
  // TODO: (IGamReceiptRepo.IGamReceiptRepo) [RENAME] Rename this
  Task<int> SetGameOrderDateAsync(int receiptId, string recDate);
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
  
  public async Task<int> SetReceiptLocationAsync(int receiptId, string receiptName)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptName` = @ReceiptName
    WHERE `ReceiptID` = @ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { ReceiptID = receiptId, ReceiptName = receiptName });
  }
  
  public async Task<int> SetGameOrderUrlAsync(int receiptId, string receiptUrl)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptUrl` = @ReceiptUrl
    WHERE `ReceiptID` = @ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { ReceiptID = receiptId, ReceiptUrl = receiptUrl });
  }

  public async Task<int> SetGameOrderNumberAsync(int receiptId, string recNumber)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptNumber` = @ReceiptNumber
    WHERE `ReceiptID` = @ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { ReceiptID = receiptId, ReceiptNumber = recNumber });
  }

  public async Task<int> SetGameOrderDateAsync(int receiptId, string recDate)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `ReceiptDate` = @ReceiptDate
    WHERE `ReceiptID` = @ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { ReceiptID = receiptId, ReceiptDate = recDate });
  }
}
