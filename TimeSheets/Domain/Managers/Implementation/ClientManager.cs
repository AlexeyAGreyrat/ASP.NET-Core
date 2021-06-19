using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class ClientManager : IClientManager
	{
		private readonly IClientRepo _repository;

		public ClientManager(IClientRepo repository)
		{
			_repository = repository;
		}

		public async Task<ClientAggregate> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<IEnumerable<ClientAggregate>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(ClientRequest request)
		{
			var client = ClientAggregate.CreateFromRequest(request);
			await _repository.Add(client);
			return client.Id;
		}

		public async Task<bool> CheckClientIsDeleted(Guid id)
		{
			return await _repository.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repository.Delete(id);
		}
	}
}
