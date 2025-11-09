using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Clipr.API.Controllers;

public class UserController : BaseApiController
{
    [HttpGet]
    public IActionResult GetUser()
    {
        return Ok("User endpoint is working.");
    }
}
