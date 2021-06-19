using System;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class SheetAgg : Sheet
	{
		private SheetAgg() { }

		//Создание учета времени
		public static SheetAgg CreateRequest(SheetRequest request)
		{
			return new SheetAgg()
			{
				Id = Guid.NewGuid(),
				Amount = SpentTime.FromInt(request.Hour),
				ContractId = request.ContractId,
				Date = request.Date,
				EmployeeId = request.EmployeeId,
				ServiceId = request.ServiceId,
				IsDeleted = false,
			};
		}

		//Флаг Подтверждения
		public void ApproveSheet()
		{
			IsApproved = true;
			ApprovedDate = DateTime.Now;
		}

		//Флаг удаления
		public void FlagDeleted()
		{
			IsDeleted = true;
		}
	}
}
