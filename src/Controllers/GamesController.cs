using GameIndex.Models.Dto;
using GameIndex.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
  private readonly IGamesService _gamesService;

  public GamesController(IGamesService gamesService)
  {
    _gamesService = gamesService;
  }

  [HttpGet("platform/{platformId:int}")]
  public async Task<List<BasicGameInfoDto>> GetPlatformGames([FromRoute] int platformId) =>
    await _gamesService.GetPlatformGamesAsync(platformId);
  
  [HttpPost("update")]
  public async Task<BasicGameInfoDto?> Update([FromBody] BasicGameInfoDto game) =>
    await _gamesService.UpdateGameInfoAsync(game);
}
