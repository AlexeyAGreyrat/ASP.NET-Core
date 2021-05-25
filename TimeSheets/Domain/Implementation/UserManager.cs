using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Implementation
{
    public class UserManager: IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<int> CreateUser(UserRequest request)
        {    
            var user = new User
            {
                Id = await _userRepo.LastId() + 1,
                Username = request.Username
            };

            await _userRepo.Create(user);

            return user.Id;
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepo.GetUserById(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepo.GetUsers();
        }

        public async Task<User> UpdateUser(int id, UserRequest request)
        {
            var user = new User
            {
                Id = id,
                Username = request.Username                
            };

            await _userRepo.Update(user);
            return user;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepo.Delete(id);
        }
    }
}