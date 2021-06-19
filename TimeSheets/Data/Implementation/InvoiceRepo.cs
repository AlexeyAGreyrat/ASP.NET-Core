using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Implementation
{
	public class InvoiceRepo : IInvoiceRepo
	{
		private readonly TimeSheetDbContext _dbCcontext;

		public InvoiceRepo(TimeSheetDbContext dbContext)
		{
			_dbCcontext = dbContext;
		}

		public async Task Add(InvoiceAggregate item)
		{
			await _dbCcontext.Invoices.AddAsync(item);
			await _dbCcontext.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbCcontext.Invoices.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<InvoiceAggregate> GetItem(Guid id)
		{
			var result = await _dbCcontext.Invoices.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<InvoiceAggregate>> GetItems()
		{
			return await _dbCcontext.Invoices.ToListAsync();
		}

		public async Task Update(InvoiceAggregate item)
		{
			_dbCcontext.Invoices.Update(item);
			await _dbCcontext.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _dbCcontext.Invoices.FindAsync(id);
			if (item != null)
			{
				item.FlagDeleted();
				_dbCcontext.Invoices.Update(item);
				await _dbCcontext.SaveChangesAsync();
			}
		}
		public async Task<IEnumerable<SheetAggregate>> GetContarctFromTo(
			Guid contractId,
			DateTime dateStart,
			DateTime dateEnd)
		{
			var sheets = await _dbCcontext.Sheets
				.Where(x => x.ContractId == contractId)
				.Where(x => x.Date <= dateEnd && x.Date >= dateStart)
				.Where(x => x.InvoiceId == null)
				.ToListAsync();

			return sheets;
		}

	}
}
