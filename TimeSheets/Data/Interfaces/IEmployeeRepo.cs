using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Interfaces
{
	public interface IEmployeeRepo : IRepoBase<EmployeeAggregate>
	{
	}
}
