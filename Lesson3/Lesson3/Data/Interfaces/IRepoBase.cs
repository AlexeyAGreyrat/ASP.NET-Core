using System;
using System.Collections.Generic;

namespace Lesson3.Data.Interfaces
{
    public interface IRepoBase<T>
    {
        T GetItem(int id);
        IEnumerable<T> GetItems(string name);

        IEnumerable<T> GetSkip(int skip,int take);
        int LastId();
        void Add(T item);
        void Update(T data);
        void Delete(int id);
    }
}