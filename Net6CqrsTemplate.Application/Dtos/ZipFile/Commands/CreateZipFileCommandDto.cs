namespace Net6CqrsTemplate.Application.Dtos.ZipFile.Commands;

public record CreateZipFileCommandDto
{
    public string[]? FilePaths { get; set; }
}