using System;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class SheetAggregate : Sheet
	{
		private SheetAggregate() { }

		//Создание учета времени
		public static SheetAggregate CreateFromRequest(SheetRequest request)
		{
			return new SheetAggregate()
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
