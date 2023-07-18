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
	[Route("api/selection-process")]
	public class SelectionProcessController : ControllerBase
	{
		private readonly ILogger<SelectionProcessController> _logger;
		private readonly IMapper _mapper;
		private readonly ISelectionProcessService _selectionProcessService;
		private readonly ICandidateService _candidateService;
		private readonly IApplicationService _applicationService;

		public SelectionProcessController(ILogger<SelectionProcessController> logger,
										ISelectionProcessService selectionProcessService,
										IMapper mapper,
										ICandidateService candidateService, IApplicationService applicationService)
		{
			_logger = logger;
			_selectionProcessService = selectionProcessService;
			_mapper = mapper;
			_candidateService = candidateService;
			_applicationService = applicationService;
		}

		/// <summary>
		/// Get all selection processes
		/// </summary>
		/// <returns>
		/// A lis of selecion processes
		/// </returns>
		/// <response code="200">Returns the list with all selection processes</response>
		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<SelectionProcessResponseDto>>> Get()
		{
			var selectionProcesses = await _selectionProcessService.GetSelectionProcessesAsync();
			var result = _mapper.Map<IEnumerable<SelectionProcessResponseDto>>(selectionProcesses);
			return Ok(new ApiOkResponse(result));
		}

		/// <summary>
		/// Creates a Selecction Process.
		/// </summary>
		/// <returns>A newly created TodoItem</returns>
		/// <remarks>
		/// Sample request:
		///
		///     POST /Todo
		///     {
		///        "name": "Selection Process #1",
		///        "startDate": 2023-06-24,
		///        "endDate": 2023-06-24,
		///        "ProcessState": 0,
		///        "Recruiters": ["2c0ce974-a8a0-48c0-8ac9-7daadf90ccab", "ecb67b9c-d105-48a7-a14c-5baade11526e" ]
		///     }
		///
		/// </remarks>
		/// <response code="201">Returns the newly created selection process</response>
		/// <response code="400">If the item is null</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<SelectionProcessResponseDto>> Post(SelectionProcessRequestDto requestDto)
		{
			SelectionProcess selectionProcess = await _selectionProcessService.AddSelectionProcessAsync(requestDto);
			SelectionProcessResponseDto result = _mapper.Map<SelectionProcessResponseDto>(selectionProcess);
			return Created("", new ApiCreatedResponse(result));
		}

		/// <summary>
		/// Get a selection process by id
		/// </summary>
		/// <returns>
		/// </returns>
		/// <response code="200">Returns the selection proccess</response>
		/// <response code="404">Returns Not Found</response>
		[HttpGet("{id}")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

		public async Task<ActionResult<SelectionProcessResponseDto>> Get(Guid id)
		{
			var selectionProcess = await _selectionProcessService.GetSelectionProcessByIdAsync(id);
			if (selectionProcess == null)
				return NotFound(new ApiResponse(404, "Not Found"));

			var result = _mapper.Map<SelectionProcessResponseDto>(selectionProcess);
			return Ok(new ApiOkResponse(result));
		}

		/// <summary>
		/// Remove a selection process by id
		/// </summary>
		/// <returns>
		/// </returns>
		/// <response code="204">Returns No Content if the selection process was removed</response>
		/// <response code="404">Returns Not Found</response>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var selectionProcess = await _selectionProcessService.GetSelectionProcessByIdAsync(id);
			if (selectionProcess == null)
				return NotFound(new ApiResponse(404, "Not Found"));

			await _selectionProcessService.DeleteSelectionProcessAsync(id);
			return NoContent();
		}

		/// <summary>
		/// Get candidates by selection process by id
		/// </summary>
		/// <returns>
		/// </returns>
		/// <response code="200">The candidates who applied to the selection process</response>
		/// <response code="404">Returns Not Found</response>
		[HttpGet("{id}/candidates")]
		[Produces("application/json")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		public async Task<ActionResult<IEnumerable<CandidateResponseDto>>> GetCandidates(Guid id)
		{
			var selectionProcess = await _selectionProcessService.GetSelectionProcessByIdAsync(id);
			if (selectionProcess == null)
				return NotFound(new ApiResponse(404, "Not Found"));

			var candidates = await _candidateService.GetCandidatesBySelectionProcessIdAsync(id);
			var result = _mapper.Map<IEnumerable<CandidateResponseDto>>(candidates);
			return Ok(new ApiOkResponse(result));
		}

		/// <summary>
		/// Add document to candidate
		/// </summary>
		/// <returns>
		/// </returns>
		/// <response code="200">The candidates who applied to the selection process</response>
		/// <response code="404">Returns Not Found</response>
		[HttpPost("{id}/candidates/{candidateId}/documents")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<IEnumerable<CandidateResponseDto>>> UploadDocumment(Guid id, Guid candidateId, IFormFile file, string fileName)
		{
			var selectionProcess = await _selectionProcessService.GetSelectionProcessByIdAsync(id);
			var candidate = await _candidateService.GetCandidateByIdAsync(candidateId);
			if (selectionProcess == null)
				return NotFound(new ApiResponse(404, "SelectionProcess Not Found"));
			if (candidate == null)
				return NotFound(new ApiResponse(404, "Candidate Not Found"));
			await _applicationService.addDocumentToApplication(candidateId, id, file, fileName);
			return Ok(new ApiResponse(200, "Success"));
		}

		/// <summary>
		/// Add candidate to selection process
		/// </summary>
		/// <returns>
		/// </returns>
		/// <response code="200">The new candidate</response>
		/// <response code="400">Bad request</response>
		[HttpPost("{id}/candidates")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<CandidateResponseDto>> AddCandidateToProcess(Guid id, CandidateRequestDto requestDto)
		{
			var candidate = _mapper.Map<Candidate>(requestDto);
			var data = await _candidateService.AddCandidateToSelectionProcessAsync(id, candidate);
			var result = _mapper.Map<CandidateResponseDto>(data);
			return Ok(new ApiOkResponse(result));
		}
	}
}