using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ContractAggregate : Contract
	{
		private ContractAggregate() { }

		//Создание контракта
		public static ContractAggregate CreateFromRequest(ContractRequest request)
		{
			return new ContractAggregate()
			{
				Id = Guid.NewGuid(),
				NameContract = request.NameContract,
				DateFrom = request.DateFrom,
				DateTo = request.DateTo,
				Annotations = request.Annotations,
				IsDeleted = false,
			};
		}

		//Обновление контракта
		public void UpdateFromRequest(ContractUpdateRequest request)
		{
			NameContract = request.NameContract;
			Annotations = request.Annotations;
		}



		//Флаг удаления
		public void FlagDeleted()
		{
			IsDeleted = true;
		}
	}
}
