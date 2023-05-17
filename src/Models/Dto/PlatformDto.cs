using GameIndex.Models.Entities;

namespace GameIndex.Models.Dto;

public class PlatformDto
{
  public int PlatformID { get; set; }
  public string PlatformName { get; set; } = string.Empty;

  public static PlatformDto FromEntity(PlatformEntity entity) => new()
  {
    PlatformID = entity.PlatformID,
    PlatformName = entity.PlatformName,
  };
}
