﻿using System;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface ISheetManager : IBaseManager<SheetAggregate, SheetRequest>
	{
		Task Approve(Guid id);
	}
}
