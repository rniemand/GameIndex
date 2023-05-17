using GameIndex.Models.Entities;

namespace GameIndex.Models.Dto;

public class ImageDto
{
  public long GameID { get; set; }
  public string ImageType { get; set; } = "cover";
  public int ImageOrder { get; set; } = 255;
  public string ImagePath { get; set; } = string.Empty;

  public static ImageDto FromEntity(ImageEntity entity) => new()
  {
    GameID = entity.GameID,
    ImageType = entity.ImageType,
    ImageOrder = entity.ImageOrder,
    ImagePath = entity.ImagePath
  };
}
