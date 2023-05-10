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
    Rating = entity.Rating
  };
}