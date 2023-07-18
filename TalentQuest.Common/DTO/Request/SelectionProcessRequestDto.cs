using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities.Enums;

namespace TalentQuest.Common.DTO.Request
{
	public class SelectionProcessRequestDto
	{
		[Required]
        public string Name { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }
		public List<Guid> Recruiters { get; set; }
		[Required]
		public ProcessState ProcessState { get; set; }
	}
}
