namespace MesLite.Models;

public class ProductionLine
{
    public Guid LineId { get; set; }
    public required string LineName { get; set; }
    public required LineStatus Status { get; set; }

    public List<Batch> Batches { get; set; } = new();
}
