using GameIndex.Models.Entities;

namespace GameIndex.Models.Dto;

public class GameLocationDto
{
  public int LocationID { get; set; }
  public int PlatformID { get; set; }
  public string LocationName { get; set; } = string.Empty;

  public static GameLocationDto FromEntity(GameLocationEntity entity) => new()
  {
    PlatformID = entity.PlatformID,
    LocationID = entity.LocationID,
    LocationName = entity.LocationName,
  };
}
