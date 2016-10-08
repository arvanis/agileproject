using System.Collections.Generic;

namespace ImNew.Domain.Model
{
	public class Techonology
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual IList<User> Users { get; set; }
	}
}
