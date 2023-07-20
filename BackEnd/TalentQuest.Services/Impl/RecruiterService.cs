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
	public class RecruiterService : IRecruiterService
	{
		private readonly IUnitOfWork _unitOfWork;
		public RecruiterService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Recruiter> AddRecruiterAsync(Recruiter recruiter)
		{
			await _unitOfWork.RecruitersRepository.CreateAsync(recruiter);
			return recruiter;
		}

		public async Task DeleteRecruiterAsync(Guid id)
		{
			var recruiter = await _unitOfWork.RecruitersRepository.GetByIdAsync(id);
			_unitOfWork.RecruitersRepository.Delete(recruiter);
		}

		public async Task<IEnumerable<Recruiter>> GetAllRecruitersAsync()
		{
			return await _unitOfWork.RecruitersRepository.GetAll().Include(r=>r.User).ToListAsync();
		}

		public async Task<Recruiter> GetRecruiterByIdAsync(Guid id)
		{
			return await _unitOfWork.RecruitersRepository.GetByIdAsync(id);
		}

		public Task<Recruiter> UpdateRecruiterAsync(Guid id, Recruiter recruiter)
		{
			throw new NotImplementedException();
		}
	}
}
