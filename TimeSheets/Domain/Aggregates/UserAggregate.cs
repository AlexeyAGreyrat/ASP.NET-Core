using System;
using System.Security.Cryptography;
using System.Text;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
    public class UserAggregate : User
	{
		private UserAggregate() { }


		//Создание пользователя
		public static UserAggregate CreateFromRequest(UserRequest request)
		{
			var sha1 = new SHA1CryptoServiceProvider();
			return new UserAggregate()
			{
				Id = Guid.NewGuid(),
				Username = request.Username,
				PasswordHash = sha1.ComputeHash(Encoding.Unicode.GetBytes(request.Password)),
				Role = request.Role,
				RefreshToken = String.Empty,
				IsDeleted = false,
			};
		}

		//Обновление пользователя
		public void UpdateFromRequest(UserUpdateRequest request)
		{
			var sha1 = new SHA1CryptoServiceProvider();
			Username = request.Username;
			PasswordHash = sha1.ComputeHash(Encoding.Unicode.GetBytes(request.Password));
			Role = request.Role;
		}
		//Флаг удаления
		public void FlagDeleted()
		{
			IsDeleted = true;
		}
		//Овление токена
		public void UpdateRefreshToken(string refreshToken)
		{
			RefreshToken = refreshToken;
		}



	}
}
