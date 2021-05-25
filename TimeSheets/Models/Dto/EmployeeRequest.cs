using System;

namespace TimeSheets.Models.Dto
{
    public class EmployeeRequest
    {        
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}