using Application.Common.Repositories;
using Application.UseCases.Users.Common;
using Domain.Aggregates.UserAggregate;
using MediatR;

namespace Application.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _repository.ListAsync(null, cancellationToken);
            IEnumerable<BaseUserDto> userDtos = users.Select(user => new UserDto(user));

            return new GetAllUsersResponse(userDtos);
        }
    }
}
