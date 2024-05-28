using whs.api.business.common;

namespace whs.api.manager.viewmodels.management.department;

public class ViewModelUpdateDepartment
{
	public required Guid UniqueId { get; init; }
	public required UpdateableValue<string> Name { get; init; }
}
