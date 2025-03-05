using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Common.Interfaces
{
    public interface IRoverService
    {
        Rover Land(int x, int y, Orientation orientation);
        void Move(Rover rover, WorldMap map, Movement movement);
        void Rotate(Rover rover, Rotation rotation);
    }
}