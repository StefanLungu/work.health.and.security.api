using whs.api.business;
using whs.api.repository.extensions;
using whs.api.business.validations;

namespace whs.api.manager.infrastructure.dependencyinjection;

public static class ExtensionsCoreServiceCollection
{
	public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCustomDbContext(configuration);
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IBusinessDiscovery).Assembly));
		services.AddValidators();
		return services;
	}
}
