using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IServiceManager : IBaseManager<ServiceAggregate, ServiceRequest>
	{
		Task Update(Guid id, ServiceRequest request);
	}
}
