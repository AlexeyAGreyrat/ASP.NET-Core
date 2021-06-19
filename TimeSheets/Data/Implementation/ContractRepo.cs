using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Implementation
{
	public class ContractRepo : IContractRepo
	{
		private readonly TimeSheetDbContext _dbContext;

		public ContractRepo(TimeSheetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(ContractAggregate item)
		{
			await _dbContext.Contracts.AddAsync(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool?> CheckContractIsActive(Guid id)
		{
			var contract = await _dbContext.Contracts.FindAsync(id);
			var now = DateTime.Now;
			var isActive = (now <= contract?.DateTo && now >= contract?.DateFrom);
			return isActive;
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbContext.Contracts.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<ContractAggregate> GetItem(Guid id)
		{
			var result = await _dbContext.Contracts.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<ContractAggregate>> GetItems()
		{
			return await _dbContext.Contracts.ToListAsync();
		}

		public async Task Update(ContractAggregate item)
		{
			_dbContext.Contracts.Update(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _dbContext.Contracts.FindAsync(id);
			if (item != null)
			{
				item.FlagDeleted();
				_dbContext.Contracts.Update(item);
				await _dbContext.SaveChangesAsync();
			}
		}

	}
}
