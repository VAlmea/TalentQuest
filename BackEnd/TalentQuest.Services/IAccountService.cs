using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentQuest.Common.DTO.Request;
using TalentQuest.Data.Entities;

namespace TalentQuest.Services
{
	public interface IAccountService
	{
		Task<User> AddUserAsync(User user);
		Task<IEnumerable<User>> GetAllUsersAsync();
		Task<User> GetUserByIdAsync(Guid id);
		Task<User> GetUserByEmailAsync(string email);
		Task<User> UpdateUserAsync(Guid id, User user);
		Task DeleteUserAsync(Guid id);
		Task SignUpAsync(RegisterRequestDto suRequest);
		Task<(User user, string accessToken)> LoginAsync(LoginRequestDto loginRequest);
	}
}
