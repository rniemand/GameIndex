namespace GameIndex.Models.Entities;

public class GameOrderInfoEntity
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
  public bool ReceiptScanned { get; set; }
}
