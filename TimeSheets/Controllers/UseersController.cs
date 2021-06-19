using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
	//Работа с пользователями
	public class UsersController : TimeSheetBaseController
	{
		private readonly IUserManager _manager;

		public UsersController(IUserManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о пользователе по его Id</summary>
		/// <param name="id">Id пользователя</param>
		/// <returns>Инорфмация о пользователе</returns>
		[Authorize(Roles = "admin")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение списка пользователях</summary>
		/// <returns>Список пользователей</returns>
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового пользователя</summary>
		/// <param name="request">Информация о пользователе</param>
		/// <returns>Id созданного пользователя</returns>
		[Authorize(Roles = "admin")]
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] UserRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующего пользователя</summary>
		/// <param name="id">Id изменяемого пользователя</param>
		/// <param name="request">Информация об пользователе</param>
		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserUpdateRequest request)
		{
			await _manager.Update(id, request);
			return Ok();

		}

		/// <summary>Удаление пользователя</summary>
		/// <param name="id">Id удаляемого пользователя</param>
		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
