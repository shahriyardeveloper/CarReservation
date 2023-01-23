using CarReservation.Application.Interfaces.Repositories;
using CarReservation.Domain.Common;
using CarReservation.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarReservation.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicatonDbContext dbContext;

    public GenericRepository(ApplicatonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() => await dbContext.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await dbContext.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> GetPageResponseAsync(int pageNumber, int pageSize) => await dbContext
            .Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await dbContext.Set<T>().AddRangeAsync(entities);
        return entities;
    }

    public void Delete(T entity)
    {
        entity.IsDeleted = true;
        dbContext.Set<T>().Attach(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Update(T entity)
    {
        dbContext.ChangeTracker.Clear();
        dbContext.Set<T>().Update(entity);
        dbContext.Entry(entity).State = EntityState.Modified;
    }

    public IQueryable<T> AsQueryable()
    {
        return dbContext.Set<T>().AsQueryable();
    }
}
