using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Interfaces
{
	public interface IUserRepo : IRepoBase<UserAgg>
	{
		Task<UserAgg> GetUsersA(string login, byte[] passwordHash);
	}
}
