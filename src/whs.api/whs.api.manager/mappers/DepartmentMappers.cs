using whs.api.business.handlers;
using whs.api.manager.viewmodels.management.department;

namespace whs.api.manager.mappers;

public static class DepartmentMappers
{
	public static RequestCreateDepartment MapToRequestCreateDepartment(this ViewModelCreateDepartment source)
	{
		return new RequestCreateDepartment()
		{
			UniqueId = source.UniqueId,
			Name = source.Name,
			ParentId = source.ParentId,
		};
	}

	public static RequestUpdateDepartment MapToRequestUpdateDepartment(this ViewModelUpdateDepartment source)
	{
		return new RequestUpdateDepartment()
		{
			UniqueId = source.UniqueId,
			Name = source.Name
		};
	}
}
