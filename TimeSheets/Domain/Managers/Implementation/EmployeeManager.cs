using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class EmployeeManager : IEmployeeManager
	{
		private readonly IEmployeeRepo _repository;

		public EmployeeManager(IEmployeeRepo repository)
		{
			_repository = repository;
		}

		public async Task<EmployeeAggregate> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<IEnumerable<EmployeeAggregate>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(EmployeeRequest request)
		{
			var employee = EmployeeAggregate.CreateFromRequest(request);

			await _repository.Add(employee);

			return employee.Id;
		}

		public async Task<bool> CheckEmployeeIsDeleted(Guid id)
		{
			return await _repository.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repository.Delete(id);
		}
	}
}
