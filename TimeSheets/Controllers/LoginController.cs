using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Responses;
using TimeSheets.Models.Dto.Requests;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheets.Controllers
{
	//Аутентификация
	[Route("api")]
	public class LoginController : TimeSheetBaseController
	{
		private readonly IUserManager _userManager;
		private readonly ILoginManager _loginManager;

		public LoginController(ILoginManager loginManager, IUserManager userManager)
		{
			_loginManager = loginManager;
			_userManager = userManager;
		}

		/// <summary>Аутентификация пользователя</summary>
		/// <returns>Создание токена</returns>
		[AllowAnonymous]
		[Route("Login")]
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			var user = await _userManager.GetItem(request);

			if (user == null)
			{
				return Unauthorized();
			}

			var loginResponse = await _loginManager.Authenticate(user);

			return Ok(loginResponse);
		}

		/// <summary>Ообновление токенов</summary>
		/// <returns>Новые токены</returns>
		[AllowAnonymous]
		[Route("Refresh")]
		[HttpPost]
		public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
		{
			var loginResponse = new LoginResponse();
			try
			{
				loginResponse = await _loginManager.Refresh(request);
			}
			catch(ArgumentException e)
			{
				return BadRequest(e.Message);
			}

			return Ok(loginResponse);
		}
	}
}
