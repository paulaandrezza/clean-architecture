using Application.Common.Repositories;
using Application.UseCases.Users.Common;
using Domain.Aggregates.UserAggregate;
using Domain.Exceptions;
using MediatR;

namespace Application.UseCases.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
                throw new NotFoundException("user", request.Id);

            BaseUserDto userDto = new UserDto(user);

            return new GetUserByIdResponse(userDto);
        }
    }
}
