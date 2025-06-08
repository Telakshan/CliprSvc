using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Ensure this is present for IFormFile
using Clipr.Application.Features.Commands.UploadVideo; // For UploadVideoCommand
using System;
using System.Threading.Tasks;

namespace CliprUploadSvc.Controllers;

[ApiController]
[Route("api/[controller]")] // Consider adding 'api/' prefix if standard for your project
public class UploadController : ControllerBase
{
    private readonly IMediator _mediator;

    public UploadController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost("video")] // Changed route to be more specific, e.g., api/upload/video
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UploadVideo(IFormFile file) // Parameter name 'file' is conventional
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file selected or file is empty.");
        }

        // Basic validation for video MIME types can be done here if desired,
        // or handled by the application layer/service.
        // For example:
        // if (!file.ContentType.StartsWith("video/"))
        // {
        //     return BadRequest("Invalid file type. Only video files are allowed.");
        // }

        var command = new UploadVideoCommand { VideoFile = file };
        var result = await _mediator.Send(command);

        // Assuming the command handler returns the URL string directly.
        // If it returns a more complex object, adjust accordingly.
        return Ok(new { videoUrl = result });
    }
}
