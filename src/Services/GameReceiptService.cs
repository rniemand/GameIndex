using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGameReceiptService
{
  Task<ReceiptDto?> GetByIDAsync(int receiptId);
  Task<ReceiptDto?> UpdateAsync(ReceiptDto receipt);
  Task<ReceiptDto?> AddReceiptAsync(long gameId);
  Task<List<ReceiptDto>> SearchAsync(string term);
  Task<ReceiptDto?> AssociateGameReceiptAsync(long gameId, int receiptId);
}

public class GameReceiptService : IGameReceiptService
{
  private readonly IReceiptRepo _receiptRepo;

  public GameReceiptService(IReceiptRepo receiptRepo)
  {
    _receiptRepo = receiptRepo;
  }

  public async Task<ReceiptDto?> GetByIDAsync(int receiptId) =>
    await GetSingleOrDefaultAsync(receiptId);

  public async Task<ReceiptDto?> UpdateAsync(ReceiptDto receipt)
  {
    // TODO: (GameReceiptService.UpdateAsync) [HANDLE] handle when nothing is updated
    var numRows = await _receiptRepo.UpdateAsync(receipt.ToEntity());
    if (numRows < 0) throw new Exception("Failed to update receipt"); 
    return await GetSingleOrDefaultAsync(receipt.ReceiptID);
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

  public async Task<List<ReceiptDto>> SearchAsync(string term)
  {
    var dbReceipts = await _receiptRepo.SearchReceiptsAsync(term);
    return dbReceipts.Select(ReceiptDto.FromEntity).ToList();
  }

  public async Task<ReceiptDto?> AssociateGameReceiptAsync(long gameId, int receiptId)
  {
    // TODO: (GameReceiptService.AssociateGameReceiptAsync) [HANDLE] handle this better
    var numRows = await _receiptRepo.AssociateGameReceiptAsync(gameId, receiptId);
    if (numRows < 1) throw new Exception("Unable to associate game with receipt");
    return await GetSingleOrDefaultAsync(receiptId);
  }


  // Internal methods
  private async Task<ReceiptDto?> GetSingleOrDefaultAsync(int receiptId)
  {
    var gameOrderInfoEntity = await _receiptRepo.GetByIDAsync(receiptId);
    return gameOrderInfoEntity is null ? null : ReceiptDto.FromEntity(gameOrderInfoEntity);
  }
}
