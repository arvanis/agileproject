using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImNew.Domain.Model
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }

		public virtual IList<Techonology> Techonologies { get; set; }
		public virtual IList<Hobby> Hobbies { get; set; }

		[ForeignKey("Role")]
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }

	}
}
