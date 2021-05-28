using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash);
        Task CreateUser(User user);
        Task<User> GetUserById(Guid id);
        Task<IList<User>> GetUsers();
        Task Update(User user);
        Task Delete(Guid id);
    }
}