namespace TimeSheets.Models.Dto.Requests
{
	//Запрос на обновление контракта
	public class ContractUpdateRequest
	{
		public string NameContract { get; set; }
		public string Annotations { get; set; }
	}
}
