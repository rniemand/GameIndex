using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
  [Route("game/{gameId}")]
  public ActionResult GetImage([FromRoute] int gameId)
  {
    var resolveImagePath = "\\\\192.168.0.60\\Backups\\app-data\\nas-landing-page\\data\\link-img\\aws-ses.png";
    var fileStream = System.IO.File.OpenRead(resolveImagePath);
    var contentType = "image/png";

    //if (provider.TryGetContentType(resolveImagePath, out var resolved))
    //{
    //  contentType = resolved;
    //}

    return File(fileStream, contentType);
  }
}