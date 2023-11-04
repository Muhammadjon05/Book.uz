using System.Linq.Expressions;

namespace Book.uz.Repositories.Generic;


public interface IGenericRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity> InsertAsync(TEntity entity);
    ValueTask InsertRangeAsync(List<TEntity> entities);
    ValueTask<bool> HasAnyAsync(Expression<Func<TEntity, bool>> expression);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>>? expression = null);
    ValueTask<TEntity?> SelectSingleAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<TEntity?> SelectFirstAsync(Expression<Func<TEntity, bool>> expression);
    ValueTask<TEntity> UpdateAsync(TEntity entity);
    ValueTask DeleteAsync(TEntity entity);
}