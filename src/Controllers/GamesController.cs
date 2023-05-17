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

  [HttpGet("images/{gameId:long}")]
  public async Task<List<ImageDto>> GetGameImages([FromRoute] long gameId) =>
    await _gamesService.GetGameImagesAsync(gameId);
  
  [HttpPost("update")]
  public async Task<BasicGameInfoDto?> UpdateGameInfo([FromBody] BasicGameInfoDto game) =>
    await _gamesService.UpdateGameInfoAsync(game);
}
