using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace whs.api.business.validations;

public static class ExtensionsValidationServiceCollection
{
	public static IServiceCollection AddValidators(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		return services;
	}
}
