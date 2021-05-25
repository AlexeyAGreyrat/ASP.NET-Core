using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
    public interface IUserRepo : IRepoBase<User>
    {
        Task<User> GetUserById(int id);
        Task<IList<User>> GetUsers();
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}