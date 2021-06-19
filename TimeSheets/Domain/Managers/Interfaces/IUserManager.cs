using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IUserManager : IBaseManager<UserAgg, UserRequest>
	{
		Task Update(Guid id, UserUpdateRequest request);
		Task<UserAgg> GetItem(LoginRequest request);
	}
}
