using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImNew.Domain.Model
{
	public class Hobby
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual IList<User> Users { get; set; }
	}
}
