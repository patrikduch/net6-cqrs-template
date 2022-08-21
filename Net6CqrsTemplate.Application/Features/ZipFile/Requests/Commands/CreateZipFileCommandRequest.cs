namespace Net6CqrsTemplate.Application.Features.ZipFile.Requests.Commands;

using MediatR;
using Net6CqrsTemplate.Application.Dtos.Zip;
using Net6CqrsTemplate.Application.Dtos.ZipFile.Commands;


public class CreateZipFileCommandRequest : IRequest<ZipResultDto>
{
    public CreateZipFileCommandDto? CreateZipFile { get; set; }
}
