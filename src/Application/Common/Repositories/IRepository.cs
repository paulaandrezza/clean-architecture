using Domain.Common;
using System.Linq.Expressions;

namespace Application.Common.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindOrDefaultAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken, Expression<Func<TEntity, TEntity>> select = null);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<List<TEntity>> AddManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task UpdateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
