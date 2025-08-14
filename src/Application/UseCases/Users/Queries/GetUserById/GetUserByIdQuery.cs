using MediatR;

namespace Application.UseCases.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }
    }
}