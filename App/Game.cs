using Cgol.App.Models;
using Cgol.Domain.Infrastructure;

namespace Cgol.App
{
	public class Game : IGame
	{
		public Game() { }
		public Game(ITicker ticker, ICell[,] board)
		{
			Ticker = ticker;
			Board = board;
		}

		public int Height { get { return Board.GetLength(1); } }
		public int Width { get { return Board.GetLength(0); } }
		public ICell[,] Board { get; private set; }
		ICell[,] _lastBoard;
		public ITicker Ticker { get; }

		public bool IsAliveAt(int x, int y) => Board[x, y].Alive;
		public void Tick()
		{
			Board = Ticker.Execute(Board);
		}

		public override string ToString()
		{
			var result = "";

			for (int i = 0; i < Width; i++)
			{
				for (var j = 0; j < Height; j++)
				{
					if (IsAliveAt(i, j))
						result += "*";
					else
						result += " ";
				}
				result += "\n";
			}

			return result;
		}
	}
}