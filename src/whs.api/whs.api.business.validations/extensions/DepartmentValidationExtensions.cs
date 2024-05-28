using FluentValidation;
using whs.api.business.handlers;
using whs.api.repository.abstractions.management;

namespace whs.api.business.validations.extensions;

internal static class DepartmentValidationExtensions
{
	public static IRuleBuilderOptions<T, Guid> DepartmentExists<T>(this IRuleBuilder<T, Guid> ruleBuilder, IDepartmentsRepository departmentRepository)
	{
		return ruleBuilder.MustAsync((id, _) => departmentRepository.ExistsAsync(id));
	}

	public static IRuleBuilderOptions<T, RequestCreateDepartment> DepartmentNotExistsByName<T>(this IRuleBuilder<T, RequestCreateDepartment> ruleBuilder, IDepartmentsRepository departmentRepository)
	{
		return ruleBuilder.MustNotAsync((r, _) => departmentRepository.ExistsByNameAndParent(r.Name, r.UniqueId, r.ParentId));
	}
}
