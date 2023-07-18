using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentQuest.API.Responses;
using TalentQuest.Common.DTO.Request;
using TalentQuest.Services;

namespace TalentQuest.API.Controllers
{
	//[Authorize]
	[Route("api/account")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;
		public AccountController(IAccountService accountService)
		{			
			_accountService = accountService;
		}

		[HttpPost("login")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult> Login(LoginRequestDto loginRequestDto)
		{
			var user = await _accountService.GetUserByEmailAsync(loginRequestDto.Email);

			if (user == null)
				return Unauthorized(new ApiResponse(401, "Unauthorized"));

			var result = await _accountService.LoginAsync(loginRequestDto);

			return Ok(new ApiOkResponse(new { accessToken = result.accessToken }));
		}

		[HttpPost("register")]
		[ProducesResponseType(typeof(ApiOkResponse), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]

		public async Task<ActionResult> Register(RegisterRequestDto registerDto)
		{
			var userExists = await _accountService.GetUserByEmailAsync(registerDto.EmailAddress);
			if (userExists != null)
			{
				return BadRequest(new ApiResponse(400, "User already exists"));
			}		

			await _accountService.SignUpAsync(registerDto);

			return Ok(new ApiResponse(200, "Ok"));
		}
	}
}
