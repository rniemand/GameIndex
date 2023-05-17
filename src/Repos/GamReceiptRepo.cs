using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamReceiptRepo
{
  // TODO: (IGamReceiptRepo.IGamReceiptRepo) [RENAME] Rename this
  Task<GameReceiptEntity?> GetOrderInfoAsync(int receiptId);
  Task<int> UpdateReceiptAsync(GameReceiptEntity receipt);
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

  public async Task<int> UpdateReceiptAsync(GameReceiptEntity receipt)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `Store` = @Store,
      `ReceiptNumber` = @ReceiptNumber,
      `ReceiptDate` = @ReceiptDate
      `ReceiptName` = @ReceiptName
      `ReceiptUrl` = @ReceiptUrl
      `ReceiptScanned` = @ReceiptScanned
    WHERE
      `ReceiptID` = @ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, receipt);
  }
}
