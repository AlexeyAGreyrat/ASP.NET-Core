using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Implementation
{
	public class ServiceRepo : IServiceRepo
	{
		private readonly TimeSheetDbContext _dbContext;

		public ServiceRepo(TimeSheetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(ServiceAggregate item)
		{
			await _dbContext.Services.AddAsync(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbContext.Services.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<ServiceAggregate> GetItem(Guid id)
		{
			var result = await _dbContext.Services.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<ServiceAggregate>> GetItems()
		{
			return await _dbContext.Services.ToListAsync();
		}

		public async Task Update(ServiceAggregate item)
		{
			_dbContext.Services.Update(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _dbContext.Services.FindAsync(id);
			if (item != null)
			{
				item.FlagDeleted();
				_dbContext.Services.Update(item);
				await _dbContext.SaveChangesAsync();
			}
		}

	}
}
