using MesLite.Data;
using MesLite.Helpers.Exceptions;
using MesLite.Models;
using Microsoft.EntityFrameworkCore;

namespace MesLite.Services;

public class DbActions(AppDbContext context, ILogger<DbActions> logger) : IDbActions
{
    #region Get
    public async Task<List<ProductionLine>> GetProductionLinesAsync(int pageIndex, int pageSize, CancellationToken token = default)
    {
        logger.LogInformation("Start getting all production lines");

        List<ProductionLine> lines = await context.ProductionLines
            .Where(l => l.Status != LineStatus.Stopped)  
            .OrderBy(l => l.LineName)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(token);

        logger.LogInformation("Retrieved {count} production lines", lines.Count);

        return lines;
    }

    public async Task<ProductionLine> GetProductionLineByIdAsync(Guid lineId, CancellationToken token = default)
    {
        logger.LogInformation("Start getting production line with id: {id}", lineId);

        var line = await context.ProductionLines
                .FirstOrDefaultAsync(l => l.LineId == lineId, token);

        if (line is null)
            throw new EntityNotFoundException(nameof(ProductionLine), lineId);

        logger.LogInformation("Retrieved production line with id: {id}", lineId);

        return line;
    }
    #endregion

    public async Task CreateProductionLineAsync(ProductionLine productionLineInfo, CancellationToken token = default)
    {
        logger.LogInformation("Start creating new production line with {id}", productionLineInfo.LineId);

        context.ProductionLines.Add(productionLineInfo);
        await context.SaveChangesAsync(token);

        logger.LogInformation("New production line with {id} was creatated", productionLineInfo.LineId);
    }

    public async Task CreateBatchAsync(Batch batchInfo, CancellationToken token = default)
    {
        logger.LogInformation("Start creating new batch with {id}", batchInfo.BatchId);

        // Check that line exist
        var line = await context.ProductionLines.FirstOrDefaultAsync(l => l.LineId ==  batchInfo.LineId, token);

        if (line is null)
            throw new EntityNotFoundException(nameof(ProductionLine), batchInfo.LineId);

        context.Batches.Add(batchInfo);
        await context.SaveChangesAsync(token);

        logger.LogInformation("New batch with {id} was creatated", batchInfo.BatchId);
    }

    #region Delete
    public async Task StopProductionLineAsync(Guid lineId, CancellationToken token = default)
    {
        logger.LogInformation("Start deleting production line with {id}", lineId);

        var line = await context.ProductionLines
        .FirstOrDefaultAsync(l => l.LineId == lineId, token);

        if (line is null)
            throw new EntityNotFoundException(nameof(ProductionLine), lineId);

        line.Status = LineStatus.Stopped;

        await context.SaveChangesAsync(token);

        logger.LogInformation("Production line with {id} was stopped", lineId);
    }
    #endregion
}
