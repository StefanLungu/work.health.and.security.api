using Microsoft.EntityFrameworkCore;
using whs.api.entities.configurations.management;
using whs.api.entities.management;
using whs.api.repository.utils;

namespace whs.api.repository.context;

public class WHSDbContext : DbContext
{
	public DbSet<Department> Departments { get; set; }
	public DbSet<User> Users { get; set; }

    public WHSDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema(Constants.WHS_DEFAULT_DB_SCHEMA_NAME);

		#region [ Management Configurations ]
		modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
		#endregion
	}
}
