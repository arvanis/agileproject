using System.Collections.Generic;
using System.Linq;
using ImNew.Domain.Model;
using ImNew.Domain.Repositories;

namespace ImNew.Services
{
	public class RoleService
	{
		public IRepository<Role> Repository { get;  }

		public RoleService(IRepository<Role> repository )
		{
			Repository = repository;
		}

		public IEnumerable<DtoRole> GetAllRoles()
		{
			return Repository.GetAll().Select(x => new DtoRole {Id = x.Id, Name = x.Name});
		}

		public void AddRole(string role)
		{
			Repository.Add(new Role
			{
				Name = role
			});
		}


	}
}
