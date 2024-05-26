using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using whs.api.entities.management;

namespace whs.api.entities.configurations.management;

public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
{
	public void Configure(EntityTypeBuilder<Department> builder)
	{
		builder.HasKey(e => e.UniqueId);

		builder.Property(e => e.Name)
			.HasMaxLength(250)
			.IsRequired();

		builder.Property(e => e.IsActive)
			.IsRequired();

		builder.Property(e => e.IncrementalPath);

		builder.HasOne(e => e.Parent)
			.WithMany(e => e.Departments)
			.HasForeignKey("ParentId");
	}
}
