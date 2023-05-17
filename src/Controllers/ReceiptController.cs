using GameIndex.Models.Dto;
using GameIndex.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameIndex.Controllers;

[ApiController]
[Route("[controller]")]
public class ReceiptController : ControllerBase
{
  private readonly IGameReceiptService _receiptService;

  public ReceiptController(IGameReceiptService receiptService)
  {
    _receiptService = receiptService;
  }

  [HttpGet("order-info/{receiptId:int}")]
  public async Task<GameReceiptDto?> GetOrderInformation([FromRoute] int receiptId) =>
    await _receiptService.GetOrderInfoAsync(receiptId);

  [HttpGet("toggle-receipt-scanned/{receiptId:int}")]
  public async Task<GameReceiptDto?> ToggleReceiptScanned([FromRoute] int receiptId) =>
    await _receiptService.ToggleReceiptScannedAsync(receiptId);

  [HttpPut("set-receipt-location/{receiptId:int}")]
  public async Task<GameReceiptDto?> SetReceiptLocation([FromRoute] int receiptId, [FromBody] string location) =>
    await _receiptService.SetReceiptLocationAsync(receiptId, location);

  [HttpPut("set-game-order-url/{receiptId:int}")]
  public async Task<GameReceiptDto?> SetGameOrderUrl([FromRoute] int receiptId, [FromBody] string orderUrl) =>
    await _receiptService.SetGameOrderUrlAsync(receiptId, orderUrl);

  [HttpPut("set-game-order-number/{receiptId:int}")]
  public async Task<GameReceiptDto?> SetGameOrderNumber([FromRoute] int receiptId, [FromBody] string orderNumber) =>
    await _receiptService.SetGameOrderNumberAsync(receiptId, orderNumber);

  [HttpPut("set-game-order-date/{receiptId:int}")]
  public async Task<GameReceiptDto?> SetOrderDate([FromRoute] int receiptId, [FromBody] string orderDate) =>
    await _receiptService.SetGameOrderDateAsync(receiptId, orderDate);
}
