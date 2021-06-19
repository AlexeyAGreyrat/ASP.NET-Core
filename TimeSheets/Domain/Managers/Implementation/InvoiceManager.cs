using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class InvoiceManager : IInvoiceManager
	{
		private readonly IInvoiceRepo _repository;

		public InvoiceManager(IInvoiceRepo repository)
		{
			_repository = repository;
		}
		
		public async Task<InvoiceAggregate> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<IEnumerable<InvoiceAggregate>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(InvoiceRequest request)
		{
			var invoice = InvoiceAggregate.CreateFromRequest(request);
			var sheets = await _repository.GetContarctFromTo
				(
				request.ContractId,
				request.DateFrom,
				request.DateTo
				);
			invoice.IncludeSheets(sheets);
			await _repository.Add(invoice);

			return invoice.Id;
		}
		public async Task Delete(Guid id)
		{
			await _repository.Delete(id);
		}
	}
}
