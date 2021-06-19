﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Configurations
{
	public class ClientConfiguration : IEntityTypeConfiguration<ClientAgg>
	{
		public void Configure(EntityTypeBuilder<ClientAgg> builder)
		{
			builder.ToTable("clients");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(x => x.User)
				.WithOne(u => u.Client)
				.HasForeignKey<ClientAgg>("UserId");

		}
	}
}
