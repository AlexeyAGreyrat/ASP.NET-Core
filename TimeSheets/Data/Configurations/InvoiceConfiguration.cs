using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Data.Configurations
{
	public class InvoiceConfiguration : IEntityTypeConfiguration<InvoiceAgg>
	{
		public void Configure(EntityTypeBuilder<InvoiceAgg> builder)
		{
			builder.ToTable("invoices");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(invoice => invoice.Contract)
				.WithMany(contract => contract.Invoices)
				.HasForeignKey("ContractId");

			//Value
			var converter = new ValueConverter<Money, decimal>(
				v => v.Amount,
				v => Money.FromDecimal(v));

			builder.Property(x => x.Sum)
				.HasConversion(converter);
		}
	}
}