using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Interfaces
{
    public interface ISheetManager
    {
        Task<Sheet> GetItem(int id);
        Task<IEnumerable<Sheet>> GetItems();
        Task<int> Create(SheetRequest sheet);
        Task Update(int id, SheetRequest sheetRequest);
    }
}