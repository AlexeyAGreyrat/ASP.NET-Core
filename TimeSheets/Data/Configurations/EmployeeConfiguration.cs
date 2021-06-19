using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Configurations
{
	public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeAggregate>
	{
		public void Configure(EntityTypeBuilder<EmployeeAggregate> builder)
		{
			builder.ToTable("employees");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(x => x.User)
				.WithOne(y => y.Employee)
				.HasForeignKey<EmployeeAggregate>("UserId");
		}
	}
}