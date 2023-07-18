using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Data.Entities.Enums;

namespace TalentQuest.Common.DTO.Response
{
	public class SelectionProcessResponseDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		[DataType(DataType.Date)]
		public DateTime StartDate { get; set; }
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }
		public ProcessState ProcessState { get; set; }
	}
}
