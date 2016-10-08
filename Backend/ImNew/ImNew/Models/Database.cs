using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImNew.Domain.Model;

namespace ImNew.Models
{
	public static class Database
	{
		public static  ImNewContext DbContext { get; } = new ImNewContext();

	}
}