using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGameReceiptService
{
  Task<ReceiptDto?> GetByIDAsync(int receiptId);
  Task<ReceiptDto?> UpdateAsync(ReceiptDto receipt);
  Task<ReceiptDto?> AddReceiptAsync(long gameId);
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

  public async Task<ReceiptDto?> AddReceiptAsync(long gameId)
  {
    var dbReceipt = await _receiptRepo.GetByGameIDAsync(gameId);
    if (dbReceipt is not null) return ReceiptDto.FromEntity(dbReceipt);

    var numRows = await _receiptRepo.CreateNewReceiptAsync();
    if (numRows < 1) throw new Exception("Unable to create a new receipt");

    numRows = await _receiptRepo.AssociateNewReceiptWithGameAsync(gameId);
    if (numRows < 1) throw new Exception("Unable to associate receipt with game");

    dbReceipt = await _receiptRepo.GetByGameIDAsync(gameId);
    return dbReceipt is not null ? ReceiptDto.FromEntity(dbReceipt) : null;
  }
}
