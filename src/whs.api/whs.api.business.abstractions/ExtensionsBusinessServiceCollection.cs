using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace whs.api.business.abstractions;

public static class ExtensionsBusinessServiceCollection
{
	public static IServiceCollection AddBusinessServices(this IServiceCollection services)
	{
		Assembly ass = Assembly.GetExecutingAssembly();
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(ass));

		return services;
	}
}
