using GameIndex.Models.Entities;

namespace GameIndex.Models.Dto;

public class GameReceiptDto
{
  public long GameID { get; set; }
  public bool HasProtection { get; set; }
  public string Store { get; set; } = string.Empty;
  public string ReceiptNumber { get; set; } = string.Empty;
  public double Cost { get; set; }
  public DateTime ReceiptDate { get; set; }
  public string ReceiptName { get; set; } = string.Empty;
  public string ReceiptUrl { get; set; } = string.Empty;
  public bool ReceiptScanned { get; set; }

  public static GameReceiptDto FromEntity(GameReceiptEntity entity) => new()
  {
    Cost = entity.Cost,
    ReceiptDate = entity.ReceiptDate,
    GameID = entity.GameID,
    HasProtection = entity.HasProtection,
    ReceiptNumber = entity.ReceiptNumber,
    Store = entity.Store,
    ReceiptName = entity.ReceiptName,
    ReceiptUrl = entity.ReceiptUrl,
    ReceiptScanned = entity.ReceiptScanned,
  };
}
