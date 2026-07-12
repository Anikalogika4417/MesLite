using MesLite.Models;
using MesLite.Models.DTO;
using MesLite.Services;
using Microsoft.AspNetCore.Mvc;

namespace MesLite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatchController(IDbActions dbActions) : ControllerBase
{
    [HttpPost]
    public async Task<IResult> CreateLine(CreateBatchRequest batchInfoRequest)
    {
        if (batchInfoRequest.LineId == Guid.Empty)
            throw new ArgumentException("Production line id is empty");

        if (string.IsNullOrWhiteSpace(batchInfoRequest.ProductName))
            throw new ArgumentException("Product name is empty");

        // Mapping
        var batchInfo = new Batch()
        {
            BatchId = Guid.NewGuid(),
            LineId = batchInfoRequest.LineId,
            ProductName = batchInfoRequest.ProductName,
            StartDate = DateTimeOffset.Now,
            Status = BatchStatus.Initialized
        };


        await dbActions.CreateBatchAsync(batchInfo);

        return Results.Ok();
    }
}
