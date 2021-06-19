using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Configurations
{
	public class ServiceConfiguration : IEntityTypeConfiguration<ServiceAggregate>
	{
		public void Configure(EntityTypeBuilder<ServiceAggregate> builder)
		{
			builder.ToTable("services");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");
		}
	}
}