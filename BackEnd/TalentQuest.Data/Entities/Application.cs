using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities.Enums;

namespace TalentQuest.Data.Entities
{
	public class Application:BaseEntity
	{
		public Application()
		{
			CandidateDocuments = new HashSet<CandidateDocument>();
		}
		public Guid CandidateId { get; set; }
		public Candidate Candidate { get; set; }
		public Guid SelectionProcessId { get; set; }
		public SelectionProcess SelectionProcess { get; set; }
		public DateTime RegistrationDate { get; set; }
		public CandidateState CandidateState { get; set; }
		public ICollection<CandidateDocument> CandidateDocuments { get; set; }
	}
}
