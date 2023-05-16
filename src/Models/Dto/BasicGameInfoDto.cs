using GameIndex.Models.Entities;

namespace GameIndex.Models.Dto;

public class BasicGameInfoDto
{
  public long GameID { get; set; }
  public string GameName { get; set; } = string.Empty;
  public int PlatformID { get; set; }
  public int LocationID { get; set; }
  public string GameCase { get; set; } = string.Empty;
  public bool HasCover { get; set; }
  public int Rating { get; set; }
  public string ImagePath { get; set; } = string.Empty;
  public string LocationName { get; set; } = string.Empty;
  public string PlatformName { get; set; } = string.Empty;
  public bool HasProtection { get; set; }
  public string Store { get; set; } = string.Empty;
  public string ReceiptNumber { get; set; } = string.Empty;
  public double Cost { get; set; }
  public DateTime? ReceiptDate { get; set; }
  public bool GameSold { get; set; }
  public bool HaveReceipt { get; set; }
  public string ReceiptName { get; set; } = string.Empty;
  public bool ReceiptScanned { get; set; }

  public static BasicGameInfoDto FromEntity(BasicGameInfoEntity entity) => new()
  {
    ImagePath = entity.ImagePath,
    GameCase = entity.GameCase,
    GameID = entity.GameID,
    GameName = entity.GameName,
    HasCover = entity.HasCover,
    LocationID = entity.LocationID,
    LocationName = entity.LocationName,
    PlatformID = entity.PlatformID,
    PlatformName = entity.PlatformName,
    Rating = entity.Rating,
    Cost = entity.Cost,
    ReceiptDate = entity.ReceiptDate,
    HasProtection = entity.HasProtection,
    ReceiptNumber = entity.ReceiptNumber,
    Store = entity.Store,
    GameSold = entity.GameSold,
    HaveReceipt = entity.HaveReceipt,
    ReceiptName = entity.ReceiptName,
    ReceiptScanned = entity.ReceiptScanned,
  };

  public BasicGameInfoEntity ToEntity() => new()
  {
    Cost = Cost,
    GameCase = GameCase,
    GameID = GameID,
    GameName = GameName,
    GameSold = GameSold,
    HasCover = HasCover,
    LocationID = LocationID,
    LocationName = LocationName,
    PlatformID = PlatformID,
    PlatformName = PlatformName,
    Rating = Rating,
    HasProtection = HasProtection,
    ImagePath = ImagePath,
    ReceiptNumber = ReceiptNumber,
    ReceiptDate = ReceiptDate,
    Store= Store,
    HaveReceipt = HaveReceipt,
    ReceiptName = ReceiptName,
    ReceiptScanned = ReceiptScanned,
  };
}
