using System;

namespace TimeSheets.Models.Dto.Requests
{
	//Запрос на создание контракта
	public class ContractRequest
	{
		public string NameContract { get; set; }

		public DateTime DateFrom { get; set; }

		public DateTime DateTo { get; set; }
		public string Annotations { get; set; }
	}
}
