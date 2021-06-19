using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Configurations
{
	public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeAgg>
	{
		public void Configure(EntityTypeBuilder<EmployeeAgg> builder)
		{
			builder.ToTable("employees");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(x => x.User)
				.WithOne(u => u.Employee)
				.HasForeignKey<EmployeeAgg>("UserId");
		}
	}
}