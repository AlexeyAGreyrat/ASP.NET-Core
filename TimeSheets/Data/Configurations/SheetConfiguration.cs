using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Data.Configurations
{
	public class SheetConfiguration : IEntityTypeConfiguration<SheetAggregate>
	{
		public void Configure(EntityTypeBuilder<SheetAggregate> builder)
		{
			builder.ToTable("sheets");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(sheet => sheet.Invoice)
				.WithMany(invoice => invoice.Sheets)
				.HasForeignKey("InvoiceId");

			builder
				.HasOne(sheet => sheet.Contract)
				.WithMany(contract => contract.Sheets)
				.HasForeignKey("ContractId");

			builder
				.HasOne(sheet => sheet.Service)
				.WithMany(service => service.Sheets)
				.HasForeignKey("ServiceId");

			builder
				.HasOne(sheet => sheet.Employee)
				.WithMany(employee => employee.Sheets)
				.HasForeignKey("EmployeeId");

			//Value
			var converter = new ValueConverter<SpentTime, int>(
				y => y.Amount,
				y => SpentTime.FromInt(y));

			builder.Property(z => z.Amount)
				.HasConversion(converter);

		}
	}
}