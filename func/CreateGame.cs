using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Cgol.App;

namespace Cgol.Func
{
	public class CreateGame
	{
		private GameFactory _gameFactory;

		public CreateGame(GameFactory gameFactory)
		{
			_gameFactory = gameFactory;
		}


		[Function("CreateGame")]
		public async Task<HttpResponseData> Run(
			[HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
			FunctionContext executionContext)
		{
			var response = req.CreateResponse(HttpStatusCode.OK, );
			response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

			response.WriteString($"Hello World, time and date are {DateTime.Now.ToString()}");

			return response;
		}
	}
}
