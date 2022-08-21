namespace Net6CqrsTemplate.Application.Contracts.Infrastructure.Services;

using Net6CqrsTemplate.Application.Dtos.Zip;

public interface IZipFileService
{
    ZipResultDto DownloadZipFile(string[] filePaths);
}
