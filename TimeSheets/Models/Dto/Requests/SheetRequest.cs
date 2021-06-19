using System;

namespace TimeSheets.Models.Dto.Requests
{
	//Запрос на создание учета затраченного времени
	public class SheetRequest
	{
		public DateTime Date { get; set; }		
		public Guid EmployeeId { get; set; }
		public Guid ContractId { get; set; }
		public Guid ServiceId { get; set; }
		public int Hour { get; set; }
	}
}
