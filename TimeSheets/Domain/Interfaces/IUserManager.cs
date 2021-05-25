using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    public interface IUserManager
    {  
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<int> CreateUser(UserRequest request);
        Task<User> UpdateUser(int id, UserRequest request);
        Task DeleteUser(int id);
    }
}