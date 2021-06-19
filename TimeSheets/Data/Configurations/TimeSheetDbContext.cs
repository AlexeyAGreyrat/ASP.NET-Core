using Microsoft.EntityFrameworkCore;
using TimeSheets.Data.Configurations;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data
{
	//База данных
	public class TimeSheetDbContext : DbContext
	{
		public DbSet<ClientAggregate> Clients { get; set; }
		public DbSet<ContractAggregate> Contracts { get; set; }
		public DbSet<EmployeeAggregate> Employees { get; set; }
		public DbSet<ServiceAggregate> Services { get; set; }
		public DbSet<InvoiceAggregate> Invoices { get; set; }
		public DbSet<SheetAggregate> Sheets { get; set; }
		public DbSet<UserAggregate> Users { get; set; }

		public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
		{
		}

		//База данных
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClientConfiguration());
			modelBuilder.ApplyConfiguration(new ContractConfiguration());
			modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
			modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
			modelBuilder.ApplyConfiguration(new ServiceConfiguration());
			modelBuilder.ApplyConfiguration(new SheetConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
		}
	}
}