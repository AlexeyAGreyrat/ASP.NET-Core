using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Interfaces
{
	public interface IInvoiceRepo : IRepoBase<InvoiceAggregate>
	{
		Task<IEnumerable<SheetAggregate>> GetContarctFromTo
			(
			Guid contractId,
			DateTime dateFrom,
			DateTime dateTo
			);

	}
}
