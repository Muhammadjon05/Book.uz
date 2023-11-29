using System.Linq.Expressions;
using BookShop.Data.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Service.Repositories.Generic;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _dbContext;
    protected DbSet<TEntity> DbSet;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        DbSet = _dbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await this.DbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async ValueTask InsertRangeAsync(List<TEntity> entities)
    {
        await this.DbSet.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask<bool> HasAnyAsync(Expression<Func<TEntity, bool>> expression)
        => await this.DbSet.AnyAsync(expression);

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>>? expression = null)
        => expression is null ? this.DbSet : this.DbSet.Where(expression);

    public async ValueTask<TEntity?> SelectSingleAsync(Expression<Func<TEntity, bool>> expression)
        => await this.DbSet.SingleOrDefaultAsync(expression);

    public async ValueTask<TEntity?> SelectFirstAsync(Expression<Func<TEntity, bool>> expression)
        => await this.DbSet.FirstOrDefaultAsync(expression);

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = DbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entry.Entity;
    }

    public async ValueTask DeleteAsync(TEntity entity)
    {
        this.DbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}