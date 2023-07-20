using TalentQuest.API.Responses;

namespace TalentQuest.API.Responses
{
	public class ApiCreatedResponse : ApiResponse
	{
		public ApiCreatedResponse(object result)
			: base(201,"Created")
		{
			Result = result;
		}

		public object Result { get; }
	}
}
