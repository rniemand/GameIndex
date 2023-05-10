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
}