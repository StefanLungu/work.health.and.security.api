using whs.api.entities.management;

namespace whs.api.repository.abstractions.management;

public interface IDepartmentsRepository : IRepository<Department>
{
	Task<bool> ExistsByNameAndParent(string name, Guid currentDepId, Guid? parentId);
}
