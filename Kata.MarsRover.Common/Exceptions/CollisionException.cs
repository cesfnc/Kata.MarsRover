using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Common.Exceptions
{
    public class CollisionException : ApplicationBaseException
    {
        public CollisionException(Coordinates coordinates) 
            : base($"Coordinates '{coordinates.X},{coordinates.Y}' coincide with obstacle")
        {
            Data = new { coordinates };
        }
    }
}
