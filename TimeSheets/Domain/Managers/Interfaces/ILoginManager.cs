using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;

namespace TimeSheets.Domain.Interfaces
{
	public interface ILoginManager
	{
		Task<LoginResponse> Authenticate(UserAgg user);
		//RefreshToken
		Task<LoginResponse> Refresh(RefreshRequest request);
	}
}
