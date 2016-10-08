using System.Data.Entity;

namespace ImNew.Domain.Model
{
	public class ImNewContext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Techonology> Techonologies { get; set; }
		public DbSet<Hobby> Hobbies { get; set; }
		public DbSet<Role> Roles { get; set; }
	}
}
