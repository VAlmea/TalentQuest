using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Data.Entities
{
	public class Recruiter:BaseEntity
	{
		public Recruiter()
		{
			SelectionProcesses = new HashSet<SelectionProcess>();
		}
		public ICollection<SelectionProcess> SelectionProcesses { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
