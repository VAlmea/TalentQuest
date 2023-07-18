using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities;

namespace TalentQuest.Services
{
	public interface IRecruiterService
	{
		Task<Recruiter> AddRecruiterAsync(Recruiter recruiter);
		Task<IEnumerable<Recruiter>> GetAllRecruitersAsync();
		Task<Recruiter> GetRecruiterByIdAsync(Guid id);
		Task<Recruiter> UpdateRecruiterAsync(Guid id, Recruiter recruiter);
		Task DeleteRecruiterAsync(Guid id);
	}
}
