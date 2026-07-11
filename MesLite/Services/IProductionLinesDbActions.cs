using MesLite.Models;

namespace MesLite.Services;

public interface IProductionLinesDbActions
{
    public Task<List<ProductionLine>> GetProductionLinesAsync(int pageIndex, int pageSize, CancellationToken token = default);
    public Task<ProductionLine> GetProductionLineByIdAsync(Guid lineId, CancellationToken token = default);
    public Task CreateProductionLineAsync(ProductionLine productionLineInfo, CancellationToken token = default);
    public Task StopProductionLineAsync(Guid lineId, CancellationToken token = default);
}
