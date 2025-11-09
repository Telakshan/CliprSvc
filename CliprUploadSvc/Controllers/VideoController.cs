using Microsoft.AspNetCore.Mvc;

namespace Clipr.API.Controllers;

public class VideoController : BaseApiController
{
    [HttpGet("video/{videoId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetVideoById(string videoId)
    {
        if (string.IsNullOrEmpty(videoId))
        {
            return BadRequest("Video Id is required");
        }

        return Ok($"videoId: {videoId}");
    }
}
