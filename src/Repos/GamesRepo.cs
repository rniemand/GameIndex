
using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;
using Microsoft.Extensions.Hosting;

namespace GameIndex.Repos;

public interface IGamesRepo
{
  Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId);
  Task<int> UpdateGameInfoAsync(BasicGameInfoEntity game);
  Task<int> ToggleProtectionAsync(long gameId);
  Task<int> SetGamePriceAsync(long gameId, double price);
}

public class GamesRepo : IGamesRepo
{
  public const string TableName = "Games";
  private readonly IConnectionHelper _connectionHelper;

  public GamesRepo(IConnectionHelper connectionHelper)
  {
    _connectionHelper = connectionHelper;
  }

  public async Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId)
  {
    const string query = @$"SELECT
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
      g.HasProtection,
	    o.Store,
	    o.ReceiptNumber,
	    g.Cost,
	    o.ReceiptDate,
      CASE WHEN gs.GameID IS NOT NULL THEN TRUE ELSE FALSE END AS `GameSold`,
      CASE WHEN o.Store IS NOT NULL THEN TRUE ELSE FALSE END AS `HaveReceipt`,
      o.ReceiptName,
      o.ReceiptScanned
    FROM `{TableName}` g
	    INNER JOIN `{GamePlatformsRepo.TableName}` p ON p.PlatformID = g.PlatformID
	    INNER JOIN `{GameLocationRepo.TableName}` l ON l.LocationID = g.LocationID
	    LEFT JOIN `{GameImagesRepo.TableName}` i ON i.GameID = g.GameID AND i.ImageType = 'cover'
      LEFT JOIN `{GamReceiptRepo.TableName}` o ON o.GameID = g.GameID
      LEFT JOIN `GameSales` gs ON gs.GameID = g.GameID
    WHERE g.PlatformID = @PlatformID
    ORDER BY g.GameName";
    await using var connection = _connectionHelper.GetCoreConnection();
    return (await connection.QueryAsync<BasicGameInfoEntity>(query, new { PlatformID = platformId })).ToList();
  }

  public async Task<int> UpdateGameInfoAsync(BasicGameInfoEntity game)
  {
    const string query = @$"UPDATE `{TableName}`
    SET
	    `GameName` = @GameName,
	    `GameCase` = @GameCase,
      `Cost` = @Cost,
      `HasProtection` = @HasProtection
    WHERE
	    `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, game);
  }

  public async Task<int> ToggleProtectionAsync(long gameId)
  {
    const string query = @$"UPDATE `{TableName}`
    SET `HasProtection` = !`HasProtection`
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId });
  }

  public async Task<int> SetGamePriceAsync(long gameId, double price)
  {
    const string query = @$"UPDATE `{TableName}`
    SET `Cost` = @Cost
    WHERE `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, new { GameID = gameId, Cost = price });
  }
}
