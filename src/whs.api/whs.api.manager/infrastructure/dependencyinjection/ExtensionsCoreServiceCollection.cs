using whs.api.repository.extensions;

namespace whs.api.manager.infrastructure.dependencyinjection;

public static class ExtensionsCoreServiceCollection
{
	public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCustomDbContext(configuration);

		return services;
	}
}
