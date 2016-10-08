using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;

namespace ImNew.Domain.Repositories
{
	public class RoleRepository: IRepository<Role>
	{
		public ImNewContext DbContext { get; }

		public RoleRepository(ImNewContext dbContext)
		{
			DbContext = dbContext;
		}
		public void Add(Role item)
		{
			DbContext.Roles.Add(item);
			DbContext.SaveChanges();
		}

		public void Edit(Role item)
		{
			DbContext.Entry(item).State = EntityState.Modified;
			DbContext.SaveChanges();
		}

		public Role GetSingle(int id)
		{
			return DbContext.Roles.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Role> GetAll()
		{
			return DbContext.Roles;
		}
	}
}
