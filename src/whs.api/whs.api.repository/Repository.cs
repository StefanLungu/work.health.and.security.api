using Microsoft.EntityFrameworkCore;
using whs.api.entities;
using whs.api.repository.abstractions;
using whs.api.repository.context;

namespace whs.api.repository;

internal class Repository<T>(WHSDbContext context) : IRepository<T> where T : BaseEntity, new()
{
	protected readonly WHSDbContext _context = context;

	public async Task CreateAsync(T entity)
	{
		_context.Set<T>().Add(entity);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(T entity)
	{
		_context.Set<T>().Remove(entity);
		await _context.SaveChangesAsync();
	}

	public async Task<bool> ExistsAsync(Guid id)
	{
		return await _context.Set<T>().AnyAsync(entity => entity.UniqueId == id);
	}

	public IQueryable GetAll()
	{
		return _context.Set<T>().AsQueryable();
	}

	public async Task<T?> GetByIdAsync(Guid id)
	{
		return await _context.Set<T>().FindAsync(id);
	}

	public async Task UpdateAsync(T entity)
	{
		_context.Set<T>().Update(entity);
		await _context.SaveChangesAsync();
	}
}
