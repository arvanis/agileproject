using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ImNew.Domain.Model;
using ImNew.Domain.Repositories;

namespace ImNew.Services
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
                RoleId = user.RoleId.ToString(),

                Hobbies = user.Hobbies.Select(x => x.Name).ToList()
            };
        }

        public void AddUser(DtoUserDetails DtoUser)
        {
            var user = new User();

            //user.Id = DtoUser.Id;
            user.Name = DtoUser.Name;
            user.Surname = DtoUser.Surname;

	        int roleId;
			user.Role = int.TryParse(DtoUser.RoleId, out roleId) && roleId > 0 ? Repository.DbContext.Roles.FirstOrDefault(y => y.Id == roleId) : Repository.DbContext.Roles.FirstOrDefault(y => y.Name == DtoUser.Role);
			//user.RoleId = DtoUser.RoleId;

			if(DtoUser.Technologies != null)
				user.Techonologies = DtoUser.Technologies.Select(x => Repository.DbContext.Techonologies.FirstOrDefault(y => y.Name == x)).ToList();
			if(DtoUser.Hobbies != null)
				user.Hobbies = DtoUser.Hobbies.Select(x => Repository.DbContext.Hobbies.FirstOrDefault(y => y.Name == x)).ToList();

			Repository.Add(user);
        }

        public void EditUser(DtoUserDetails DtoUser)
        {
            var user = Repository.GetSingle(DtoUser.Id);

            user.Name = DtoUser.Name;
            user.Surname = DtoUser.Surname;

            user.Role = Repository.DbContext.Roles.FirstOrDefault(y => y.Name == DtoUser.Role);

            user.Techonologies = DtoUser.Technologies.Select(x => Repository.DbContext.Techonologies.FirstOrDefault(y => y.Name == x)).ToList();
            user.Hobbies = DtoUser.Hobbies.Select(x => Repository.DbContext.Hobbies.FirstOrDefault(y => y.Name == x)).ToList();

			Repository.Edit(user);
        }

		public IEnumerable<DtoUser> GetUsers(string name, string surname, int role)
		{
			var all = Repository.GetAll();

			if (!string.IsNullOrWhiteSpace(name))
				all = all.Where(x => x.Name.Contains(name));
			if (!string.IsNullOrWhiteSpace(surname))
				all = all.Where(x => x.Surname.Contains(surname));
			if (role > 0)
				all = all.Where(x => x.RoleId == role);

			return all.Select(x => new DtoUser
			{
				Id = x.Id,
				Name = x.Name,
				Surname = x.Surname
			});
		}

		public void DeleteUser(int id)
		{
			var user = Repository.GetSingle(id);
			Repository.DbContext.Entry(user).State = EntityState.Deleted;
			Repository.DbContext.SaveChanges();
		}
	}
}