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

  public ImageController(IAppPathHelper pathHelper, IGameImagesRepo gameImagesRepo, IFileAbstraction file)
  {
    _pathHelper = pathHelper;
    _gameImagesRepo = gameImagesRepo;
    _file = file;
  }

  [Route("game/{gameId}")]
  public async Task<ActionResult> GetImage([FromRoute] long gameId)
  {
    var gameCoverEntity = await _gameImagesRepo.GetGameCoverImageAsync(gameId);

    // todo: handle nulls
    if (gameCoverEntity is null)
      return NotFound();

    // todo: handle this better
    var resolveImagePath = _pathHelper.ResolveImagePath(gameCoverEntity.ImagePath);
    if(!_file.Exists(resolveImagePath))
      return NotFound();

    var provider = new FileExtensionContentTypeProvider();
    var contentType = "image/png";
    if (provider.TryGetContentType(resolveImagePath, out var resolved))
      contentType = resolved;

    var fileStream = System.IO.File.OpenRead(resolveImagePath);
    return File(fileStream, contentType);
  }
}