using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Configurations
{
	public class ContractConfiguration : IEntityTypeConfiguration<ContractAggregate>
	{
		public void Configure(EntityTypeBuilder<ContractAggregate> builder)
		{
			builder.ToTable("contracts");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");
		}
	}
}