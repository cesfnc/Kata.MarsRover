namespace Kata.MarsRover.Common.Enums
{
    public class CommandMR
    {
        public CommandMR(Movement? movement, Rotation? rotation)
        {
            Movement = movement;
            Rotation = rotation;
        }

        public Movement? Movement { get; set; }
        public Rotation? Rotation { get; set; }
    }
}
