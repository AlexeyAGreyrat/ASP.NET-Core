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
		public UserAgg User { get; set; }
		public ICollection<SheetAgg> Sheets { get; set; }

	}
}
