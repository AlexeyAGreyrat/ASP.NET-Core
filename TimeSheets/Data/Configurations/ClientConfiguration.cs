using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Configurations
{
	public class ClientConfiguration : IEntityTypeConfiguration<ClientAggregate>
	{
		public void Configure(EntityTypeBuilder<ClientAggregate> builder)
		{
			builder.ToTable("clients");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(x => x.User)
				.WithOne(y => y.Client)
				.HasForeignKey<ClientAggregate>("UserId");

		}
	}
}
