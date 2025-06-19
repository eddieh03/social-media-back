using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social.Media.Application.Authentication.Queries.Login;

namespace Social.Media.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator; // Use ISender (or IMediator)

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")] // More RESTful route
    public async Task<IActionResult> Login([FromBody] LoginQuery query) 
    {
        var token = await _mediator.Send(query);

        if (token == null)
        {
            return Unauthorized("Invalid email or password.");
        }

        return Ok(new { Token = token }); 
    }

    [HttpPost("signout")]
    [Authorize]
    public IActionResult SignOutUser()
    {
        // The SignOutAsync is for cookie-based auth. For JWTs, the client
        // just needs to delete the token. This endpoint is often not needed,
        // but can be used for server-side token revocation if you implement it.
        // For now, a simple Ok is fine.
        return Ok("Signed out successfully. Please discard the token on the client-side.");
    }
}
