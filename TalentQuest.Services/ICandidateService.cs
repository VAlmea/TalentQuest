using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities;

namespace TalentQuest.Services
{
	public interface ICandidateService
	{
		Task<Candidate> AddCandidateAsync(Candidate candidate);
		Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
		Task<IEnumerable<Candidate>> GetCandidatesBySelectionProcessIdAsync(Guid processId);
		Task<Candidate> GetCandidateByIdAsync(Guid id);
		Task<Candidate> AddCandidateToSelectionProcessAsync(Guid id, Candidate candidate);
	}
}
