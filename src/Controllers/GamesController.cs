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

  [HttpGet("{platformId:int}")]
  public async Task<List<BasicGameInfoDto>> GetAllGames([FromRoute] int platformId) =>
    await _gamesService.ListAllGamesAsync(platformId);

  [HttpGet("order-info/{gameId:long}")]
  public async Task<GameOrderInfoDto?> GetOrderInformation([FromRoute] long gameId) =>
    await _gamesService.GetOrderInfoAsync(gameId);

  [HttpGet("images/{gameId:long}")]
  public async Task<List<GameImageDto>> GetGameImages([FromRoute] long gameId) =>
    await _gamesService.GetImagesAsync(gameId);

  [HttpGet("locations/{platformId:int}")]
  public async Task<List<GameLocationDto>> GetGameLocations([FromRoute] int platformId) =>
    await _gamesService.GetLocationsAsync(platformId);

  [HttpPut("set-location/{gameId:long}/{locationId:int}")]
  public async Task<int> SetGameLocation([FromRoute] long gameId, [FromRoute] int locationId) =>
    await _gamesService.SetGameLocationAsync(gameId, locationId);

  [HttpPost("update")]
  public async Task<int> UpdateGameInfo([FromBody] BasicGameInfoDto game) =>
    await _gamesService.UpdateGameInfoAsync(game);

  [HttpGet("toggle-protection/{gameId:long}")]
  public async Task<GameOrderInfoDto?> ToggleGameProtection([FromRoute] long gameId) =>
    await _gamesService.ToggleGameProtectionAsync(gameId);
}
