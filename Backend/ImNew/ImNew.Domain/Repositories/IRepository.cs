using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;

namespace ImNew.Domain.Repositories
{
	public interface IRepository<T>
	{
		ImNewContext DbContext { get; }
		void Add(T item);
		void Edit(T item);
		T GetSingle(int id);
	}
}
