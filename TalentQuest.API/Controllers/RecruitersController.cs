using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentQuest.API.Responses;
using TalentQuest.Common.DTO.Response;
using TalentQuest.Services;

namespace TalentQuest.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/recruiters")]
	public class RecruitersController : ControllerBase
	{
		private readonly ILogger<RecruitersController> _logger;
		private readonly IMapper _mapper;
		private readonly IRecruiterService _recruiterService;

		public RecruitersController(ILogger<RecruitersController> logger,
										IRecruiterService recruiterService,
										IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
			_recruiterService = recruiterService;
		}

		/// <summary>
		/// Get all recruiters
		/// </summary>
		/// <returns>
		/// A lis of recruiters
		/// </returns>
		/// <response code="200">Returns the list with all the recruiters</response>
		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<RecruiterResponseDto>>> Get()
		{
			var recruiter = await _recruiterService.GetAllRecruitersAsync();
			var result = _mapper.Map<IEnumerable<RecruiterResponseDto>>(recruiter);
			return Ok(new ApiOkResponse(result));
		}		
	}
}