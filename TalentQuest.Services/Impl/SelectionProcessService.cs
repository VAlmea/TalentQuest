using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Common.DTO.Request;
using TalentQuest.Data.Entities;
using TalentQuest.Data.UoW;

namespace TalentQuest.Services.Impl
{
	public class SelectionProcessService : ISelectionProcessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public SelectionProcessService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_hostingEnvironment = webHostEnvironment;
		}

		public async Task<SelectionProcess> AddSelectionProcessAsync(SelectionProcessRequestDto requestDto)
		{
			Expression<Func<Recruiter, bool>> filter = r => requestDto.Recruiters.Contains(r.Id);
			var recruiters = await _unitOfWork.RecruitersRepository.FindAllAsync(filter);
			var selectionProcess = new SelectionProcess
			{
				Name = requestDto.Name,
				StartDate = requestDto.StartDate,
				EndDate = requestDto.EndDate,
				Recruiters = recruiters.ToList()
			};
			await _unitOfWork.SelectionProcessRepository.CreateAsync(selectionProcess);
			await _unitOfWork.CommitAsync();
			return selectionProcess;
		}

		public async Task DeleteSelectionProcessAsync(Guid id)
		{
			SelectionProcess selectionProcess = await _unitOfWork.SelectionProcessRepository.GetByIdAsync(id);
			if (selectionProcess != null)
			{
				_unitOfWork.SelectionProcessRepository.Delete(selectionProcess);
				await _unitOfWork.CommitAsync();
			}
		}		

		public Task<SelectionProcess> GetSelectionProcessByIdAsync(Guid id)
		{
			return _unitOfWork.SelectionProcessRepository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<SelectionProcess>> GetSelectionProcessesAsync()
		{
			return await _unitOfWork.SelectionProcessRepository.GetAllAsync();
		}

		public async Task<SelectionProcess> UpdateSelectionProcessAsync(Guid id, SelectionProcess selectionProcessData)
		{
			SelectionProcess selectionProcess = await _unitOfWork.SelectionProcessRepository.GetByIdAsync(id);
			if (selectionProcess != null)
			{
				selectionProcess.Name = selectionProcessData.Name;
				selectionProcess.StartDate = selectionProcessData.StartDate;
				selectionProcess.EndDate = selectionProcessData.EndDate;
				_unitOfWork.SelectionProcessRepository.Update(selectionProcess);
				await _unitOfWork.CommitAsync();
			}
			return selectionProcess;
		}
	}
}
