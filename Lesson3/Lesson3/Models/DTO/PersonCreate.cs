using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3.Models.DTO
{
    public class PersonCreate
    {
        /// <summary> Информация о сотруднике для доступа к чтению </summary>
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
    }
}
