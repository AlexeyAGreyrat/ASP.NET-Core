using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Infrastructure.Extensions;
using TimeSheets.Models.Dto.Authentication;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace TimeSheets.Domain.Implementation
{
	public class LoginManager : ILoginManager
	{
		private readonly JwtAccessOptions _jwtAccessOptions;
		private readonly JwtRefreshOptions _jwtRefreshOptions;

		private readonly IUserRepo _userRepository;

		public LoginManager(
			IOptions<JwtAccessOptions> jwtAccessOptions,
			IOptions<JwtRefreshOptions> jwtRefreshOptions,
			IUserRepo userRepository)
		{
			_jwtAccessOptions = jwtAccessOptions.Value;
			_jwtRefreshOptions = jwtRefreshOptions.Value;
			_userRepository = userRepository;
		}
		// Генерируем токен
		public async Task<LoginResponse> Authenticate(UserAggregate user)
		{			
			var answer = CreateTokensPair(user);
			user.UpdateRefreshToken(answer.RefreshToken);
			await _userRepository.Update(user);

			return answer;
		}
		// Обновление токена
		public async Task<LoginResponse> Refresh(RefreshRequest request)
		{
			var securityHandler = new JwtSecurityTokenHandler();
			var newRefreshToken = securityHandler.ReadJwtToken(request.RefreshToken);
			var validTo = newRefreshToken.ValidTo;
			var userId = Guid.Parse(newRefreshToken.Subject);
			var user = await _userRepository.GetItem(userId);
			if(user == null || validTo < DateTime.Now || user.RefreshToken != request.RefreshToken)
			{
				throw new ArgumentException("Обновление JWT-token невозможно");
			}
			var answer = CreateTokensPair(user);
			user.UpdateRefreshToken(answer.RefreshToken);
			await _userRepository.Update(user);

			return answer;

		}

		//Создаем токены
		private LoginResponse CreateTokensPair(UserAggregate user)
		{
			var securityHandler = new JwtSecurityTokenHandler();
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
			};
			var newAccessToken = _jwtAccessOptions.GenerateToken(claims);
			var newRefreshToken = _jwtRefreshOptions.GenerateToken(claims);	
			var accessToken = securityHandler.WriteToken(newAccessToken);
			var refreshToken = securityHandler.WriteToken(newRefreshToken);

			var answer = new LoginResponse()
			{
				AccessToken = accessToken,
				ExpiresIn = newAccessToken.ValidTo.Origin(),
				RefreshToken = refreshToken,
			};

			return answer;
		}

	}
}
