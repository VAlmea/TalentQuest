using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Common.DTO.Request
{
	public class CandidateRequestDto
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public DateTime BirthDate { get; set; }
		public string LinkedinProfile { get; set; }
	}
}
