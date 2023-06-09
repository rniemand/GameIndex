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
  public async Task<ReceiptDto?> GetOrderInformation([FromRoute] int receiptId) =>
    await _receiptService.GetByIDAsync(receiptId);

  [HttpPost("update")]
  public async Task<ReceiptDto?> UpdateReceipt([FromBody] ReceiptDto receipt) =>
    await _receiptService.UpdateAsync(receipt);

  [HttpGet("create/game-id/{gameId:long}")]
  public async Task<ReceiptDto?> AddReceipt([FromRoute] long gameId) =>
    await _receiptService.AddReceiptAsync(gameId);

  [HttpGet("search/term/{term}")]
  public async Task<List<ReceiptDto>> Search([FromRoute] string term) =>
    await _receiptService.SearchAsync(term);

  [HttpPatch("associate/game-id/{gameId:long}/receipt-id/{receiptId:int}")]
  public async Task<ReceiptDto?> AssociateReceiptToGame(
    [FromRoute] long gameId,
    [FromRoute] int receiptId) =>
    await _receiptService.AssociateGameReceiptAsync(gameId, receiptId);
}
