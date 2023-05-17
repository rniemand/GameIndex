using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGameReceiptService
{
  Task<ReceiptDto?> GetByIDAsync(int receiptId);
  Task<ReceiptDto?> UpdateAsync(ReceiptDto receipt);
}

public class GameReceiptService : IGameReceiptService
{
  private readonly IReceiptRepo _receiptRepo;

  public GameReceiptService(IReceiptRepo receiptRepo)
  {
    _receiptRepo = receiptRepo;
  }

  public async Task<ReceiptDto?> GetByIDAsync(int receiptId)
  {
    var gameOrderInfoEntity = await _receiptRepo.GetByIDAsync(receiptId);
    return gameOrderInfoEntity is null ? null : ReceiptDto.FromEntity(gameOrderInfoEntity);
  }

  public async Task<ReceiptDto?> UpdateAsync(ReceiptDto receipt)
  {
    // TODO: (GameReceiptService.UpdateAsync) [HANDLE] handle when nothing is updated
    await _receiptRepo.UpdateAsync(receipt.ToEntity());
    var gameOrderInfoEntity = await _receiptRepo.GetByIDAsync(receipt.ReceiptID);
    return gameOrderInfoEntity is null ? null : ReceiptDto.FromEntity(gameOrderInfoEntity);
  }
}
