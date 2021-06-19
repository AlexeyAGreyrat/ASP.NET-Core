using System;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Tests.Build
{
	public class Builder
	{
		//Cоздание учетной записи для теста
		public static SheetRequest CreateTestSheetCreate()
		{
			var request = new SheetRequest()
			{
				Hour = 4,
				ContractId = Guid.NewGuid(),
				Date = DateTime.Now,
				EmployeeId = Guid.NewGuid(),
				ServiceId = Guid.NewGuid(),
			};
			return request;
		}
		//Создание услуги для теста
		public static ServiceRequest CreateTestService()
		{
			var request = new ServiceRequest()
			{
				Service = "Service",
			};
			return request;

		}
		//Создание счета для теста
		public static InvoiceRequest CreateTestInvoiceCreate()
		{
			var request = new InvoiceRequest()
			{
				ContractId = Guid.NewGuid(),
				DateFrom = DateTime.MinValue,
				DateTo = DateTime.Now,
			};
			return request;
		}	

		//Создание работника для теста
		public static EmployeeRequest CreateTestEmployeeCreate()
		{
			var request = new EmployeeRequest()
			{
				UserId = Guid.NewGuid(),
			};
			return request;

		}		

		//Cоздание пользователя для теста
		public static UserRequest CreateTestUserCreate()
		{
			var request = new UserRequest()
			{
				Username = "Username",
				Password = "123456",
				Role = "Role",
			};
			return request;

		}

		//Обновление пользователя для теста
		public static UserUpdateRequest CreateTestUserUpdate()
		{
			var request = new UserUpdateRequest()
			{
				Username = "Username",
				Password = "123456",
				Role = "Role",
			};
			return request;

		}

		//Создание клиента для теста
		public static ClientRequest CreateTestClientCreate()
		{
			var request = new ClientRequest()
			{
				UserId = Guid.NewGuid(),
			};
			return request;

		}
		//Создание контракта для теста
		public static ContractRequest CreateTestContractCreate()
		{
			var request = new ContractRequest()
			{
				NameContract = "Contract 1234",
				DateFrom = DateTime.MinValue,
				DateTo = DateTime.Now,
				Annotations = "Annotations",
			};
			return request;

		}

		//Обновление контракта для теста
		public static ContractUpdateRequest CreateTestContractUpdate()
		{
			var request = new ContractUpdateRequest()
			{
				NameContract = "Contract 1234",
				Annotations = "Annotations",
			};
			return request;

		}
		public static bool PasswordTrue(byte[] password1, byte[] password2)
		{
			bool Chek = true;

			if (password1.Length == password2.Length)
			{
				for (int i = 0; i < password1.Length; i++)
				{
					if (password1[i] != password2[i])
					{
						Chek = false;
						i = password1.Length;
					}
					
				}
			}	
			return Chek;
		}
	}
}
