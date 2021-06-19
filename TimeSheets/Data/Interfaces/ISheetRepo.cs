using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Interfaces
{
	public interface ISheetRepo : IRepoBase<SheetAggregate>
	{
	}
}
