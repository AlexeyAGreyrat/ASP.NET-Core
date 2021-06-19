using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class SheetManager : ISheetManager
	{
		private readonly ISheetRepo _repository;

		public SheetManager(ISheetRepo repository)
		{
			_repository = repository;
		}

		public async Task<SheetAgg> GetItem(Guid id)
		{
			return await _repository.GetItem(id);
		}

		public async Task<IEnumerable<SheetAgg>> GetItems()
		{
			return await _repository.GetItems();
		}

		public async Task<Guid> Create(SheetRequest request)
		{
			var sheet = SheetAgg.CreateRequest(request);

			await _repository.Add(sheet);

			return sheet.Id;
		}

		public async Task Approve(Guid id)
		{
			var sheet = await _repository.GetItem(id);
			sheet.ApproveSheet();
			await _repository.Update(sheet);
		}

		public async Task Delete(Guid id)
		{
			await _repository.Delete(id);
		}
	}
}
