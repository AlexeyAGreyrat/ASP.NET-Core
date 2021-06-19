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

		public async Task<EmployeeAgg> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<IEnumerable<EmployeeAgg>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(EmployeeRequest request)
		{
			var employee = EmployeeAgg.CreateRequest(request);

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
