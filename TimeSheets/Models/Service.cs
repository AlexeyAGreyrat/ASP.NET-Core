using System;
using System.Collections.Generic;

namespace TimeSheets.Models
{
    /// <summary> Информация о предоставляемой услуге в рамках контракта </summary>
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Sheet> Sheets { get; set; }
    }
}