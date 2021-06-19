using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IUserManager : IBaseManager<UserAggregate, UserRequest>
	{
		Task Update(Guid id, UserUpdateRequest request);
		Task<UserAggregate> GetItem(LoginRequest request);
	}
}
