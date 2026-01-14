namespace TheaterBackend.Application.Services;

using TheaterBackend.Application.Interfaces;
using TheaterBackend.Domain.Interfaces;
public abstract class GenericService<T> : IGenericService<T>
    where T : class
{
    protected readonly IGenericRepo<T> Repo;

    protected GenericService(IGenericRepo<T> repo)
    {
        Repo = repo;
    }

    public virtual Task<IEnumerable<T>> GetAllAsync()
        => Repo.GetAllAsync();

    public virtual Task<T> GetByIdAsync(int id)
        => Repo.GetByIdAsync(id);

    public virtual Task CreateAsync(T entity)
        => Repo.AddAsync(entity);

    public virtual Task UpdateAsync(T entity)
        => Repo.UpdateAsync(entity);

    public virtual Task DeleteAsync(int id)
        => Repo.DeleteAsync(id);
}
