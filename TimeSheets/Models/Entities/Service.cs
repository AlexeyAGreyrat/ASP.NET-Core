using System;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	public class Service
	{
		public Guid Id { get; protected set; }
		public string Name { get; protected set; }
		public bool IsDeleted { get; protected set; }



		//Свойства
		public ICollection<SheetAgg> Sheets { get; set; }

	}
}
