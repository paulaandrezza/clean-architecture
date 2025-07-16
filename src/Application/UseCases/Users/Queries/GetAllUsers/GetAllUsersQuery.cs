using Domain.Enums;
using MediatR;

namespace Application.UseCases.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<GetAllUsersResponse>
    {
        public Role? Role { get; set; }
    }
}