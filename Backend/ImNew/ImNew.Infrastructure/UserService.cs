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

		public DtoUser GetUser(int id)
		{
			var user = Repository.GetSingle(id);
			return new DtoUser
			{
				Name = user.Name,
				Surname = user.Surname,
				Id = id,
				Role = user.Role.Name
			};
		}

        public DtoUserDetails GetUserDetails(int id)
        {
            var user = Repository.GetSingle(id);
            return new DtoUserDetails
            {
                Name = user.Name,
                Surname = user.Surname,
                Id = id,

                Technologies = user.Techonologies.Select(x => x.Name).ToList(),

                Role = user.Role.Name,
                RoleId = user.RoleId,

                Hobbies = user.Hobbies.Select(x => x.Name).ToList()
            };
        }

        public void AddUser(DtoUserDetails DtoUser)
        {
            var user = new User();

            user.Id = DtoUser.Id;
            user.Name = DtoUser.Name;
            user.Surname = DtoUser.Surname;

            user.Role = Repository.DbContext.Roles.FirstOrDefault(y => y.Name == DtoUser.Role);
            user.RoleId = DtoUser.RoleId;

            user.Techonologies = DtoUser.Technologies.Select(x => Repository.DbContext.Techonologies.FirstOrDefault(y => y.Name == x)).ToList();
            user.Hobbies = DtoUser.Hobbies.Select(x => Repository.DbContext.Hobbies.FirstOrDefault(y => y.Name == x)).ToList();
        }
	}
}