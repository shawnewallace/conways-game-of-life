using System;
using System.Threading;
using Cgol.App;
using Cgol.Domain.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.Extensions.CommandLineUtils;

namespace Cgol.Con
{
  class Program
  {
    static void Main(string[] args)
    {
			
			var app = new CommandLineApplication();
			app.Name = "ConwaysGameOfLifeCon";
			app.Description = "Console version of Conway's Game of Life";
			app.HelpOption("-?|-h|--help");

			Console.Clear();

      var serviceProvider = new ServiceCollection()
        .AddLogging()
        .AddTransient<IGame, Game>()
        .AddTransient<IGameFactory, GameFactory>()
        .AddTransient<ITicker, Ticker>()
        .AddTransient<INeighborCalculator, NeighborCalculator>()
        .BuildServiceProvider();

      var logger = serviceProvider
        .GetService<ILoggerFactory>()
        .CreateLogger<Program>();

      logger.LogDebug("Starting Applicaiton");

      var creator = serviceProvider.GetService<IGameFactory>();
      creator.Width = 10;
      creator.Height = 10;
      creator.FillFactor = .5;
      //creator.Generator = BoardGenerator.Random;

      var game = creator.Execute();

      Console.WriteLine(game.ToString());
      Pause(1);

      DrawBoard(game);

      ICell[,] lastBoard;
      int numTicks = 0;
      do {
        lastBoard = DuplicateBoard(game.Board);
        game.Tick();
        numTicks++;

        DrawBoard(game);
      }
      while (BoardsAreDifferent(game, lastBoard));

      Console.WriteLine($"Board in steady state in '{numTicks}' ticks");

      logger.LogDebug("All done!");
      Console.WriteLine("All done!");
    }

    private static void DrawBoard(IGame game)
    {
      Console.Clear();
      Console.WriteLine(game.ToString());
      Pause(1);
    }

    private static ICell[,] DuplicateBoard(ICell[,] board)
    {
      return board.Clone() as ICell[,];
    }

    private static bool BoardsAreDifferent(IGame game, ICell[,] lastBoard)
    {
      var board = game.Board;
      var maxX = game.Width;
      var maxY = game.Height;
      for (var x = 0; x < maxX; x++)
      {
        for (var y = 0; y < maxY; y++)
        {
          if (board[x, y].Alive != lastBoard[x, y].Alive)
          {
            return true;
          }
        }
      }

      return false;
    }

    private static void Pause(int numSeconds = 3)
    {
      Thread.Sleep(numSeconds * 1000);
    }
  }
}
