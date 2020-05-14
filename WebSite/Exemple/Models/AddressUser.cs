using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class AddressUser
	{
		public string Rue { get; set; }
		public string Ville { get; set; }
		public string Pays { get; set; }
		public string Numero { get; set; }
		public int CodePostal { get; set; }
	}
}
