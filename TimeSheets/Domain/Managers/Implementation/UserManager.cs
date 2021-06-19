using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class UserManager : IUserManager
	{
		private readonly IUserRepo _repository;

		public UserManager(IUserRepo repository)
		{
			_repository = repository;
		}

		public async Task<UserAgg> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<UserAgg> GetItem(LoginRequest request)
		{
			var pass = new SHA1CryptoServiceProvider();			
			var passwordHash = pass.ComputeHash(Encoding.Unicode.GetBytes(request.Password));
			var user = await _repository.GetUsersA(request.Login, passwordHash);

			return user;
		}

		public async Task<IEnumerable<UserAgg>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(UserRequest request)
		{

			var user = UserAgg.CreateRequest(request);

			await _repository.Add(user);

			return user.Id;
		}

		public async Task Update(Guid id, UserUpdateRequest request)
		{
			var item = await _repository.GetItem(id);
			item.UpdateRequest(request);
		}

		public async Task<bool> CheckUserIsDeleted(Guid id)
		{
			return await _repository.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repository.Delete(id);
		}



	}
}
