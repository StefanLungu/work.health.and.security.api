using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using whs.api.entities.management;

namespace whs.api.entities.configurations.management;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasKey(e => e.UniqueId);

		builder.Property(e => e.Username)
			.HasMaxLength(250)
			.IsRequired();

		builder.Property(e => e.Description)
			.HasMaxLength(250)
			.IsRequired();

		builder.Property(e => e.EmailAddress)
			.HasMaxLength(250);

		builder.Property(e => e.Role)
			.IsRequired();

		builder.HasOne(e => e.Department)
			.WithMany(e => e.Users)
			.IsRequired()
			.HasForeignKey("DepartmentId");

		builder.Property(e => e.Password)
			.HasMaxLength(100)
			.IsRequired();
	}
}
