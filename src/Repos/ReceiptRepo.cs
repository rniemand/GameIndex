using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IReceiptRepo
{
  // TODO: (IReceiptRepo.IReceiptRepo) [RENAME] Rename this
  Task<ReceiptEntity?> GetOrderInfoAsync(int receiptId);
  Task<int> UpdateReceiptAsync(ReceiptEntity receipt);
}

public class ReceiptRepo : IReceiptRepo
{
  public const string TableName = "Receipts";
  private readonly IConnectionHelper _connectionHelper;

  public ReceiptRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<ReceiptEntity?> GetOrderInfoAsync(int receiptId)
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
    return await connection.QuerySingleOrDefaultAsync<ReceiptEntity>(query, new { ReceiptID = receiptId });
  }

  public async Task<int> UpdateReceiptAsync(ReceiptEntity receipt)
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
