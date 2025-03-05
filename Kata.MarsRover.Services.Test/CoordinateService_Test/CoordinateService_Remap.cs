using FluentAssertions;
using Kata.MarsRover.Common.Entities;

namespace Kata.MarsRover.Services.Test.CoordinateService_Test
{
    [TestClass]
    public class CoordinateService_Remap
    {
        [TestMethod]
        [DataRow(-1, 0, 12, 0)]
        [DataRow(13, 0, 0, 0)]
        [DataRow(-1, 0, 12, 0)]
        [DataRow(0, 7, 0, 0)]
        public void ExceedMapCoordinates_DoesModifyCoordinates(int x, int y, int xRemapped, int yRemapped )
        {
            var position = new Coordinates(x, y);
            var map = new WorldMap(12, 6, []);

            var actual = CoordinateService.Remap(position, map);
            var expected = new Coordinates(xRemapped, yRemapped);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);

        }
    }
}