using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Interfaces
{
	public interface IUserRepo : IRepoBase<UserAggregate>
	{
		Task<UserAggregate> GetUsersA(string login, byte[] passwordHash);
	}
}
