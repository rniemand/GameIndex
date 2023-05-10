namespace GameIndex.Models.Entities;

public class GameEntity
{
  public long GameID { get; set; }
  public string GameName { get; set; } = string.Empty;
  public int PlatformID { get; set; }
  public int LocationID { get; set; }
  public string GameCase { get; set; } = string.Empty;
  public bool HasCover { get; set; }
  public int Rating { get; set; }
}
