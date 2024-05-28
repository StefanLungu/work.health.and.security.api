using FluentValidation.Results;

namespace whs.api.business.common;

public static class ValidatorHelper
{
	public static IEnumerable<string> GetErrors(this IEnumerable<ValidationFailure> failures)
	{
		foreach (ValidationFailure failure in failures)
		{
			yield return $"{failure.ErrorMessage}";
		}
	}
}
