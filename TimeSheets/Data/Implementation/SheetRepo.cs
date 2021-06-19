using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Implementation
{
	public class SheetRepo : ISheetRepo
	{
		private readonly TimeSheetDbContext _dbContext;

		public SheetRepo(TimeSheetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(SheetAggregate item)
		{
			await _dbContext.Sheets.AddAsync(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbContext.Sheets.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task Delete(Guid id)
		{
			var item = await _dbContext.Sheets.FindAsync(id);
			if (item != null)
			{
				item.FlagDeleted();
				_dbContext.Sheets.Update(item);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<SheetAggregate> GetItem(Guid id)
		{
			var result = await _dbContext.Sheets.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<SheetAggregate>> GetItems()
		{
			return await _dbContext.Sheets.ToListAsync();
		}

		public async Task Update(SheetAggregate item)
		{
			_dbContext.Sheets.Update(item);
			await _dbContext.SaveChangesAsync();
		}

	}
}
