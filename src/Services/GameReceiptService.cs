using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGameReceiptService
{
  // TODO: (IGameReceiptService.IGameReceiptService) [RENAME] Rename this 
  Task<GameReceiptDto?> GetOrderInfoAsync(int receiptId);
  Task<GameReceiptDto?> UpdateAsync(GameReceiptDto receipt);
}

public class GameReceiptService : IGameReceiptService
{
  private readonly IGamReceiptRepo _gamReceiptRepo;

  public GameReceiptService(IGamReceiptRepo gamReceiptRepo)
  {
    _gamReceiptRepo = gamReceiptRepo;
  }

  public async Task<GameReceiptDto?> GetOrderInfoAsync(int receiptId)
  {
    var gameOrderInfoEntity = await _gamReceiptRepo.GetOrderInfoAsync(receiptId);
    return gameOrderInfoEntity is null ? null : GameReceiptDto.FromEntity(gameOrderInfoEntity);
  }

  public async Task<GameReceiptDto?> UpdateAsync(GameReceiptDto receipt)
  {
    // TODO: (GameReceiptService.UpdateAsync) [HANDLE] handle when nothing is updated
    await _gamReceiptRepo.UpdateReceiptAsync(receipt.ToEntity());
    var gameOrderInfoEntity = await _gamReceiptRepo.GetOrderInfoAsync(receipt.ReceiptID);
    return gameOrderInfoEntity is null ? null : GameReceiptDto.FromEntity(gameOrderInfoEntity);
  }
}
