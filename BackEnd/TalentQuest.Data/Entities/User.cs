using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Data.Entities
{
	public class User: BaseEntity
	{
		public User()
		{
			Roles = new HashSet<Role>();
		}
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public ICollection<Role> Roles { get; set; }
		public Recruiter Recruiter { get; set; }
    }
}
