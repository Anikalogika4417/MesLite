using MesLite.Data;
using MesLite.Models;
using Microsoft.EntityFrameworkCore;

namespace MesLite.Services;

public class ProductionLinesDbActions(AppDbContext context, ILogger<ProductionLinesDbActions> logger) : IProductionLinesDbActions
{
    public async Task<List<ProductionLine>> GetProductionLinesAsync(int pageIndex, int pageSize, CancellationToken token = default)
    {
        logger.LogInformation("Start getting all production lines");
        try
        {
            List<ProductionLine> lines = await context.ProductionLines
                .OrderBy(l => l.LineName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(token);

            logger.LogInformation("Retrieved {count} production lines", lines.Count);
            return lines;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Getting production lines finished with error");
            throw;
        }

    }

    public async Task CreateProductionLineAsync(ProductionLine productionLineInfo, CancellationToken token = default)
    {
        logger.LogInformation("Start creating new production line with {id}", productionLineInfo.LineId);
        try
        {
            context.ProductionLines.Add(productionLineInfo);
            await context.SaveChangesAsync(token);
            logger.LogInformation("New production line with {id} was creatated", productionLineInfo.LineId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Creating new production line with {id} finished with error", productionLineInfo.LineId);
            throw;
        }
    }
}
