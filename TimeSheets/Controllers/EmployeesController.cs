using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
	//Работа со служащими
	[Authorize(Roles = "admin")]
	public class EmployeesController : TimeSheetBaseController
	{
		private readonly IEmployeeManager _manager;

		public EmployeesController(IEmployeeManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о сотруднике по его Id</summary>
		/// <param name="id">Id сотрудника</param>
		/// <returns>Инорфмация о сотруднике</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetItem(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение списка сотрудников</summary>
		/// <returns>Список сотрудников</returns>
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового сотрудника</summary>
		/// <param name="request">Информация о сотруднике</param>
		/// <returns>Id созданного сотрудника</returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] EmployeeRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Удаление сотрудника</summary>
		/// <param name="id">Id удаляемого сотрудника</param>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
