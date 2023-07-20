using AutoMapper;
using TalentQuest.Common.DTO.Request;
using TalentQuest.Common.DTO.Response;
using TalentQuest.Data.Entities;

namespace TalentQuest.API.Utils
{
	public class MappingProfiles: Profile
	{
		public MappingProfiles()
		{
			CreateMap<SelectionProcess, SelectionProcessResponseDto>();
			CreateMap<CandidateRequestDto, Candidate>();
			CreateMap<Candidate, CandidateResponseDto>();
			CreateMap<Application, ApplicationResponseDto>();
			CreateMap<Recruiter, RecruiterResponseDto>()
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
		}
	}
}
