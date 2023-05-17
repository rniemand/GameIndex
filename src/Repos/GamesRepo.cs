using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamesRepo
{
  Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId);
  // TODO: (IGamesRepo.IGamesRepo) [RENAME] Rename this
  Task<int> UpdateGameInfoAsync(BasicGameInfoEntity game);
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
	    g.GameCaseLocation,
	    g.HasGameBox,
	    g.GameRating,
	    l.LocationName,
	    p.PlatformName,
	    i.ImagePath,
      g.HasProtection,
	    r.Store,
	    r.ReceiptNumber,
	    g.GamePrice,
	    r.ReceiptDate,
      CASE WHEN gs.GameID IS NOT NULL THEN TRUE ELSE FALSE END AS `GameSold`,
      CASE WHEN r.Store IS NOT NULL THEN TRUE ELSE FALSE END AS `HaveReceipt`,
      r.ReceiptName,
      r.ReceiptScanned,
      r.ReceiptID
    FROM `{TableName}` g
	    INNER JOIN `{GamePlatformsRepo.TableName}` p ON p.PlatformID = g.PlatformID
	    INNER JOIN `{GameLocationRepo.TableName}` l ON l.LocationID = g.LocationID
	    LEFT JOIN `{GameImagesRepo.TableName}` i ON i.GameID = g.GameID AND i.ImageType = 'cover'
      LEFT JOIN `{GamReceiptRepo.TableName}` r ON r.ReceiptID = g.ReceiptID
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
}
