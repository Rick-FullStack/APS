namespace APS.Shared;

public class FileUpload
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string IndustryId { get; set; } = string.Empty;
    public string IndustryName { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FileType { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
}