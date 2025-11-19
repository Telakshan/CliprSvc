using Microsoft.AspNetCore.Mvc;
using MediatR;
using Clipr.Application.Features.Queries.GetUser;

namespace Clipr.API.Controllers;

public class UserController : BaseApiController
{
    [HttpGet("/all")]
    public async Task<IActionResult> GetUsers()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(await Mediator.Send(new GetUserListQuery()));
    }
}
