using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto;

namespace TimeSheets.Domain.Implementation
{
    public class SheetManager: ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
        }

        public async Task<Sheet> GetItem(int id)
        {
            return await _sheetRepo.GetItem(id);
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            return await _sheetRepo.GetItems();
        }

        public async Task<int> Create(SheetRequest sheetRequest)
        {
            var sheet = new Sheet()
            {
                Id = await _sheetRepo.LastId() + 1,
                Amount = sheetRequest.Amount,
                ContractId = sheetRequest.ContractId,
                Date = sheetRequest.Date,
                EmployeeId = sheetRequest.EmployeeId,
                ServiceId = sheetRequest.ServiceId
            };
            
            await _sheetRepo.Add(sheet);
            
            return sheet.Id;
        }

        public async Task Update(int id, SheetRequest sheetRequest)
        {
            var sheet = new Sheet
            {
                Id = id,
                Amount = sheetRequest.Amount,
                ContractId = sheetRequest.ContractId,
                Date = sheetRequest.Date,
                EmployeeId = sheetRequest.EmployeeId,
                ServiceId = sheetRequest.ServiceId
            };
            
            await _sheetRepo.Update(sheet);
        }
    }
}