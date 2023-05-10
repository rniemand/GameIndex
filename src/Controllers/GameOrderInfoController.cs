using GameIndex.Models.Entities;
using GameIndex.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GameOrderInfoController : ControllerBase
{
  private readonly IGamOrderInfoRepo _gamOrderInfoRepo;

  public GameOrderInfoController(IGamOrderInfoRepo gamOrderInfoRepo)
  {
    _gamOrderInfoRepo = gamOrderInfoRepo;
  }

  [Route("{gameId:long}")]
  public async Task<GameOrderInfoEntity?> GetGameOrderInfo([FromRoute] long gameId) =>
    await _gamOrderInfoRepo.GetOrderInfoAsync(gameId);
}