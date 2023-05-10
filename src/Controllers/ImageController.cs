using GameIndex.Helpers;
using GameIndex.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RnCore.Abstractions;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
  private readonly IAppPathHelper _pathHelper;
  private readonly IGameImagesRepo _gameImagesRepo;
  private readonly IFileAbstraction _file;
  private readonly FileExtensionContentTypeProvider _provider = new();

  public ImageController(IAppPathHelper pathHelper, IGameImagesRepo gameImagesRepo, IFileAbstraction file)
  {
    _pathHelper = pathHelper;
    _gameImagesRepo = gameImagesRepo;
    _file = file;
  }

  [Route("game/{gameId:long}")]
  public async Task<ActionResult> GetImage([FromRoute] long gameId)
  {
    var gameCoverEntity = await _gameImagesRepo.GetGameCoverImageAsync(gameId);
    var fallbackPath = _pathHelper.ResolveImagePath("covers/switch/placeholder.png");

    if (!_file.Exists(fallbackPath))
      throw new Exception("Unable to resolve placeholder image");

    if (gameCoverEntity is null)
      return File(System.IO.File.OpenRead(fallbackPath), GetContentType(fallbackPath));

    var resolveImagePath = _pathHelper.ResolveImagePath(gameCoverEntity.ImagePath);

    // todo: allow for system type
    if (!_file.Exists(resolveImagePath))
      return File(System.IO.File.OpenRead(fallbackPath), GetContentType(fallbackPath));

    return File(System.IO.File.OpenRead(resolveImagePath), GetContentType(resolveImagePath));
  }

  private string GetContentType(string filePath)
  {
    var contentType = "image/png";

    if (_provider.TryGetContentType(filePath, out var resolved))
      contentType = resolved;

    return contentType;
  }
}