using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Common.Entities
{
    public class Rover
    {
        public Rover(int x, int y, Orientation? orientation)
        {
            Position = new Coordinates(x, y);
            Orientation = orientation == null ? Orientation.N : orientation.Value;
        }

        public Coordinates Position { get; set; }
        public Orientation Orientation { get; set; }
    }
}
