using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class ServiceManager : IServiceManager
	{
		private readonly IServiceRepo _repository;

		public ServiceManager(IServiceRepo repository)
		{
			_repository = repository;
		}

		public async Task<ServiceAggregate> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<IEnumerable<ServiceAggregate>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(ServiceRequest request)
		{
			var Service = ServiceAggregate.CreateFromRequest(request);

			await _repository.Add(Service);

			return Service.Id;
		}

		public async Task Update(Guid id, ServiceRequest request)
		{
			var item = await _repository.GetItem(id);
			if (item != null)
			{
				item.UpdateFromRequest(request);
			}
		}

		public async Task<bool> CheckServiceIsDeleted(Guid id)
		{
			return await _repository.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repository.Delete(id);
		}
	}
}
