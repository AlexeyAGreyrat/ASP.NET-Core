using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Domain
{
	//Базовый интерфейс
	public interface IBaseManager<TObject, TRequest>
	{
		Task<TObject> GetItem(Guid id);
		Task<IEnumerable<TObject>> GetItems();
		Task<Guid> Create(TRequest request);
		Task Delete(Guid id);
	}
}
