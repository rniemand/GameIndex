using GameIndex.Models.Dto;
using GameIndex.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController : ControllerBase
{
  private readonly IImageService _imageService;
  private readonly FileExtensionContentTypeProvider _provider = new();

  public ImagesController(IImageService imageService)
  {
    _imageService = imageService;
  }

  [Route("game/cover/{platform}/{gameId:long}")]
  public async Task<ActionResult> GetImage([FromRoute] string platform, [FromRoute] long gameId)
  {
    // TODO: (ImagesController.GetImage) [OPTIMIZE] Cache mime type of file to save lookup
    var path = await _imageService.GetGameCoverImagePathAsync(platform, gameId);
    return File(System.IO.File.OpenRead(path), GetContentType(path));
  }

  [HttpGet("game/images/{gameId:long}")]
  public async Task<List<ImageDto>> GetGameImages([FromRoute] long gameId) =>
    await _imageService.GetGameImagesAsync(gameId);

  // Internal methods
  private string GetContentType(string filePath)
  {
    var contentType = "image/png";

    if (_provider.TryGetContentType(filePath, out var resolved))
      contentType = resolved;

    return contentType;
  }
}
