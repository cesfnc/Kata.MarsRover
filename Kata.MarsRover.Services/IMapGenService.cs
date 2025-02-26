using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Services
{
    public interface IMapGenService
    {
        WorldMap Create(int m, int p, IEnumerable<Coordinates> obstacles);
    }
}