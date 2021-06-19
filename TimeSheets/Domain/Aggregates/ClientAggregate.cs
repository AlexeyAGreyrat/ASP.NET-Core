using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ClientAggregate : Client
	{
		private ClientAggregate() { }
		//Создание клиента
		public static ClientAggregate CreateFromRequest(ClientRequest request)
		{
			return new ClientAggregate()
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
