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

  [HttpGet("")]
  public async Task<List<GameEntity>> GetAllGames()
  {
    var games = await _gamesRepo.GetAllAsync();
    return games;
  }
}