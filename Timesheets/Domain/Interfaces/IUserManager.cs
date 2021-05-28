using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IUserManager
    {
        /// <summary> Возвращает пользователя по логину и паролю </summary>
        Task<User> GetUserPass(LoginRequest request);

        Task<User> GetUser(Guid id);
        Task<IEnumerable<User>> GetUsers();

        /// <summary> Создает нового пользователя </summary>
        Task<Guid> CreateUser(CreateUserRequest request);

        Task<User> UpdateUser(Guid id, CreateUserRequest request);
        Task DeleteUser(Guid id);
    }
}