using FluentValidation;
using whs.api.business.handlers;
using whs.api.business.validations.extensions;
using whs.api.repository.abstractions.management;

namespace whs.api.business.validations.management;

public class ValidatorUpdateDepartment : AbstractValidator<RequestUpdateDepartment>
{
	private readonly string VALIDATED_OBJECT = nameof(RequestUpdateDepartment);

    public ValidatorUpdateDepartment(IDepartmentsRepository departmentsRepository)
    {
		RuleFor(r => r.UniqueId)
			.IsValidGuid()
			.WithMessage((r, _) => $"{VALIDATED_OBJECT} has undefined {nameof(RequestUpdateDepartment.UniqueId)}: {r.UniqueId}")
			.DepartmentExists(departmentsRepository)
			.WithMessage((r, _) => $"Department with unique id '{r.UniqueId}' does not exists");

		When(r => r.Name.HasValue, () =>
		{
			RuleFor(r => r.Name!.Value)
				.NotEmpty()
				.WithMessage($"{VALIDATED_OBJECT} has empty {nameof(RequestUpdateDepartment.Name)}")
				.MaximumLength(250)
				.WithMessage($"{nameof(RequestUpdateDepartment.Name)} must not exceed 250 characters");
		});
	}
}
