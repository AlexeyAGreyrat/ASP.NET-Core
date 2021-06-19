using System;

namespace TimeSheets.Models.Dto.Requests
{
	//Запрос для счета
	public class InvoiceRequest
	{
		public Guid ContractId { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }

	}
}
