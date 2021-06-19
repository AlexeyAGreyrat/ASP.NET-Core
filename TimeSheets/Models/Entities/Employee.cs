using System;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	public class Employee
	{
		public Guid Id { get; protected set; }	
		public Guid UserId { get; protected set; }
		public bool IsDeleted { get; protected set; }



		//Свойства
		public UserAggregate User { get; set; }
		public ICollection<SheetAggregate> Sheets { get; set; }

	}
}
