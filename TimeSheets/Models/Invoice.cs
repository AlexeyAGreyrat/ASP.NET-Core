using System;
using System.Collections.Generic;

namespace TimeSheets.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Sum { get; set; }

        public Contract Contract { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
    }
}