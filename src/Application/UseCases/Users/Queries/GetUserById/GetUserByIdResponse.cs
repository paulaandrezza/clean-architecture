using Application.UseCases.Users.Common;

namespace Application.UseCases.Users.Queries.GetUserById
{
    public record GetUserByIdResponse(BaseUserDto user);
}