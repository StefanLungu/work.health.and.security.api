using FluentValidation;
using whs.api.business.handlers;
using whs.api.repository.abstractions.management;
using whs.api.business.validations.extensions;
using whs.api.entities.management;

namespace whs.api.business.validations.management;

public class ValidatorCreateDepartment : AbstractValidator<RequestCreateDepartment>
{
	private const string VALIDATED_OBJECT = nameof(RequestCreateDepartment);

    public ValidatorCreateDepartment(IDepartmentsRepository departmentsRepository)
    {
		RuleFor(r => r.UniqueId)
			.IsValidGuid()
			.WithMessage((r, _) => $"{VALIDATED_OBJECT} has undefined {nameof(RequestCreateDepartment.UniqueId)}: {r.UniqueId}");

		When(r => r.ParentId.HasValue, () =>
		{
			RuleFor(r => r.ParentId!.Value)
				.IsValidGuid()
				.WithMessage((r, _) => $"{VALIDATED_OBJECT} has undefined {nameof(RequestCreateDepartment.ParentId)}: {r.ParentId!.Value}")
				.DepartmentExists(departmentsRepository)
				.WithMessage((r, _) => $"Department with unique id {r.ParentId!.Value} does not exist");
		});

		RuleFor(r => r.Name)
			.NotEmpty()
			.WithMessage($"{VALIDATED_OBJECT} has empty {nameof(RequestCreateDepartment.Name)}")
			.MaximumLength(250)
			.WithMessage($"{nameof(RequestUpdateDepartment.Name)} must not exceed 250 characters");

		RuleFor(r => r)
			.DepartmentNotExistsByName(departmentsRepository)
			.WithMessage(r => {
				if (r.ParentId.HasValue)
				{
					return $"Department '{r.Name}' already exists for department with uniqueId '{r.ParentId.Value}'.";
				}
				else
				{
					return $"Department '{r.Name}' already exists";
				}
			});
	}
}
