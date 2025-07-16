using Domain.Aggregates.UserAggregate;
using System.Linq.Expressions;

namespace Application.Common.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<List<User>> ListAsync(Expression<Func<User, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<int> AddAsync(User entity, CancellationToken cancellationToken);
    }
}
