using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class EmployeeAggregate : Employee
	{
		private EmployeeAggregate() { }
		//Создание работника
		public static EmployeeAggregate CreateFromRequest(EmployeeRequest request)
		{
			return new EmployeeAggregate()
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
