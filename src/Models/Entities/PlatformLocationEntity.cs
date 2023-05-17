namespace GameIndex.Models.Entities;

public class PlatformLocationEntity
{
  public int PlatformLocationID { get; set; }
  public int PlatformID { get; set; }
  public string LocationName { get; set; } = string.Empty;
}
