using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Services
{
    public class MapGenService : IMapGenService
    {
        public WorldMap Create(int m, int p, IEnumerable<Coordinates> obstacles)
        {
            if (m == 0 || p == 0) throw new ArgumentException($"Map must have at least one meridian/parallel ({m},{p})");
            return new WorldMap(m, p, obstacles);
        }
    }
}
