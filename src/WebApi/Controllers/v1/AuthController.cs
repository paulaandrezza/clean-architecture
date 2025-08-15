using Application.Common.Interfaces;
using Application.UseCases.Auth.Commands.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : MainController
    {
        private readonly IMediator _mediator;

        public AuthController(IApplicationUserService appUser, IMediator mediator) : base(appUser)
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
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthenticateUserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Auth(AuthenticateUserCommand command, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(command);
            if (token == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok(token);
        }

        // TODO: create refreshtoken
    }
}
