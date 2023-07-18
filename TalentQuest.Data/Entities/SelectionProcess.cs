using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities.Enums;

namespace TalentQuest.Data.Entities
{
	public class SelectionProcess:BaseEntity
	{
        public SelectionProcess()
        {
			Recruiters = new HashSet<Recruiter>();
			Applications = new HashSet<Application>();
		}
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ProcessState ProcessState { get; set; }
        public ICollection<Recruiter> Recruiters { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
