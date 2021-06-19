using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IContractManager : IBaseManager<ContractAgg, ContractRequest>
	{
		//обновление контракта
		Task Update(Guid id, ContractUpdateRequest request);

		//Флаг контракта
		public Task<bool?> CheckContractIsActive(Guid id);
	}
}
