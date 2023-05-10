using GameIndex.Models.Entities;
using GameIndex.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GamePlatformsController : ControllerBase
{
  private readonly IGamePlatformsRepo _platformsRepo;

  public GamePlatformsController(IGamePlatformsRepo platformsRepo)
  {
    _platformsRepo = platformsRepo;
  }

  public async Task<List<GamePlatformEntity>> GetAll() => await _platformsRepo.GetAllPlatformsAsync();
}