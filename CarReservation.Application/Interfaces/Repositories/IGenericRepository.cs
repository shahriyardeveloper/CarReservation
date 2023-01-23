namespace CarReservation.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> GetAllAsync();

    Task<IReadOnlyList<T>> GetPageResponseAsync(int pageNumber, int pageSize);

    Task<T> AddAsync(T entity);

    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

    void Update(T entity);

    void Delete(T entity);

    IQueryable<T> AsQueryable();
}

