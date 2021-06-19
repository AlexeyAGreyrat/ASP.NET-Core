using Microsoft.EntityFrameworkCore;
using TimeSheets.Data.Configurations;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data
{
	//База данных
	public class TimeSheetDbContext : DbContext
	{
		public DbSet<ClientAgg> Clients { get; set; }
		public DbSet<ContractAgg> Contracts { get; set; }
		public DbSet<EmployeeAgg> Employees { get; set; }
		public DbSet<ServiceAggregate> Services { get; set; }
		public DbSet<InvoiceAgg> Invoices { get; set; }
		public DbSet<SheetAgg> Sheets { get; set; }
		public DbSet<UserAgg> Users { get; set; }

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