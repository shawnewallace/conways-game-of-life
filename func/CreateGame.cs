using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Cgol.App;
using System.IO;
using Cgol.Func.Models;
using Newtonsoft.Json;

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
		public async Task<HttpResponseData> RunAsync(
			[HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req,
			FunctionContext executionContext)
		{
			var requestBody = string.Empty;

			using(var sr = new StreamReader(req.Body)){
				requestBody = await sr.ReadToEndAsync();
			}

			var data = JsonConvert.DeserializeObject<GameParameters>(requestBody);

			var response = req.CreateResponse(HttpStatusCode.OK);
			response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

			response.WriteString($"Hello World, time and date are {DateTime.Now.ToString()}");

			return response;
		}
	}
}
