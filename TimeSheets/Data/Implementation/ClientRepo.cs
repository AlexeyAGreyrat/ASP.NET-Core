using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Implementation
{
	public class ClientRepo : IClientRepo
	{
		private readonly TimeSheetDbContext _dbContext;

		public ClientRepo(TimeSheetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(ClientAggregate item)
		{
			await _dbContext.Clients.AddAsync(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbContext.Clients.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<ClientAggregate> GetItem(Guid id)
		{
			var result = await _dbContext.Clients.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<ClientAggregate>> GetItems()
		{
			return await _dbContext.Clients.ToListAsync();
		}

		public async Task Update(ClientAggregate item)
		{
			_dbContext.Clients.Update(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _dbContext.Clients.FindAsync(id);
			if (item != null)
			{
				item.FlagDeleted();
				_dbContext.Clients.Update(item);
				await _dbContext.SaveChangesAsync();
			}
		}

	}
}
