using FluentValidation.Validators;
using FluentValidation;

namespace whs.api.business.validations.common;

public class GuidValidator<T> : PropertyValidator<T, Guid>
{
	public override string Name => nameof(GuidValidator<T>);

	public override bool IsValid(ValidationContext<T> context, Guid value)
	{
		return value != Guid.Empty;
	}
}
