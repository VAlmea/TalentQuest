using System.ComponentModel.DataAnnotations;
using CandidateState = TalentQuest.Data.Entities.Enums.CandidateState;

namespace TalentQuest.Common.DTO.Response
{
	public class ApplicationResponseDto
	{
		public Guid Id { get; set; }
		public CandidateResponseDto Candidate { get; set; }
		public SelectionProcessResponseDto SelectionProcess { get; set; }
		[DataType(DataType.Date)]
		public DateTime RegistrationDate { get; set; }
		public CandidateState CandidateState { get; set; }
	}
}
