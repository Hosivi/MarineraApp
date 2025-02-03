using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Repositories;

public static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> inputQuery, Specification<TEntity> specification) where TEntity : class
    {
        IQueryable<TEntity> query = inputQuery;
        if (specification.Criteria != null)
        {
            query = query.Where(specification.Criteria);
        }
        specification.Includes.Aggregate(query, (current, include) => current.Include(include));
        return query;
    }
}