using Microsoft.EntityFrameworkCore;
using whs.api.entities.management;
using whs.api.repository.abstractions.management;
using whs.api.repository.context;

namespace whs.api.repository.management;

public class DepartmentsRepository(WHSDbContext context) : Repository<Department>(context), IDepartmentsRepository
{
	public async Task<bool> ExistsByNameAndParent(string name, Guid currentDepId , Guid? parentId)
	{
		return await _context.Departments.AnyAsync(dep => dep.Parent.UniqueId == parentId && dep.UniqueId != currentDepId && dep.Name.Equals(name));
	}
}
