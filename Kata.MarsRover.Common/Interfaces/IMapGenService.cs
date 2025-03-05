using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Common.Interfaces
{
    public interface IMapGenService
    {
        WorldMap Create(int meridians, int parallels);
    }
}