using System;

namespace TimeSheets.Models
{
    /// <summary> Информация о затраченном времени сотрудника </summary>
    public class Sheet
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int ContractId { get; set; }
        public int ServiceId { get; set; }
        public int InvoiceId { get; set; }
        public int Amount { get; set; }
        
        public Employee Employee { get; set; }
        public Contract Contract { get; set; }
        public Service Service { get; set; }
        public Invoice Invoice { get; set; }
    }
}