using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;

namespace ImNew.Domain.Repositories
{
	class UserRepository: IRepository<User>
	{
		public ImNewContext DbContext { get; }

		public UserRepository()
		{
			DbContext = new ImNewContext();
		}

		public void Add(User item)
		{
			DbContext.Users.Add(item);
			Save();

		}

		public void Edit(User item)
		{
			DbContext.Entry(item).State = EntityState.Modified;
			Save();
		}

		public User GetSingle(int id)
		{
			return DbContext.Users.FirstOrDefault(x => x.Id == id);
		}

		private void Save()
		{
			DbContext.SaveChanges();
		}
	}
}
