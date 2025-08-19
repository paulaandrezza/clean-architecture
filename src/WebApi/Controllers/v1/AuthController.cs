using Application.UseCases.Auth.Commands.Authenticate;
using Application.UseCases.Auth.Commands.CreateRefreshToken;
using Application.UseCases.Auth.Commands.RevokeToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : MainController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Auth
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticateUserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Auth(AuthenticateUserCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] CreateRefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("revoke")]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
                return Ok(new { message = "Token revoked successfully" });

            return BadRequest(new { message = "Invalid token" });
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout([FromBody] RevokeTokenCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Logged out successfully" });
        }
    }
}
