using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Data.Configurations
{
	public class InvoiceConfiguration : IEntityTypeConfiguration<InvoiceAggregate>
	{
		public void Configure(EntityTypeBuilder<InvoiceAggregate> builder)
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
				y => y.Amount,
				y => Money.FromDecimal(y));

			builder.Property(z => z.Sum)
				.HasConversion(converter);
		}
	}
}