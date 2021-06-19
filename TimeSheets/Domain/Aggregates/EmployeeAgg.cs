using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class EmployeeAgg : Employee
	{
		private EmployeeAgg() { }
		//Создание работника
		public static EmployeeAgg CreateRequest(EmployeeRequest request)
		{
			return new EmployeeAgg()
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				IsDeleted = false,
			};
		}

		//Флаг удаления
		public void FlagDeleted()
		{
			IsDeleted = true;
		}
	}
}
