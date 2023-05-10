namespace GameIndex.Models;

public class GameIndexConfig
{
  [ConfigurationKeyName("configRootDir")]
  public string ContentRootDir { get; set; } = string.Empty;
}
