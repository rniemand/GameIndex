using GameIndex.Models.Dto;
using GameIndex.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformsController : ControllerBase
{
  private readonly IPlatformService _platformService;

  public PlatformsController(IPlatformService platformService)
  {
    _platformService = platformService;
  }

  [Route("list")]
  public async Task<List<PlatformDto>> GetAll() =>
    await _platformService.GetAllAsync();
}
