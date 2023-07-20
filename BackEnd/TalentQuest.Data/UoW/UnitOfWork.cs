using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities;
using TalentQuest.Data.Repository;

namespace TalentQuest.Data.UoW
{
	public class UnitOfWork: IUnitOfWork, IDisposable
	{
		private readonly TalentQuestDbContext _context;
		public UnitOfWork(TalentQuestDbContext context)
		{
			_context = context;
			SelectionProcessRepository = new GenericRepository<SelectionProcess>(_context);
			RecruitersRepository = new GenericRepository<Recruiter>(_context);
			CandidatesRepository = new GenericRepository<Candidate>(_context);
			ApplicationsRepository = new GenericRepository<Application>(_context);
			UsersRepository = new GenericRepository<User>(_context);
			CandidateDocumentsRepository = new GenericRepository<CandidateDocument>(_context);
		}

		public IGenericRepository<SelectionProcess> SelectionProcessRepository { get; set ; }
		public IGenericRepository<Recruiter> RecruitersRepository { get; set ; }
		public IGenericRepository<Candidate> CandidatesRepository { get; set ; }
		public IGenericRepository<Application> ApplicationsRepository { get; set ; }
		public IGenericRepository<User> UsersRepository { get; set ; }
		public IGenericRepository<CandidateDocument> CandidateDocumentsRepository { get; set ; }

		public async Task<int> CommitAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
