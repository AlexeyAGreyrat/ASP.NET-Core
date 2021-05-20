using Lesson3.Models;
using Lesson3.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3.Domain.Interfaces
{
    public interface IPersonManager
    {
        Person GetItem(int id);
        IEnumerable<Person> GetItems(string name);
        IEnumerable<Person> GetSkip(int skip,int take);
        int Create(PersonCreate sheet);
        void Update(Person person);
        void Delete(int id);
    }
}
