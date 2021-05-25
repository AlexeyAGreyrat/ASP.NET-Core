using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(int id);
        Task<IEnumerable<Employee>> GetItems();
        Task<int> Create(EmployeeRequest employee);
        Task Update(int id, EmployeeRequest employee);
        Task Delete(int id);
    }
}