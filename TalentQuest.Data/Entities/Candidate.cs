using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Data.Entities
{
	public class Candidate:BaseEntity
	{   
        public Candidate()
        {
			Applications = new HashSet<Application>();
		}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string LinkedinProfile { get; set; }
		public ICollection<Application> Applications { get; set; }
    }
}
