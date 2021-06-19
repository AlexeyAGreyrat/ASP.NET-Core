namespace TimeSheets.Models.Dto.Requests
{
	//>Запрос на создание пользователя системы
	public class UserRequest
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public string Role { get; set; }
	}
}
