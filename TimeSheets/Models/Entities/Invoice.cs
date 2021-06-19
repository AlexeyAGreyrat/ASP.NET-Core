using System;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Models.Entities
{
	public class Invoice
	{
		public Guid Id { get; protected set; }
		public Guid ContractId { get; protected set; }
		public DateTime DateFrom { get; protected set; }
		public DateTime DateTo { get; protected set; }
		public Money Sum { get; protected set; }
		public bool IsDeleted { get; protected set; }


		//Свойства
		public ContractAggregate Contract { get; set; }
		public List<SheetAggregate> Sheets { get; set; } = new List<SheetAggregate>();
	}
}