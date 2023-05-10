using GameIndex.Models.Entities;
using GameIndex.Repos;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GamOrderInfoController : ControllerBase
{
  private readonly IGamOrderInfoRepo _gamOrderInfoRepo;

  public GamOrderInfoController(IGamOrderInfoRepo gamOrderInfoRepo)
  {
    _gamOrderInfoRepo = gamOrderInfoRepo;
  }

  [Route("{gameId:long}")]
  public async Task<GamOrderInfoEntity?> GetGameOrderInfo([FromRoute] long gameId) =>
    await _gamOrderInfoRepo.GetOrderInfoAsync(gameId);
}