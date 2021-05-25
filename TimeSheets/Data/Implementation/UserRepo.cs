using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheets.Data.EntityConfiguration;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly TimesheetDbContext _context;

        public UserRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<int> LastId()
        {
            var result = await _context.Employees.ToListAsync();
            return result.Count;
        }

        public async Task Delete(int id)
        {
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public Task<User> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetItems()
        {
            throw new NotImplementedException();
        }

        public Task Add(User item)
        {
            throw new NotImplementedException();
        }
    }
}