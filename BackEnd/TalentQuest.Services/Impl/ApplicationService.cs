using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TalentQuest.Data.Entities;
using TalentQuest.Data.UoW;

namespace TalentQuest.Services.Impl
{
    public class ApplicationService : IApplicationService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public ApplicationService(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
		{
			_unitOfWork = unitOfWork;
			_hostingEnvironment = hostingEnvironment;
		}

		public async Task addDocumentToApplication(Guid candidateId, Guid selectionProcessId, IFormFile file, string fileName)
		{
			var application = await _unitOfWork.ApplicationsRepository.FirstOrDefaultAsync(a => a.CandidateId == candidateId && a.SelectionProcessId == selectionProcessId);
			if (application != null)
			{
				CandidateDocument document = new()
				{
					Id = Guid.NewGuid(),
					Name = file.FileName,
					CreatedAt = DateTime.Now,
					ModifiedAt = DateTime.Now,
					ApplicationId = application.Id
				};
				string uploadsFolder = Path.Combine(_hostingEnvironment.ContentRootPath, "UploadFiles");

				string uniqueFileName = document.Id.ToString() + "_" + document.Name;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (FileStream fileStream = new(filePath, FileMode.Create))
				{
					await file.CopyToAsync(fileStream);
				}
				document.Path = filePath;
				try
				{
					application.CandidateDocuments.Add(document);
				}
				catch (Exception e)
				{
					var message = e.Message;
					throw;
				}
				await _unitOfWork.CandidateDocumentsRepository.CreateAsync(document);
				await _unitOfWork.CommitAsync();
			}
		}

		public async Task<Application> GetAllApplicationByIdAsync(Guid applicationId)
		{
			return await _unitOfWork.ApplicationsRepository.GetByIdAsync(applicationId);
		}

		public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
		{
			var applications = await _unitOfWork.ApplicationsRepository.GetAll().Include(a => a.Candidate).Include(a => a.SelectionProcess).ToListAsync();
			return applications;
		}
	}
}
