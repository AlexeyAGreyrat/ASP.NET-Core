using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Add(Employee item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return
                await _context.Employees
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            return
                await _context.Employees.ToListAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}