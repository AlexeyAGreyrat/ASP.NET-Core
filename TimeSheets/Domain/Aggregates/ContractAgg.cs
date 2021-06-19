using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ContractAgg : Contract
	{
		private ContractAgg() { }

		//Создание контракта
		public static ContractAgg CreateRequest(ContractRequest request)
		{
			return new ContractAgg()
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
		public void UpdateRequest(ContractUpdateRequest request)
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
