using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities;

namespace TalentQuest.Services
{
	public interface IApplicationService
	{
		Task addDocumentToApplication(Guid candidateId, Guid selectionProcessId, IFormFile file, string fileName);
		Task<IEnumerable<Application>> GetAllApplicationsAsync();
		Task<Application> GetAllApplicationByIdAsync(Guid applicationId);
	}
}
