namespace Net6CqrsTemplate.Application.Features.ZipFile.Handlers.Commands;

using MediatR;
using Net6CqrsTemplate.Application.Contracts.Infrastructure.Services;
using Net6CqrsTemplate.Application.Dtos.Zip;
using Net6CqrsTemplate.Application.Features.ZipFile.Requests.Commands;
using System.Threading.Tasks;

public class CreateZipFileCommandHandler : IRequestHandler<CreateZipFileCommandRequest, ZipResultDto>
{

    private readonly IZipFileService zipFileService;

    public CreateZipFileCommandHandler(IZipFileService zipFileService)
    {
        this.zipFileService = zipFileService ?? throw new ArgumentNullException(nameof(zipFileService));
    }

    public Task<ZipResultDto> Handle(CreateZipFileCommandRequest request, CancellationToken cancellationToken)
    {

        return Task.FromResult(zipFileService.DownloadZipFile(request.CreateZipFile.FilePaths));
    }
}
