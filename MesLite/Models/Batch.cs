namespace MesLite.Models;

public class Batch
{
    public  Guid BatchId { get; set; }
    public  Guid LineId { get; set; }
    public required string ProductName { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset? EndTime { get; set; } = null;
    public int TotalProduced { get; set; } = 0;
    public int DefectCount { get; set; } = 0;
    public required BatchStatus Status { get; set; }

    public required ProductionLine Line { get; set; }
}
