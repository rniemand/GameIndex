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

  [HttpPost("update")]
  public async Task<GameReceiptDto?> UpdateReceipt([FromBody] GameReceiptDto receipt) =>
    await _receiptService.UpdateAsync(receipt);
}
