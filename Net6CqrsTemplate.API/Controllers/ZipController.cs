namespace Net6CqrsTemplate.API.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Net6CqrsTemplate.Application.Dtos.Zip;
using Net6CqrsTemplate.Application.Dtos.ZipFile.Commands;
using Net6CqrsTemplate.Application.Mediator.Zipfile.Commands;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ZipResultDto))]
public class ZipController : ControllerBase
{
    private readonly IMediator mediator;

    public ZipController(IMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    // GET: api/<ZipController1>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await Task.FromResult(new ZipResultDto());

        return Ok(list);
    }


    [HttpPost]
    public async Task<IActionResult> DownLoadZip()
    {
        CreateZipFileCommandDto createZipFile = new CreateZipFileCommandDto
        {
            FilePaths = new string[]
            {
                "TextFile.txt",
                "TextFile1.txt",
                "TextFile2.txt"
            }
        };

        var result = await mediator.Send(new CreateZipFileCommandRequest
        {
            CreateZipFile = createZipFile
        });

        if (result is null || result.FileResult is null)
        {
            return BadRequest();
        }        

        return File(result.FileResult, "application/zip", result.FileName);
    }
}