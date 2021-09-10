using Cgol.Domain.Infrastructure;

namespace Cgol.Func.Models
{
	public class GameParameters : IGameParameters
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public double FillFactor { get; set; }
	}
}