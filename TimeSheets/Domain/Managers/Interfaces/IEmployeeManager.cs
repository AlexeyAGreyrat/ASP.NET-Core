using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IEmployeeManager : IBaseManager<EmployeeAggregate, EmployeeRequest>
	{
	}
}
