using System;
using System.Collections.Generic;
using Lesson3.Data.Interfaces;
using Lesson3.Domain.Interfaces;
using Lesson3.Models;
using Lesson3.Models.DTO;

namespace Lesson3.Domain.Implementation
{
    public class PersoneManager: IPersonManager
    {
        private readonly IPersonRepo _personeRepo;

        public PersoneManager(IPersonRepo personeRepo)
        {
            _personeRepo = personeRepo;
        }        

        public Person GetItem(int id)
        {
            return _personeRepo.GetItem(id);
        }

        public IEnumerable<Person> GetItems(string name)
        {
            return _personeRepo.GetItems(name);
        }

        public IEnumerable<Person> GetSkip(int skip,int take)
        {
            return _personeRepo.GetSkip(skip, take);
        }

        public int Create(PersonCreate personRequest)
        {
            var person = new Person()
            {
                Id = _personeRepo.LastId()+1,
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                Email = personRequest.Email,
                Company = personRequest.Company,
                Age = personRequest.Age

            };

            _personeRepo.Add(person);

            return person.Id;
        }

        public void Update(Person person)
        {
            var updata = new Person()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email,
                Company = person.Company,
                Age = person.Age

            };

            _personeRepo.Update(updata);
            
        }

        public void Delete(int id)
        {
            _personeRepo.Delete(id);
        }
    }
}