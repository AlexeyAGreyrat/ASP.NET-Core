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
	//Работа со счетами
	public class InvoicesController : TimeSheetBaseController
	{
		private readonly IInvoiceManager _invoiceManager;
		private readonly IContractManager _contractManager;

		public InvoicesController(IInvoiceManager invoiceManager, IContractManager contractManager)
		{
			_invoiceManager = invoiceManager;
			_contractManager = contractManager;
		}

		/// <summary>Получение информации о счете по его Id</summary>
		/// <param name="id">Id счета</param>
		/// <returns>Инорфмация о счете</returns>
		[Authorize(Roles = "admin, client")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _invoiceManager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение списка счетов</summary>
		/// <returns>Список счетов</returns>
		[Authorize(Roles = "admin")]
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _invoiceManager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового счета</summary>
		/// <param name="request">Информация о счете</param>
		/// <returns>Id созданного счета</returns>
		[Authorize(Roles = "admin")]
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
		{
			var isAllowedToCreate = await _contractManager.CheckContractIsActive(request.ContractId);

			if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
			{
				return BadRequest($"Contract {request.ContractId} is not active or not found.");
			}

			var id = await _invoiceManager.Create(request);
			return Ok(id);
		}

		/// <summary>Удаление счета</summary>
		/// <param name="id">Id удаляемого счета</param>
		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _invoiceManager.Delete(id);
			return Ok();
		}
	}
}
