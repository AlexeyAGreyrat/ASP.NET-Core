using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Implementation
{
	public class EmployeeRepo : IEmployeeRepo
	{
		private readonly TimeSheetDbContext _dbContext;

		public EmployeeRepo(TimeSheetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(EmployeeAgg item)
		{
			await _dbContext.Employees.AddAsync(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbContext.Employees.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<EmployeeAgg> GetItem(Guid id)
		{
			var result = await _dbContext.Employees.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<EmployeeAgg>> GetItems()
		{
			return await _dbContext.Employees.ToListAsync();
		}

		public async Task Update(EmployeeAgg item)
		{
			_dbContext.Employees.Update(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _dbContext.Employees.FindAsync(id);
			if (item != null)
			{
				item.FlagDeleted();
				_dbContext.Employees.Update(item);
				await _dbContext.SaveChangesAsync();
			}
		}

	}
}
