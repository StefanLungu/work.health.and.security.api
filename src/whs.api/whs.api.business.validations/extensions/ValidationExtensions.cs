using FluentValidation;
using whs.api.business.validations.common;

namespace whs.api.business.validations.extensions;

public static class ValidatonExtensions
{
	public static IRuleBuilderOptions<T, Guid> IsValidGuid<T>(this IRuleBuilder<T, Guid> ruleBuilder)
	{
		return ruleBuilder.SetValidator(new GuidValidator<T>());
	}

	public static IRuleBuilderOptions<T, TProperty> MustNotAsync<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, Func<TProperty, CancellationToken, Task<bool>> predicate)
	{
		return ruleBuilder.MustAsync(async (T _, TProperty val, ValidationContext<T> _, CancellationToken cancel) => !await predicate(val, cancel));
	}
}
