using MesLite.Models;

namespace MesLite.Services;

public interface IDbActions
{
    public Task<List<ProductionLine>> GetProductionLinesAsync(int pageIndex, int pageSize, CancellationToken token = default);
    public Task<ProductionLine> GetProductionLineByIdAsync(Guid lineId, CancellationToken token = default);
    public Task CreateProductionLineAsync(ProductionLine productionLineInfo, CancellationToken token = default);
    public Task CreateBatchAsync(Batch batchInfo, CancellationToken token = default);
    public Task StopProductionLineAsync(Guid lineId, CancellationToken token = default);
}
