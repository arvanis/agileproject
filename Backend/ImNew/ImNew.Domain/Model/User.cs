using System.Collections.Generic;

namespace ImNew.Domain.Model
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }

		public virtual IList<Techonology> Techonologies { get; set; }
		public virtual IList<Hobby> Hobbies { get; set; }
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }

	}
}
