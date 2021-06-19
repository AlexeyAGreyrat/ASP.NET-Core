using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class InvoiceAgg : Invoice
	{
		//Стоимость одного часа работы
		private readonly decimal _rate = 150;

		private InvoiceAgg() { }

		//Создание счета
		public static InvoiceAgg CreateRequest(InvoiceRequest request)
		{
			return new InvoiceAgg()
			{
				Id = Guid.NewGuid(),
				ContractId = request.ContractId,
				DateFrom = request.DateFrom,
				DateTo = request.DateTo,
				IsDeleted = false,
			};
		}

		//Добавление учета времени к счету
		public void IncludeSheets(IEnumerable<SheetAgg> sheets)
		{
			Sheets.AddRange(sheets);
			CalculateSum();
		}

		//Рассчет суммы
		private void CalculateSum()
		{
			var amount = Sheets.Sum(x => x.Amount.Amount * _rate);
			Sum = Money.FromDecimal(amount);
		}

		//Флаг удаления
		public void FlagDeleted()
		{
			IsDeleted = true;
		}
	}

}
