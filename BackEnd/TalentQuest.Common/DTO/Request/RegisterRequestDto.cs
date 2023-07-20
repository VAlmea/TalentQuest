using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentQuest.Common.DTO.Request
{
	public class RegisterRequestDto
	{
		[Required]
        public string FirstName { get; set; }
		[Required]
        public string LastName { get; set; }
        [Required]
		public string EmailAddress { get; set; }
		[Required]
		public string Password { get; set; }

		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}
}
