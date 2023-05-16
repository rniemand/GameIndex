using GameIndex.Models.Dto;
using GameIndex.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
  private readonly IGamesService _gamesService;

  public GamesController(IGamesService gamesService)
  {
    _gamesService = gamesService;
  }

  [HttpGet("{platformId:int}")]
  public async Task<List<BasicGameInfoDto>> GetAllGames([FromRoute] int platformId) =>
    await _gamesService.ListAllGamesAsync(platformId);

  [HttpGet("order-info/{gameId:long}")]
  public async Task<GameOrderInfoDto?> GetOrderInformation([FromRoute] long gameId) =>
    await _gamesService.GetOrderInfoAsync(gameId);

  [HttpGet("images/{gameId:long}")]
  public async Task<List<GameImageDto>> GetGameImages([FromRoute] long gameId) =>
    await _gamesService.GetImagesAsync(gameId);

  [HttpGet("locations/{platformId:int}")]
  public async Task<List<GameLocationDto>> GetGameLocations([FromRoute] int platformId) =>
    await _gamesService.GetLocationsAsync(platformId);

  [HttpPut("set-location/{gameId:long}/{locationId:int}")]
  public async Task<int> SetGameLocation([FromRoute] long gameId, [FromRoute] int locationId) =>
    await _gamesService.SetGameLocationAsync(gameId, locationId);

  [HttpPost("update")]
  public async Task<int> UpdateGameInfo([FromBody] BasicGameInfoDto game) =>
    await _gamesService.UpdateGameInfoAsync(game);

  [HttpGet("toggle-protection/{gameId:long}")]
  public async Task<GameOrderInfoDto?> ToggleGameProtection([FromRoute] long gameId) =>
    await _gamesService.ToggleGameProtectionAsync(gameId);

  [HttpGet("toggle-receipt-scanned/{gameId:long}")]
  public async Task<GameOrderInfoDto?> ToggleReceiptScanned([FromRoute] long gameId) =>
    await _gamesService.ToggleReceiptScannedAsync(gameId);

  [HttpGet("toggle-receipt/{gameId:long}")]
  public async Task<GameOrderInfoDto?> ToggleGameReceipt([FromRoute] long gameId) =>
    await _gamesService.ToggleGameReceiptAsync(gameId);

  [HttpPut("set-receipt-location/{gameId:long}")]
  public async Task<GameOrderInfoDto?> SetReceiptLocation([FromRoute] long gameId, [FromBody] string location) =>
    await _gamesService.SetReceiptLocationAsync(gameId, location);

  [HttpPut("set-game-price/{gameId:long}")]
  public async Task<GameOrderInfoDto?> SetGamePrice([FromRoute] long gameId, [FromBody] double price) =>
    await _gamesService.SetGamePriceAsync(gameId, price);

  [HttpPut("set-game-order-url/{gameId:long}")]
  public async Task<GameOrderInfoDto?> SetGameOrderUrl([FromRoute] long gameId, [FromBody] string orderUrl) =>
    await _gamesService.SetGameOrderUrlAsync(gameId, orderUrl);

  [HttpPut("set-game-order-number/{gameId:long}")]
  public async Task<GameOrderInfoDto?> SetGameOrderNumber([FromRoute] long gameId, [FromBody] string orderNumber) =>
    await _gamesService.SetGameOrderNumberAsync(gameId, orderNumber);

  [HttpPut("set-game-order-date/{gameId:long}")]
  public async Task<GameOrderInfoDto?> SetOrderDate([FromRoute] long gameId, [FromBody] string orderDate) =>
    await _gamesService.SetGameOrderDateAsync(gameId, orderDate);
}
