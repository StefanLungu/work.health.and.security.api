using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using whs.api.repository.context;
using whs.api.repository.utils;

namespace whs.api.repository.extensions;

public static class ExtensionsRepositoryServiceCollection
{
	public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSqlServer<WHSDbContext>(configuration.GetConnectionString(Constants.WHS_CONNECTION_STRING));

		return services;
	}
}
