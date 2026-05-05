namespace APS.Shared;

public class EnvironmentalData
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string IndustryId { get; set; } = string.Empty;
    public string IndustryName { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public double PollutionLevel { get; set; }
    public double Ph { get; set; }
    public double Temperature { get; set; }
    public double DissolvedOxygen { get; set; }
    public string Status { get; set; } = "Normal";
    public string? Notes { get; set; }
    public string? InspectorName { get; set; }
}