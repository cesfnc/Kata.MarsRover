using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Services
{
    public interface IMapGenService
    {
        WorldMap Create(int meridians, int parallels, IEnumerable<Coordinates> obstacles);
    }
}