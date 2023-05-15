using GameIndex.Models.Entities;

namespace GameIndex.Models.Dto;

public class GameOrderInfoDto
{
  public long GameID { get; set; }
  public bool HasProtection { get; set; }
  public string Seller { get; set; } = string.Empty;
  public string OrderNumber { get; set; } = string.Empty;
  public double Cost { get; set; }
  public DateTime PurchaseDate { get; set; }
  public bool HaveReceipt { get; set; }
  public string ReceiptLocation { get; set; } = string.Empty;
  public string OrderUrl { get; set; } = string.Empty;

  public static GameOrderInfoDto FromEntity(GameOrderInfoEntity entity) => new()
  {
    Cost = entity.Cost,
    PurchaseDate = entity.PurchaseDate,
    GameID = entity.GameID,
    HasProtection = entity.HasProtection,
    OrderNumber = entity.OrderNumber,
    Seller = entity.Seller,
    HaveReceipt = entity.HaveReceipt,
    ReceiptLocation = entity.ReceiptLocation,
    OrderUrl = entity.OrderUrl,
  };
}
