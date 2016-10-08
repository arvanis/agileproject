using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;
using ImNew.Domain.Repositories;

namespace ImNew.Infrastructure
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
