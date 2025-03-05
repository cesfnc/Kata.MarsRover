using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;
using FluentAssertions;

namespace Kata.MarsRover.Services.Test.CoordinateService_Test
{

    [TestClass]
    public class CoordinateService_Add
    {
        [TestMethod]
        [DataRow(Movement.Front, Orientation.N)]
        [DataRow(Movement.Back, Orientation.N)]
        [DataRow(Movement.Front, Orientation.S)]
        [DataRow(Movement.Back, Orientation.S)]
        [DataRow(Movement.Front, Orientation.W)]
        [DataRow(Movement.Back, Orientation.W)]
        [DataRow(Movement.Front, Orientation.E)]
        [DataRow(Movement.Back, Orientation.E)]
        public void OneMovement_ReturnsTraslatedCoordinates(Movement movement, Orientation orientation)
        {
            var rover = new Rover(0, 0, orientation);
            var map = new WorldMap(12, 6, []);
            var actual = CoordinateService.Add(rover, movement, map);

            actual.Should().NotBeNull().And.NotBeEquivalentTo(rover.Position);

            actual.X.Should().BeInRange(0, map.Meridians);
            actual.Y.Should().BeInRange(0, map.Parallels);
        }

        [TestMethod]
        [DataRow(Movement.Front, Orientation.N)]
        [DataRow(Movement.Back, Orientation.S)]
        public void OneNorthMove_ReturnsNorthTraslated(Movement movement, Orientation orientation)
        {
            var rover = new Rover(4, 4, orientation);
            var map = new WorldMap(12, 6, []);

            var actual = CoordinateService.Add(rover, movement, map);
            var expected = new Coordinates(4, 5);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(Movement.Back, Orientation.N)]
        [DataRow(Movement.Front, Orientation.S)]
        public void OneSouthMove_ReturnsSouthTraslated(Movement movement, Orientation orientation)
        {
            var rover = new Rover(4, 4, orientation);
            var map = new WorldMap(12, 6, []);

            var actual = CoordinateService.Add(rover, movement, map);
            var expected = new Coordinates(4, 3);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(Movement.Back, Orientation.W)]
        [DataRow(Movement.Front, Orientation.E)]
        public void OneWestMove_ReturnsWestTraslated(Movement movement, Orientation orientation)
        {
            var rover = new Rover(4, 4, orientation);
            var map = new WorldMap(12, 6, []);

            var actual = CoordinateService.Add(rover, movement, map);
            var expected = new Coordinates(5, 4);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(Movement.Front, Orientation.W)]
        [DataRow(Movement.Back, Orientation.E)]
        public void OneEastMove_ReturnsEastTraslated(Movement movement, Orientation orientation)
        {
            var rover = new Rover(4, 4, orientation);
            var map = new WorldMap(12, 6, []);

            var actual = CoordinateService.Add(rover, movement, map);
            var expected = new Coordinates(3, 4);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }
    }
}
