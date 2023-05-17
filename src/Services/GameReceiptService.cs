using GameIndex.Models.Dto;
using GameIndex.Repos;

namespace GameIndex.Services;

public interface IGameReceiptService
{
  // TODO: (IGameReceiptService.IGameReceiptService) [RENAME] Rename this 
  Task<GameReceiptDto?> GetOrderInfoAsync(int receiptId);
  // TODO: (IGameReceiptService.IGameReceiptService) [RENAME] Rename
  Task<GameReceiptDto?> ToggleReceiptScannedAsync(int receiptId);
  // TODO: (IGameReceiptService.IGameReceiptService) [RENAME] Rename
  Task<GameReceiptDto?> SetReceiptLocationAsync(int receiptId, string location);
  // TODO: (IGameReceiptService.IGameReceiptService) [RENAME] Rename
  Task<GameReceiptDto?> SetGameOrderUrlAsync(int receiptId, string orderUrl);
  // TODO: (IGameReceiptService.IGameReceiptService) [RENAME] Rename
  Task<GameReceiptDto?> SetGameOrderNumberAsync(int receiptId, string orderNumber);
  // TODO: (IGameReceiptService.IGameReceiptService) [RENAME] Rename
  Task<GameReceiptDto?> SetGameOrderDateAsync(int receiptId, string orderDate);
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

  public async Task<GameReceiptDto?> ToggleReceiptScannedAsync(int receiptId)
  {
    await _gamReceiptRepo.ToggleReceiptScannedAsync(receiptId);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(receiptId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetReceiptLocationAsync(int receiptId, string location)
  {
    await _gamReceiptRepo.SetReceiptLocationAsync(receiptId, location);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(receiptId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetGameOrderUrlAsync(int receiptId, string orderUrl)
  {
    await _gamReceiptRepo.SetGameOrderUrlAsync(receiptId, orderUrl);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(receiptId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetGameOrderNumberAsync(int receiptId, string orderNumber)
  {
    await _gamReceiptRepo.SetGameOrderNumberAsync(receiptId, orderNumber);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(receiptId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }

  public async Task<GameReceiptDto?> SetGameOrderDateAsync(int receiptId, string orderDate)
  {
    await _gamReceiptRepo.SetGameOrderDateAsync(receiptId, orderDate);
    var orderInfo = await _gamReceiptRepo.GetOrderInfoAsync(receiptId);
    return orderInfo is null ? null : GameReceiptDto.FromEntity(orderInfo);
  }
}
