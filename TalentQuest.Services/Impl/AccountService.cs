using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TalentQuest.Common.DTO.Request;
using TalentQuest.Data.Entities;
using TalentQuest.Data.UoW;

namespace TalentQuest.Services.Impl
{
	public class AccountService : IAccountService
	{
		private readonly IUnitOfWork _uow;
		private readonly IConfiguration _configuration;
		public AccountService(IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_uow = unitOfWork;
			_configuration = configuration;
		}
		public Task<User> AddUserAsync(User user)
		{
			throw new NotImplementedException();
		}

		public Task DeleteUserAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<User>> GetAllUsersAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			return await _uow.UsersRepository.FirstOrDefaultAsync(u => u.Email == email);
		}

		public Task<User> GetUserByIdAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<(User user, string accessToken)> LoginAsync(LoginRequestDto loginRequest)
		{
			var user = await _uow.UsersRepository.FirstOrDefaultAsync(u => u.Email == loginRequest.Email);
			if(!BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.PasswordHash))
			{
				 throw new Exception("Password doesn´t match");
			}
			var claims = GetClaims(user);
			var token = GetToken(claims);

			return (user, token);
		}

		public async Task SignUpAsync(RegisterRequestDto suRequest)
		{

			var recruiter = new Recruiter
			{
				User = new User
				{
					Id = Guid.NewGuid(),
					Email = suRequest.EmailAddress,
					PasswordHash = BCrypt.Net.BCrypt.HashPassword(suRequest.Password),
					FirstName = suRequest.FirstName,
					LastName = suRequest.LastName,
				}
			};

			await _uow.RecruitersRepository.CreateAsync(recruiter);
			await _uow.CommitAsync();
		}

		public Task<User> UpdateUserAsync(Guid id, User user)
		{
			throw new NotImplementedException();
		}

		private List<Claim> GetClaims(User user)
		{
			var issuer = _configuration.GetSection("JwtSettings")["Issuer"];
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, issuer),
				new Claim(ClaimTypes.Name, user.Email, ClaimValueTypes.String, issuer),
				new Claim(ClaimTypes.AuthenticationMethod, "bearer", ClaimValueTypes.String, issuer),
				new Claim(ClaimTypes.NameIdentifier, user.Email, ClaimValueTypes.String, issuer),
				new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, issuer),
			};
			return claims;
		}

		private string GetToken(IEnumerable<Claim> claims)
		{
			var issuer = _configuration.GetSection("JwtSettings")["Issuer"];
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings")["Key"]));

			var jwt = new JwtSecurityToken(issuer: issuer,
				audience: _configuration.GetSection("JwtSettings")["Audience"],
				claims: claims,
				notBefore: DateTime.UtcNow,
				expires: DateTime.UtcNow.AddHours(int.Parse(_configuration.GetSection("JwtSettings")["AccessTokenExpirationHours"])),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
			);

			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
	}
}
