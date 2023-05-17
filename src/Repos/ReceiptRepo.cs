using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IReceiptRepo
{
  Task<ReceiptEntity?> GetByIDAsync(int receiptId);
  Task<int> UpdateAsync(ReceiptEntity receipt);
  Task<ReceiptEntity?> GetByGameIDAsync(long gameId);
  Task<int> CreateNewReceiptAsync();
  Task<int> AssociateNewReceiptWithGameAsync(long gameId);
}

public class ReceiptRepo : IReceiptRepo
{
  public const string TableName = "Receipts";
  private readonly IConnectionHelper _connectionHelper;

  public ReceiptRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<ReceiptEntity?> GetByIDAsync(int receiptId)
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

  public async Task<int> UpdateAsync(ReceiptEntity receipt)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
      `Store` = @Store,
      `ReceiptNumber` = @ReceiptNumber,
      `ReceiptDate` = @ReceiptDate,
      `ReceiptName` = @ReceiptName,
      `ReceiptUrl` = @ReceiptUrl,
      `ReceiptScanned` = @ReceiptScanned
    WHERE
      `ReceiptID` = @ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, receipt);
  }

  public async Task<ReceiptEntity?> GetByGameIDAsync(long gameId)
  {
    const string query = @$"SELECT r.*
    FROM `{GamesRepo.TableName}` g
    INNER JOIN `{TableName}` r ON g.ReceiptID = r.ReceiptID
    WHERE g.GameID = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.QuerySingleOrDefaultAsync<ReceiptEntity>(query, new { GameID = gameId });
  }

  public async Task<int> CreateNewReceiptAsync()
  {
    const string query = @$"INSERT INTO {TableName}
      (`Store`, `ReceiptNumber`, `ReceiptDate`, `ReceiptName`, `ReceiptUrl`)
    VALUES
      ('', '', NULL, NULL, NULL)";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query);
  }

  public async Task<int> AssociateNewReceiptWithGameAsync(long gameId)
  {
    const string query = @$"UPDATE `{GamesRepo.TableName}`
    SET `ReceiptID` = (
	    SELECT r.ReceiptID
	    FROM `{TableName}` r
	    WHERE
		    r.Store = ''
		    AND r.ReceiptNumber = ''
		    AND r.ReceiptDate IS NULL
		    AND r.ReceiptName IS NULL
		    AND r.ReceiptUrl IS NULL
		    AND r.ReceiptScanned = 0
	    LIMIT 1
    )
    WHERE GameID = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId});
  }
}
