using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IInvoiceManager : IBaseManager<InvoiceAggregate, InvoiceRequest>
	{
	}
}
