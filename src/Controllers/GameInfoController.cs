using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GameInfoController : ControllerBase
{
  [HttpGet]
  [Route("")]
  public string[] GetGameNames()
  {
    return new[] { "Game 1", "Game 2" };
  }

  [HttpPost]
  [Route("")]
  public string SaveSomething(string data)
  {
    return data;
  }
}