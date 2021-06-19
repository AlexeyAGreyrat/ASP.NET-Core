using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Implementation
{
	public class UserRepo : IUserRepo
	{
		private readonly TimeSheetDbContext _dbContext;

		public UserRepo(TimeSheetDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task Add(UserAgg item)
		{
			await _dbContext.Users.AddAsync(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _dbContext.Users.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<UserAgg> GetItem(Guid id)
		{
			var result = await _dbContext.Users.FindAsync(id);
			return result;
		}

		public async Task<UserAgg> GetUsersA(string login, byte[] passwordHash)
		{
			return await _dbContext.Users
				.FirstOrDefaultAsync(x => x.Username == login && x.PasswordHash == passwordHash);
		}

		public async Task<IEnumerable<UserAgg>> GetItems()
		{
			return await _dbContext.Users.ToListAsync();
		}

		public async Task Update(UserAgg item)
		{
			_dbContext.Users.Update(item);
			await _dbContext.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _dbContext.Users.FindAsync(id);
			if (item != null)
			{
				item.FlagDeleted();
				_dbContext.Users.Update(item);
				await _dbContext.SaveChangesAsync();
			}
		}

	}
}
