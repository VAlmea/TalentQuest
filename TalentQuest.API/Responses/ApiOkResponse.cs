namespace TalentQuest.API.Responses
{
	public class ApiOkResponse:ApiResponse
	{
		public ApiOkResponse(object data):base(200,"OK")
		{
			Data = data;
		}
		public object Data { get; set; }
	}
}
