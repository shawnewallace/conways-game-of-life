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

			_gameFactory.Width = 20;
			_gameFactory.Height = 20;
			_gameFactory.FillFactor = .5;

			var game = _gameFactory.Execute();

			var serializedGame = JsonConvert.SerializeObject(game);

			var response = req.CreateResponse(HttpStatusCode.Created);
			await response.WriteStringAsync(serializedGame);
			response.Headers.Add("Content-Type", "application/json");

			return response;
		}
	}

	public class TickGame {}
	public class GameList {}
}
