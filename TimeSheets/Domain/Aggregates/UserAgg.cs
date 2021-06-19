using System;
using System.Security.Cryptography;
using System.Text;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class UserAgg : User
	{
		private UserAgg() { }

		//Создание пользователя
		public static UserAgg CreateRequest(UserRequest request)
		{
			var pass = new SHA1CryptoServiceProvider();
			return new UserAgg()
			{
				Id = Guid.NewGuid(),
				Username = request.Username,
				PasswordHash = pass.ComputeHash(Encoding.Unicode.GetBytes(request.Password)),
				Role = request.Role,
				RefreshToken = String.Empty,
				IsDeleted = false,
			};
		}

		//Обновление пользователя
		public void UpdateRequest(UserUpdateRequest request)
		{
			var pass = new SHA1CryptoServiceProvider();
			Username = request.Username;
			PasswordHash = pass.ComputeHash(Encoding.Unicode.GetBytes(request.Password));
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
