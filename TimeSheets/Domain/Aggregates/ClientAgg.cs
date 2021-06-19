using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ClientAgg : Client
	{
		private ClientAgg() { }
		//Создание клиента
		public static ClientAgg CreateRequest(ClientRequest request)
		{
			return new ClientAgg()
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
