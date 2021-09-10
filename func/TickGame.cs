using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Cgol.Domain.Infrastructure;

namespace Cgol.Func
{
	public class TickGame
	{
		private ITicker _gameTicker;

		public TickGame(ITicker gameTicker)
		{
			_gameTicker = gameTicker;
		}

		[Function("TickGame")]
		public async Task<HttpResponseData> RunAsync(
			[HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
			FunctionContext executionContext)
		{
			var response = req.CreateResponse(HttpStatusCode.OK);
			response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

			response.WriteString($"Hello World, time and date are {DateTime.Now.ToString()}");

			return response;
		}
	}
}
