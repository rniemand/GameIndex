
using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamesRepo
{
  Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId);
  Task<int> UpdateGameInfoAsync(BasicGameInfoEntity game);
}

public class GamesRepo : IGamesRepo
{
  private readonly IConnectionHelper _connectionHelper;

  public GamesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId)
  {
    const string query = @"SELECT
	    g.GameID,
	    g.GameName,
	    g.PlatformID,
	    g.LocationID,
	    g.GameCase,
	    g.HasCover,
	    g.Rating,
	    l.LocationName,
	    p.PlatformName,
	    i.ImagePath,
      o.HasProtection,
	    o.Seller,
	    o.OrderNumber,
	    o.Cost,
	    o.PurchaseDate,
      CASE WHEN gs.GameID IS NOT NULL THEN TRUE ELSE FALSE END AS `GameSold`,
      o.HaveReceipt,
      o.ReceiptLocation,
      o.ReceiptScanned
    FROM `Games` g
	    INNER JOIN `GamePlatforms` p ON p.PlatformID = g.PlatformID
	    INNER JOIN `GameLocations` l ON l.LocationID = g.LocationID
	    LEFT JOIN `GameImages` i ON i.GameID = g.GameID AND i.ImageType = 'cover'
      LEFT JOIN `GameOrderInfo` o ON o.GameID = g.GameID
      LEFT JOIN `GameSales` gs ON gs.GameID = g.GameID
    WHERE g.PlatformID = @PlatformID
    ORDER BY g.GameName";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<BasicGameInfoEntity>(query, new { PlatformID = platformId })).ToList();
  }

  public async Task<int> UpdateGameInfoAsync(BasicGameInfoEntity game)
  {
    const string query = @"UPDATE `Games`
    SET
	    `GameName` = @GameName,
	    `GameCase` = @GameCase
    WHERE
	    `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, game);
  }
}
