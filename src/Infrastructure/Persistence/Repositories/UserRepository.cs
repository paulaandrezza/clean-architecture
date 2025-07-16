using Application.Common.Repositories;
using Domain.Aggregates.UserAggregate;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await FindOrDefaultAsync(u => u.Email == email, cancellationToken);
    }
}
