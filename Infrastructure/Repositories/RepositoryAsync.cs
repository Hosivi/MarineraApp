using Microsoft.EntityFrameworkCore;
using SharedKernel;
using System;
using System.Linq.Expressions;
using Infrastructure.DbContext;

namespace Infrastructure.Repositories;

public class RepositoryAsync<T> : RepositoryAsyncBase<T> where T : class
{
    private readonly IDbContextFactory<ApplicationDbContext> ContextFactory;

    public RepositoryAsync(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        ContextFactory = contextFactory;
    }
    public async Task<T> AddAsync(T entity)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        var result = await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<T> AddAsync(T entity, Specification<T> specification)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        if (specification.Includes.Any())
        {
            foreach (var include in specification.Includes)
            {
                 
                var relatedEntity = include.Compile().Invoke(entity);
                if (relatedEntity != null)
                {
                    context.Entry(relatedEntity).State = EntityState.Added;
                }
            }
        }

        var result = await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task UpdateAsync(T entity)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        var entityState = context.Entry(entity).State;
        if (entityState == EntityState.Detached)
        {
            context.Set<T>().Attach(entity);
        }
        try
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            context.Entry(entity).Reload();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(T entity)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
    public async Task<T?> GetByIdAsync<TKey>(TKey id) where TKey : struct
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        return await context.Set<T>().FindAsync(id);
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        return await context.Set<T>().ToListAsync();
    }
    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        if (predicate != null)
            return await context.Set<T>().FirstOrDefaultAsync(predicate);
        return await context.Set<T>().FirstOrDefaultAsync();

    }
    public void Attach(T entity)
    {
        using var context = ContextFactory.CreateDbContext();
        context.Set<T>().Attach(entity);
    }
    public async Task<IEnumerable<T>> GetAllAsync(Specification<T> specification)
    {
        await using var context = await ContextFactory.CreateDbContextAsync();
        var query = context.Set<T>().AsQueryable();
        foreach (var include in specification.Includes)
        {
            query = query.Include(include);
        }
        return await query.ToListAsync();
    }
}