namespace Net6CqrsTemplate.Application.Dtos.Zip;

public class ZipResultDto
{
    public string FileName { get; set; } = string.Empty;
    public byte[]? FileResult { get; set; }
}
