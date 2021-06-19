using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<UserAgg>
	{
		public void Configure(EntityTypeBuilder<UserAgg> builder)
		{
			builder.ToTable("users");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

		}
	}
}