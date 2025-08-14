using Application.UseCases.Users.Common;

namespace Application.UseCases.Users.Queries.GetAllUsers
{
    public record GetAllUsersResponse(IEnumerable<BaseUserDto> users);
}