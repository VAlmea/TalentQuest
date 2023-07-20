using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities;
using TalentQuest.Data.UoW;

namespace TalentQuest.Services.Impl
{
	public class CandidateService : ICandidateService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CandidateService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<Candidate> AddCandidateAsync(Candidate candidate)
		{
			await _unitOfWork.CandidatesRepository.CreateAsync(candidate);
			await _unitOfWork.CommitAsync();
			return candidate;
		}

		public Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<Candidate> GetCandidateByIdAsync(Guid id)
		{
			return await _unitOfWork.CandidatesRepository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<Candidate>> GetCandidatesBySelectionProcessIdAsync(Guid id)
		{
			var candidates = _unitOfWork.ApplicationsRepository.GetAll().Where(a => a.SelectionProcessId == id).Select(a => a.Candidate);
			return await candidates.ToListAsync();
		}

		public async Task<Candidate> AddCandidateToSelectionProcessAsync(Guid id, Candidate candidate)
		{
			candidate.Id = Guid.NewGuid();
			await _unitOfWork.CandidatesRepository.CreateAsync(candidate);
			var application = new Application
			{
				CandidateId = candidate.Id,
				SelectionProcessId = id
			};
			await _unitOfWork.ApplicationsRepository.CreateAsync(application);
			await _unitOfWork.CommitAsync();
			return candidate;
		}
	}
}
