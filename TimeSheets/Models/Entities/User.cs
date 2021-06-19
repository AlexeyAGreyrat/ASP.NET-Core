using System;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	//Информация о пользователе
	public class User
	{
		public Guid Id { get; protected set; }	
		public string Username { get; protected set; }
		public bool IsDeleted { get; protected set; }
		public byte[] PasswordHash { get; protected set; }
		public string Role { get; protected set; }
		public string RefreshToken { get; protected set; }



		//Cвойства
		public ClientAggregate Client { get; set; }
		public EmployeeAggregate Employee { get; set; }

	}
}
