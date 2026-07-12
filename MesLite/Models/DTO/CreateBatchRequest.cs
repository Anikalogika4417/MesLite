namespace MesLite.Models.DTO;

public class CreateBatchRequest
{
    public required Guid LineId { get; set; }
    public required string ProductName { get; set; }
}
