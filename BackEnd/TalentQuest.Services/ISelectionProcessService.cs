using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Common.DTO.Request;
using TalentQuest.Data.Entities;

namespace TalentQuest.Services
{
	public interface ISelectionProcessService
	{
		Task<SelectionProcess> AddSelectionProcessAsync(SelectionProcessRequestDto selectionProcess);
		Task<SelectionProcess> GetSelectionProcessByIdAsync(Guid id);
		Task<IEnumerable<SelectionProcess>> GetSelectionProcessesAsync();
		Task<SelectionProcess> UpdateSelectionProcessAsync(Guid id, SelectionProcess selectionProcess);
		Task DeleteSelectionProcessAsync(Guid id);
	}
}
