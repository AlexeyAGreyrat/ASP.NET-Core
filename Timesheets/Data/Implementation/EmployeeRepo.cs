using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Ef;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly TimesheetDbContext _context;

        public EmployeeRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var result = await _context.Employees.FindAsync(id);

            return !result.IsDeleted ? result : null;
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            var result = await _context.Employees.ToListAsync();
            return result.FindAll(x => !x.IsDeleted);
        }
        public async Task<int> LastId()
        {
            var result = await _context.Employees.ToListAsync();
            return result.Count;
        }
        public async Task Add(Employee item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var result = await _context.Employees.FindAsync(id);
            result.IsDeleted = true;

            _context.Employees.Update(result);
            await _context.SaveChangesAsync();
        }
    }
}