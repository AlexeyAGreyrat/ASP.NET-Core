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
	//Работа с клиентами
	[Authorize(Roles = "admin")]
	public class ClientsController : TimeSheetBaseController
	{
		private readonly IClientManager _manager;

		public ClientsController(IClientManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о клиенте по его Id</summary>
		/// <param name="id">Id клиента</param>
		/// <returns>Инорфмация о клиенте</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение списка информации клиентов</summary>
		/// <returns>Список содержащий информацию о клиентах</returns>
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового клиента</summary>
		/// <param name="request">Информация о клиенте</param>
		/// <returns>Id созданного клиента</returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ClientRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Удаление клиента по Id</summary>
		/// <param name="id">Id удаляемого клиента</param>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
