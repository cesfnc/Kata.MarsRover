using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Services
{
    public class MapGenService : IMapGenService
    {
        public WorldMap Create(int meridians, int parallels, IEnumerable<Coordinates> obstacles)
        {
            if (meridians == 0 || parallels == 0) throw new ArgumentException($"Map must have at least one meridian/parallel ({meridians},{parallels})");
            return new WorldMap(meridians, parallels, obstacles);
        }
    }
}
