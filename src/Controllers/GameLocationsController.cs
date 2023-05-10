using GameIndex.Models.Entities;
using GameIndex.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GameLocationsController : ControllerBase
{
  private readonly IGameLocationRepo _gameLocationRepo;

  public GameLocationsController(IGameLocationRepo gameLocationRepo)
  {
    _gameLocationRepo = gameLocationRepo;
  }

  [Route("{locationId:int}")]
  public async Task<List<GameLocationEntity>> GetGameLocations([FromRoute] int locationId) =>
    await _gameLocationRepo.GetLocationsAsync(locationId);
}