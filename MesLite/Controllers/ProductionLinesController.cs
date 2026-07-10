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

    [HttpPost]
    public async Task<IResult> CreateLine(ProductionLine productionLineInfo)
    {
        if (string.IsNullOrWhiteSpace(productionLineInfo.LineName))
            return Results.BadRequest("Production line name is empty");

        await dbActions.CreateProductionLineAsync(productionLineInfo);

        return Results.Ok();
    }
}
