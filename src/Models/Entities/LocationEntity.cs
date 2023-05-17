namespace GameIndex.Models.Entities;

public class LocationEntity
{
  public int LocationID { get; set; }
  public int PlatformID { get; set; }
  public string LocationName { get; set; } = string.Empty;
}
