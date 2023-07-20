using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TalentQuest.API.Responses
{
	public class ApiBadRequestResponse : ApiResponse

	{
		public ApiBadRequestResponse(ModelStateDictionary modelState)
			: base(400, "Bad Request")
		{
			Errors = modelState.SelectMany(x => x.Value.Errors)
				.Select(x => x.ErrorMessage).ToArray();
		}

		public IEnumerable<string> Errors { get; }
	}
}
