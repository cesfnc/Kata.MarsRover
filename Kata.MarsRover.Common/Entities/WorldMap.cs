namespace Kata.MarsRover.Common.Entities
{
    public class WorldMap(int m, int p, IEnumerable<Coordinates> obstacles)
    {
        public int M => m;
        public int P => p;
        public IEnumerable<Coordinates> Obstacles => obstacles;
    }
}
