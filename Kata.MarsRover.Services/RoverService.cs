using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;
using Kata.MarsRover.Common.Exceptions;

namespace Kata.MarsRover.Services
{
    public class RoverService : IRoverService
    {
        public Rover Land(int x, int y, Orientation orientation)
        {
            if (x == 0 || y == 0)
                throw new ArgumentException($"Rover coordinates must be at least one ({x},{y})");

            return new Rover(x, y, orientation);
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
            rover.Orientation = rover.Orientation switch
            {
                Orientation.N => rotation == Rotation.Right ? Orientation.E : Orientation.W,
                Orientation.E => rotation == Rotation.Right ? Orientation.S : Orientation.N,
                Orientation.S => rotation == Rotation.Right ? Orientation.W : Orientation.E,
                Orientation.W => rotation == Rotation.Right ? Orientation.N : Orientation.S,
                _ => throw new ArgumentException($"{nameof(Rover)} has undefined {nameof(Rover.Orientation)}"),
            };
        }

    }
}
