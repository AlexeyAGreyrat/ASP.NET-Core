using System;

namespace TimeSheets.Models.Dto
{
    public class SheetRequest
    {
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int ContractId { get; set; }
        public int ServiceId { get; set; }
        public int Amount { get; set; }
    }
}