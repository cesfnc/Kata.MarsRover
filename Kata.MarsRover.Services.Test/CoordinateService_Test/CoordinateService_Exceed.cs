using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Services.Test.CoordinateService_Test
{
    [TestClass]
    public class CoordinateService_Exceed
    {
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(12, 0)]
        [DataRow(0, 6)]
        [DataRow(12, 6)]
        public void CoordinatesOnMap_DoesNotExceed(int x, int y)
        {
            var position = new Coordinates(x, y);
            var map = new WorldMap(12, 6, new List<Coordinates> { });

            var actual = CoordinateService.Exceed(position, map);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(13, 0)]
        [DataRow(0, -1)]
        [DataRow(0, 7)]
        public void CoordinatesOverMap_DoesExceed(int x, int y)
        {
            var position = new Coordinates(x, y);
            var map = new WorldMap(12, 6, new List<Coordinates> { });

            var actual = CoordinateService.Exceed(position, map);
            Assert.IsTrue(actual);
        }
    }
}