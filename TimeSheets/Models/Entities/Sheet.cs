using System;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Models.Entities
{
	public class Sheet
	{
		public Guid Id { get; protected set; }
		public DateTime Date { get; protected set; }
		public Guid EmployeeId { get; protected set; }	
		public Guid ContractId { get; protected set; }
		public Guid ServiceId { get; protected set; }
		public Guid? InvoiceId { get; protected set; }
		public SpentTime Amount { get; protected set; }
		public bool IsDeleted { get; protected set; }
		public bool IsApproved { get; protected set; }
		public DateTime ApprovedDate { get; protected set; }


		//Свойства
		public Domain.Aggregates.EmployeeAgg Employee { get; set; }
		public ContractAgg Contract { get; set; }
		public ServiceAggregate Service { get; set; }
		public InvoiceAgg Invoice { get; set; }

	}
}
