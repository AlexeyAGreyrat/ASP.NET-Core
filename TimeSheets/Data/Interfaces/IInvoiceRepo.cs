using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Data.Interfaces
{
	public interface IInvoiceRepo : IRepoBase<InvoiceAgg>
	{
		Task<IEnumerable<SheetAgg>> GetContarctFromTo
			(
			Guid contractId,
			DateTime dateFrom,
			DateTime dateTo
			);

	}
}
