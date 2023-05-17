namespace GameIndex.Models.Entities;

public class ImageEntity
{
  public long GameID { get; set; }
  public string ImageType { get; set; } = "cover";
  public int ImageOrder { get; set; } = 255;
  public string ImagePath { get; set; } = string.Empty;
}
