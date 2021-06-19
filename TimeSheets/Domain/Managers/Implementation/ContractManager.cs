using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class ContractManager : IContractManager
	{
		private readonly IContractRepo _repository;

		public ContractManager(IContractRepo repository)
		{
			_repository = repository;
		}

		public async Task<ContractAggregate> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<IEnumerable<ContractAggregate>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(ContractRequest request)
		{
			var contract = ContractAggregate.CreateFromRequest(request);
			await _repository.Add(contract);
			return contract.Id;
		}

		public async Task Update(Guid id, ContractUpdateRequest request)
		{
			var item = await _repository.GetItem(id);
			if(item!=null)
			{
				item.UpdateFromRequest(request);
			}

		}

		public async Task<bool?> CheckContractIsActive(Guid id)
		{
			return await _repository.CheckContractIsActive(id);
		}

		public async Task<bool> CheckContractIsDeleted(Guid id)
		{
			return await _repository.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repository.Delete(id);
		}
	}
}
