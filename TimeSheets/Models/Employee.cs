using System;
using System.Collections.Generic;

namespace TimeSheets.Models
{
    /// <summary> Информация о сотруднике </summary>
    public class Employee
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        
        public ICollection<Sheet> Sheets { get; set; }
    }
}