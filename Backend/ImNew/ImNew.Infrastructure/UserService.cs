using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImNew.Domain.Model;
using ImNew.Domain.Repositories;

namespace ImNew.Infrastructure
{
	public class UserService
	{
		public IRepository<User> Repository { get; }

		public UserService(IRepository<User> userRepository)
		{
			Repository = userRepository;
			if (Repository.GetAll().ToList().Count == 0)
				InitData();
		}

		private void InitData()
		{
			var result = new Role
			{
				Name = "Junior Developer"
			};
			Repository.DbContext.Roles.Add(result);
			Repository.Add(new User
			{
				Name = "Jan",
				Surname = "Kowalski",
				Role = result
			});
			Repository.DbContext.SaveChanges();
		}

		public IEnumerable<DtoUser> GetAllUsers()
		{
			return Repository.GetAll().Select(user => new DtoUser
			{
				Id = user.Id,
				Name = user.Name,
				Surname = user.Surname,
				Role = user.Role.Name
			});
		}
	}
}
