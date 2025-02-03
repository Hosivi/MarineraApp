namespace SharedKernel;

public interface IRepositoryAsync<T> where T : class
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, Specification<T> specifications, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, Specification<T> specifications, CancellationToken cancellationToken = default);
    Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void Attach(T entity);
}
public interface IReadRepositoryAsync<T>
{
    Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default);
    Task<T?> GetBySpecificationAsync(Specification<T> specification, CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefaultAsync(Specification<T> specification, CancellationToken cancellationToken = default);
    Task<TResult?> FirstOrDefaultAsync<TResult>(Specification<T> specification, CancellationToken cancellationToken = default);
    Task<List<T>> ListAsync(CancellationToken cancellationToken = default);
    Task<List<T>> ListPaginatorAsync(Specification<T> filter, int items, int page=1,CancellationToken cancellationToken = default);
    Task<List<T>> ListAsync(Specification<T>? specification, CancellationToken cancellationToken = default);
    Task<int> CountAsync(Specification<T> filter, CancellationToken cancellationToken = default);
    Task<int> CountAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Specification<T> specification, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(CancellationToken cancellationToken = default);
}