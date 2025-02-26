using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;
using Kata.MarsRover.Common.Exceptions;

namespace Kata.MarsRover.Services
{
    public class RoverService : IRoverService
    {
        public Rover Land(int x, int y, Orientation o)
        {
            if (x == 0 || y == 0)
                throw new ArgumentException($"Rover coordinates must be at least one ({x},{y})");

            return new Rover(x, y, o);
        }

        public void Move(Rover rover, WorldMap map, Movement movement)
        {
            var newCoords = CoordinateService.Add(rover, movement, map);

            if (CoordinateService.Collide(newCoords, map.Obstacles))
                throw new CollisionException(newCoords);

            rover.Position = newCoords;
        }

        public void Rotate(Rover rover, Rotation rotation)
        {
            switch (rover.O)
            {
                case Orientation.N:
                    rover.O = rotation == Rotation.R ? Orientation.E : Orientation.W;
                    break;
                case Orientation.E:
                    rover.O = rotation == Rotation.R ? Orientation.S : Orientation.N;
                    break;
                case Orientation.S:
                    rover.O = rotation == Rotation.R ? Orientation.W : Orientation.E;
                    break;
                case Orientation.W:
                    rover.O = rotation == Rotation.R ? Orientation.N : Orientation.S;
                    break;
                default:
                    throw new ArgumentException($"{nameof(Rover)} has undefined {nameof(Rover.O)}");
            }
        }

    }
}
