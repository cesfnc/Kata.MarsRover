using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Common.Entities
{
    public class Rover
    {
        public Rover(int x, int y, Orientation? o)
        {
            Position = new Coordinates(x, y);
            O = o == null ? Orientation.N : o.Value;
        }

        public Coordinates Position { get; set; }
        public Orientation O { get; set; }
    }
}
