using Application.UseCases.Users.Commands.CreateUser;
using Application.UseCases.Users.Queries.GetAllUsers;
using Application.UseCases.Users.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : MainController
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator) : base()
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Create an user
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateUserResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var created = await _mediator.Send(command, cancellationToken);
            return Ok(created);
        }

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllUsersResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }


        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        [Authorize]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] int userId, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = userId }, cancellationToken);
            return Ok(user);
        }
    }
}
