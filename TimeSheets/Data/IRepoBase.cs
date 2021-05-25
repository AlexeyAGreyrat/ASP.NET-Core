using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Data
{
    public interface IRepoBase<T>
    {
        Task<T> GetItem(int id);
        Task<int> LastId();
        Task<IEnumerable<T>> GetItems();
        Task Add(T item);
        Task Update(T item);
    }
}