using Clipr.Application.Features.Commands.UploadVideo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CliprUploadSvc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IMediator _mediator;

    public UploadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("video")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UploadVideo(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded");
        }

        var command = new UploadVideoCommand
        {
            VideoFile = file
        };

        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
