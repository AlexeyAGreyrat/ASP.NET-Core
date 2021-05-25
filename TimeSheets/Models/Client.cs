using System;

namespace TimeSheets.Models
{
    /// <summary> Информация о владельце контракта </summary>
    public class Client
    {
        public int Id { get; set; }
        public int User { get; set; }
        public bool IsDeleted { get; set; }
    }
}