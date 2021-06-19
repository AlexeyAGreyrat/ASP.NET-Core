namespace TimeSheets.Models.Dto.Requests
{
	//Запрос на обновление пользователя системы
	public class UserUpdateRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
	}
}
