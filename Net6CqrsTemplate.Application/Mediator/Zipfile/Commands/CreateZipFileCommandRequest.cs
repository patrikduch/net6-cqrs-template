namespace Net6CqrsTemplate.Application.Mediator.Zipfile.Commands;

using MediatR;
using Net6CqrsTemplate.Application.Dtos.Zip;
using Net6CqrsTemplate.Application.Dtos.ZipFile.Commands;


public class CreateZipFileCommandRequest : IRequest<ZipResultDto>
{
    public CreateZipFileCommandDto? CreateZipFile { get; set; }
}
