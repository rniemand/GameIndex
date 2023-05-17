using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Dto;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IReceiptRepo
{
  Task<ReceiptEntity?> GetByIDAsync(int receiptId);
  Task<int> UpdateAsync(ReceiptEntity receipt);
  Task<ReceiptEntity?> GetByGameIDAsync(long gameId);
  Task<int> CreateNewReceiptAsync();
  Task<int> AssociateNewReceiptWithGameAsync(long gameId);
  Task<List<ReceiptEntity>> SearchReceiptsAsync(string term);
  Task<int> AssociateGameReceiptAsync(long gameId, int receiptId);
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
      (`Store`, `ReceiptNumber`, `ReceiptDate`, `ReceiptName`, `ReceiptUrl`, `ReceiptAssociated`)
    VALUES
      (NULL, NULL, NULL, NULL, NULL, 0)";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query);
  }

  public async Task<int> AssociateNewReceiptWithGameAsync(long gameId)
  {
    const string query = @$"UPDATE `{GamesRepo.TableName}`
    SET `ReceiptID` = (
	    SELECT r.ReceiptID
	    FROM `{TableName}` r
	    WHERE r.Store IS NULL
		    AND r.ReceiptNumber IS NULL
		    AND r.ReceiptDate IS NULL
		    AND r.ReceiptName IS NULL
		    AND r.ReceiptUrl IS NULL
		    AND r.ReceiptScanned = 0
        AND r.ReceiptAssociated = 0
	    LIMIT 1
    )
    WHERE GameID = @GameID;
    UPDATE {TableName}
    SET
      `ReceiptAssociated` = 1
    WHERE Store IS NULL
		  AND ReceiptNumber IS NULL
		  AND ReceiptDate IS NULL
		  AND ReceiptName IS NULL
		  AND ReceiptUrl IS NULL
		  AND ReceiptScanned = 0
      AND ReceiptAssociated = 0";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId });
  }

  public async Task<List<ReceiptEntity>> SearchReceiptsAsync(string term)
  {
    var query = @$"SELECT *
    FROM `{TableName}` r
    WHERE
	    r.Store LIKE '%{term}%'
	    OR r.ReceiptNumber LIKE '%{term}%'
	    OR r.ReceiptName LIKE '%{term}%'
	    OR r.ReceiptUrl LIKE '%{term}%'
    ORDER BY r.ReceiptID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<ReceiptEntity>(query)).ToList();
  }

  public async Task<int> AssociateGameReceiptAsync(long gameId, int receiptId)
  {
    const string query = $@"UPDATE `{GamesRepo.TableName}`
    SET
	    `ReceiptID` = @ReceiptID
    WHERE
	    `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new
    {
      ReceiptID = receiptId,
      GameID = gameId
    });
  }
}
