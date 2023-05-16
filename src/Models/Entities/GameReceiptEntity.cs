namespace GameIndex.Models.Entities;

public class GameReceiptEntity
{
  public long GameID { get; set; }
  // TODO: [DROP] (GameReceiptEntity.GameReceiptEntity) Drop this property
  public bool HasProtection { get; set; }
  public string Store { get; set; } = string.Empty;
  public string ReceiptNumber { get; set; } = string.Empty;
  // TODO: [REMOVE] (GameReceiptEntity.GameReceiptEntity) Remove this
  public double Cost { get; set; }
  public DateTime ReceiptDate { get; set; }
  public string ReceiptName { get; set; } = string.Empty;
  public string ReceiptUrl { get; set; } = string.Empty;
  public bool ReceiptScanned { get; set; }
}
