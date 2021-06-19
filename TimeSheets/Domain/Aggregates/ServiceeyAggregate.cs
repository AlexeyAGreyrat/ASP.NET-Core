using System;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ServiceAggregate : Service
	{
		private ServiceAggregate() { }

		//Создание сервиса
		public static ServiceAggregate CreateFromRequest(ServiceRequest request)
		{
			return new ServiceAggregate()
			{
				Id = Guid.NewGuid(),
				Name = request.Service,
				IsDeleted = false,			
			};
		}

		//Обновление сервиса
		public void UpdateFromRequest(ServiceRequest request)
		{
			Name = request.Service;
		}

		//Флаг удаления
		public void FlagDeleted()
		{
			IsDeleted = true;
		}
	}
}
