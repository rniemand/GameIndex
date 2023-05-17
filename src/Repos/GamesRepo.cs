using Dapper;
using GameIndex.Helpers;
using GameIndex.Models.Entities;

namespace GameIndex.Repos;

public interface IGamesRepo
{
  Task<List<BasicGameInfoEntity>> GetAllAsync(int platformId);
  // TODO: (IGamesRepo.IGamesRepo) [RENAME] Rename this
  Task<int> UpdateGameInfoAsync(BasicGameInfoEntity game);
  Task<BasicGameInfoEntity?> GetByIDAsync(long gameId);
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
	    INNER JOIN `{PlatformsRepo.TableName}` p ON p.PlatformID = g.PlatformID
	    INNER JOIN `{LocationRepo.TableName}` l ON l.LocationID = g.LocationID
	    LEFT JOIN `{ImagesRepo.TableName}` i ON i.GameID = g.GameID AND i.ImageType = 'cover'
      LEFT JOIN `{ReceiptRepo.TableName}` r ON r.ReceiptID = g.ReceiptID
      LEFT JOIN `{SalesRepo.TableName}` gs ON gs.GameID = g.GameID
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
	    `HasGameBox` = @HasGameBox,
      `HasProtection` = @HasProtection,
      `GameRating` = @GameRating,
      `GamePrice` = @GamePrice,
      `GameCaseLocation` = @GameCaseLocation
    WHERE
	    `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.ExecuteAsync(query, game);
  }

  public async Task<BasicGameInfoEntity?> GetByIDAsync(long gameId)
  {
    const string query = @$"SELECT *
    FROM `{TableName}`
    WHERE
	    `GameID` = @GameID";
    await using var connection = _connectionHelper.GetCoreConnection();
    return await connection.QuerySingleOrDefaultAsync<BasicGameInfoEntity>(query, new{ GameID = gameId });
  }
}
