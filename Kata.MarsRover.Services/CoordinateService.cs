using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Services
{
    public static class CoordinateService
    {
        public static Coordinates Add(Rover rover, Movement movement, WorldMap map)
        {
            var partialCoords = GetPartialCoordinates(rover, movement);
            var newCoords = new Coordinates(
                rover.Position.X + partialCoords.X,
                rover.Position.Y + partialCoords.Y);

            if (Exceed(newCoords, map))
                newCoords = Remap(newCoords, map);
            return newCoords;
        }

        public static bool Collide(Coordinates coordinates, IEnumerable<Coordinates> obstacles)
        {
            return obstacles.Any(_ => _.Equals(coordinates));
        }

        public static bool Exceed(Coordinates coordinates, WorldMap map)
        {
            return coordinates.Y < 0 ||
                coordinates.X < 0 ||
                coordinates.Y > map.Parallels ||
                coordinates.X > map.Meridians;
        }

        public static Coordinates Remap(Coordinates coordinates, WorldMap map)
        {
            var result = new Coordinates(coordinates.X, coordinates.Y);
            if (coordinates.X < 0) result.X = map.Meridians;
            if (coordinates.X > map.Meridians) result.X = 0;

            if (coordinates.Y < 0) result.Y = map.Parallels;
            if (coordinates.Y > map.Parallels) result.Y = 0;

            return result;
        }


        private static Coordinates GetPartialCoordinates(Rover rover, Movement movement)
        {
            var result = new Coordinates();
            switch (rover.Orientation)
            {
                case Orientation.N:
                    result.Y = movement == Movement.Front ? 1 : -1;
                    break;
                case Orientation.S:
                    result.Y = movement == Movement.Front ? -1 : 1;
                    break;
                case Orientation.W:
                    result.X = movement == Movement.Front ? -1 : 1;
                    break;
                case Orientation.E:
                    result.X = movement == Movement.Front ? 1 : -1;
                    break;
                default:
                    throw new ArgumentException($"{nameof(Rover)} has undefined {nameof(Rover.Orientation)}");
            }
            return result;
        }

    }
}
