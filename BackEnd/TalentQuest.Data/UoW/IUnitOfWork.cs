using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities;
using TalentQuest.Data.Repository;

namespace TalentQuest.Data.UoW
{
	public interface IUnitOfWork
	{
		IGenericRepository<SelectionProcess> SelectionProcessRepository { get; set; }
		IGenericRepository<Recruiter> RecruitersRepository { get; set; }
		IGenericRepository<Candidate> CandidatesRepository { get; set; }
		IGenericRepository<Application> ApplicationsRepository { get; set; }
		IGenericRepository<User> UsersRepository { get; set; }
		IGenericRepository<CandidateDocument> CandidateDocumentsRepository { get; set; }

		Task<int> CommitAsync();
	}
}
