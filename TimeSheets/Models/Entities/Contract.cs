using System;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	public class Contract
	{
		public Guid Id { get; protected set; }	
		public string NameContract { get; protected set; }
		public DateTime DateFrom { get; protected set; }	
		public DateTime DateTo { get; protected set; }	
		public string Annotations { get; protected set; }
		public bool IsDeleted { get; protected set; }



		//Свойства
		public ICollection<SheetAggregate> Sheets { get; set; }
		public ICollection<InvoiceAggregate> Invoices { get; set; }

	}
}
