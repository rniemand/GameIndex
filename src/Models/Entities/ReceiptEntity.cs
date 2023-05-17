namespace GameIndex.Models.Entities;

public class ReceiptEntity
{
  public int ReceiptID { get; set; }
  public string Store { get; set; } = string.Empty;
  public string ReceiptNumber { get; set; } = string.Empty;
  public DateTime ReceiptDate { get; set; }
  public string ReceiptName { get; set; } = string.Empty;
  public string ReceiptUrl { get; set; } = string.Empty;
  public bool ReceiptScanned { get; set; }
}
