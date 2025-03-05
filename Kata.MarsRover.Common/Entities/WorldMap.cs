namespace Kata.MarsRover.Common.Entities
{
    public class WorldMap(int meridians, int parallels, IEnumerable<Coordinates> obstacles)
    {
        public int Meridians => meridians;
        public int Parallels => parallels;
        public IEnumerable<Coordinates> Obstacles => obstacles;
    }
}
