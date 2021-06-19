using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
	//Работа с контрактами
	public class ContractsController : TimeSheetBaseController
	{
		private readonly IContractManager _manager;
		public ContractsController(IContractManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о контракте по его Id</summary>
		/// <param name="id">Id контракта</param>
		/// <returns>Инорфмация о контракте</returns>
		[Authorize(Roles = "admin")]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetItem(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение списка информации о контрактах</summary>
		/// <returns>Список содержащий информацию о контрактах</returns>
		[Authorize(Roles = "admin")]
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового контракта</summary>
		/// <param name="request">Информация о создание контракта</param>
		/// <returns>Id созданного контракта</returns>
		[HttpPost]
		[Authorize(Roles = "admin")]
		public async Task<IActionResult> Create([FromBody] ContractRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующего контракта</summary>
		/// <param name="id">Id изменяемого контракта</param>
		/// <param name="request">Информация на изменение контракта</param>
		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ContractUpdateRequest request)
		{
			await _manager.Update(id, request);
			return Ok();

		}

		/// <summary>Удаление контракта</summary>
		/// <param name="id">Id удаляемого конракта</param>
		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
