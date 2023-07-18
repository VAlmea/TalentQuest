using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentQuest.API.Responses;
using TalentQuest.Common.DTO.Request;
using TalentQuest.Common.DTO.Response;
using TalentQuest.Data.Entities;
using TalentQuest.Services;

namespace TalentQuest.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/candidate-processes")]
	public class CandidateProcessesController : ControllerBase
	{
		private readonly ILogger<CandidateProcessesController> _logger;
		private readonly IMapper _mapper;
		private readonly IApplicationService _applicationService;

		public CandidateProcessesController(ILogger<CandidateProcessesController> logger,
										IApplicationService applicationService,
										IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
			_applicationService = applicationService;
		}

		/// <summary>
		/// Get all applications
		/// </summary>
		/// <returns>
		/// A lis of applications
		/// </returns>
		/// <response code="200">Returns the list with all the applications</response>
		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<ApplicationResponseDto>>> Get()
		{
			var applications = await _applicationService.GetAllApplicationsAsync();
			var result = _mapper.Map<IEnumerable<ApplicationResponseDto>>(applications);
			return Ok(new ApiOkResponse(result));
		}		
	}
}