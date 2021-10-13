using Cgol.App.Models;
using Cgol.Domain.Infrastructure;

namespace Cgol.App
{
	public class Ticker : ITicker
	{
		private INeighborCalculator neighborCalculator { get; set; }

		public Ticker(INeighborCalculator calculator)
		{
			neighborCalculator = calculator;
		}

		public ICell[,] Execute(ICell[,] board)
		{
			var xMax = board.GetLength(0);
			var yMax = board.GetLength(1);

			var result = board;

			for (var i = 0; i < xMax; i++)
				for (var j = 0; j < yMax; j++)
				{
					var isAlive = board[i, j].Alive;
					var numLivingNeighbors = neighborCalculator.Calc(board, i, j);
					var isAliveAfterTick = IsAliveAfterTick(isAlive, numLivingNeighbors);
					result[i, j] = new Cell() { Alive = isAliveAfterTick };
				}

			return result;
		}

		private bool IsAliveAfterTick(bool isAliveNow, int numLivingNeighbors)
		{
			if (isAliveNow && numLivingNeighbors < 2) return false;
			// Any live cell with two or three live neighbours lives on to the next generation.
			if (isAliveNow && numLivingNeighbors == 2) return true;
			if (isAliveNow && numLivingNeighbors == 3) return true;
			// Any live cell with more than three live neighbours dies, as if by overcrowding.
			if (isAliveNow && numLivingNeighbors > 3) return false;
			// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
			if (!isAliveNow && numLivingNeighbors == 3) return true;

			return false;
		}
	}
}