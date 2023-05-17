using GameIndex.Models.Entities;

namespace GameIndex.Models.Dto;

public class PlatformLocationDto
{
  public int PlatformLocationID { get; set; }
  public int PlatformID { get; set; }
  public string LocationName { get; set; } = string.Empty;

  public static PlatformLocationDto FromEntity(PlatformLocationEntity entity) => new()
  {
    PlatformID = entity.PlatformID,
    PlatformLocationID = entity.PlatformLocationID,
    LocationName = entity.LocationName,
  };
}
