using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cgol.App;
using Cgol.Domain.Infrastructure;

namespace Cgol.Func
{
	public class Program
	{
		public static void Main()
		{
			var host = new HostBuilder()
					.ConfigureFunctionsWorkerDefaults()
					.ConfigureServices(s =>
					{
						s.AddTransient<IGame, Game>();
						s.AddTransient<IGameFactory, GameFactory>();
						s.AddTransient<ITicker, Ticker>();
						s.AddTransient<INeighborCalculator, NeighborCalculator>();
					})
					.Build();
			host.Run();
		}
	}
}