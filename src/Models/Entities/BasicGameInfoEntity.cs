namespace GameIndex.Models.Entities;

public class BasicGameInfoEntity
{
  public long GameID { get; set; }
  public string GameName { get; set; } = string.Empty;
  public int PlatformID { get; set; }
  public int LocationID { get; set; }
  public string GameCaseLocation { get; set; } = string.Empty;
  public bool HasGameBox { get; set; }
  public int GameRating { get; set; }
  public string ImagePath { get; set; } = string.Empty;
  public string LocationName { get; set; } = string.Empty;
  public string PlatformName { get; set; } = string.Empty;
  public bool HasProtection { get; set; }
  public string Store { get; set; } = string.Empty;
  public string ReceiptNumber { get; set; } = string.Empty;
  public double GamePrice { get; set; }
  public DateTime? ReceiptDate { get; set; }
  public bool GameSold { get; set; }
  public bool HaveReceipt { get; set; }
  public string ReceiptName { get; set; } = string.Empty;
  public bool ReceiptScanned { get; set; }
  public int ReceiptID { get; set; }
}
