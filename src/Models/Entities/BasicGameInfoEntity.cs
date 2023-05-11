﻿namespace GameIndex.Models.Entities;

public class BasicGameInfoEntity
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
}