namespace Net6CqrsTemplate.Application.Usecases.Zipfile.Commands;

using MediatR;
using Net6CqrsTemplate.Application.Contracts.Infrastructure.Services;
using Net6CqrsTemplate.Application.Dtos.Zip;
using Net6CqrsTemplate.Application.Mediator.Zipfile.Commands;
using System.Threading.Tasks;

public class CreateZipFileCommandUsecase : IRequestHandler<CreateZipFileCommandRequest, ZipResultDto>
{

    private readonly IZipFileService zipFileService;

    public CreateZipFileCommandUsecase(IZipFileService zipFileService)
    {
        this.zipFileService = zipFileService ?? throw new ArgumentNullException(nameof(zipFileService));
    }

    public Task<ZipResultDto> Handle(CreateZipFileCommandRequest request, CancellationToken cancellationToken)
    {

        return Task.FromResult(zipFileService.DownloadZipFile(request.CreateZipFile.FilePaths));
    }
}
