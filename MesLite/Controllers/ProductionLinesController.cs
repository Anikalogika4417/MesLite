using MesLite.Models;
using MesLite.Services;
using Microsoft.AspNetCore.Mvc;

namespace MesLite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductionLinesController(IProductionLinesDbActions dbActions) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAllLines(int pageIndex, int pageSize)
    {
        if (pageSize <= 0)
            return Results.BadRequest("Page size is less that 0");

        if (pageIndex <= 0)
            return Results.BadRequest("Page index is less that 0");

        return Results.Ok(await dbActions.GetProductionLinesAsync(pageIndex, pageSize));
    }

    [HttpGet("{lineId}")]
    public async Task<IResult> GetLineById(Guid lineId)
    {
        if (lineId == Guid.Empty)
            throw new ArgumentException("Line id is empty Guid");

        return Results.Ok(await dbActions.GetProductionLineByIdAsync(lineId));
    }

    [HttpPost]
    public async Task<IResult> CreateLine(ProductionLine productionLineInfo)
    {
        if (string.IsNullOrWhiteSpace(productionLineInfo.LineName))
            throw new ArgumentException("Production line name is empty");

        await dbActions.CreateProductionLineAsync(productionLineInfo);

        return Results.Ok();
    }

    [HttpDelete]
    public async Task<IResult> StopLine(Guid lineId)
    {
        if (lineId == Guid.Empty)
            throw new ArgumentException("Line id is empty Guid");

        await dbActions.StopProductionLineAsync(lineId);

        return Results.Ok();
    }
}
