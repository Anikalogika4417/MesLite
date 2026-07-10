namespace MesLite.Models;

public class ProductionLine
{
    public Guid LineId { get; set; } = Guid.NewGuid();
    public required string LineName { get; set; }
    public required LineStatus Status { get; set; } = LineStatus.Active;

    public List<Batch> Batches { get; set; } = new();
}
