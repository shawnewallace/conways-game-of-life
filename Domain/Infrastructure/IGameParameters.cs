namespace Cgol.Domain.Infrastructure
{
	public interface IGameParameters
	{
		int Width { get; set; }
		int Height { get; set; }
		double FillFactor { get; set; }
	}
}
