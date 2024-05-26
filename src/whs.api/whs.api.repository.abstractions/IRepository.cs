using whs.api.entities;

namespace whs.api.repository.abstractions;

public interface IRepository<T> where T : BaseEntity
{
	IQueryable GetAll();
	Task<T?> GetByIdAsync(Guid id);
	Task CreateAsync(T entity);
	Task UpdateAsync(T entity);
	Task DeleteAsync(T entity);
	Task<bool> ExistsAsync(Guid id);
}
