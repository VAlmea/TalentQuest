using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Data.Entities
{
	public class Role
	{
		public Role()
		{
			Users = new HashSet<User>();
		}
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<User> Users { get; set; }
	}
}
