using GameIndex.Models.Entities;
using GameIndex.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
  private readonly IGamesRepo _gamesRepo;

  public GamesController(IGamesRepo gamesRepo)
  {
    _gamesRepo = gamesRepo;
  }

  [HttpGet("{platformId:int}")]
  public async Task<List<GameEntity>> GetAllGames([FromRoute] int platformId) => await _gamesRepo.GetAllAsync(platformId);
}