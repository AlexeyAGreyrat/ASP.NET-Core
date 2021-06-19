using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Interfaces
{
	public interface IContractRepo : IRepoBase<ContractAgg>
	{
		Task<bool?> CheckContractIsActive(Guid id);
	}
}
