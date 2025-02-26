using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;
using FluentAssertions;

namespace Kata.MarsRover.Services.Test.CoordinateService_Test
{

    [TestClass]
    public class CoordinateService_Add
    {
        [TestMethod]
        [DataRow(Movement.F, Orientation.N)]
        [DataRow(Movement.B, Orientation.N)]
        [DataRow(Movement.F, Orientation.S)]
        [DataRow(Movement.B, Orientation.S)]
        [DataRow(Movement.F, Orientation.W)]
        [DataRow(Movement.B, Orientation.W)]
        [DataRow(Movement.F, Orientation.E)]
        [DataRow(Movement.B, Orientation.E)]
        public void OneMovement_ReturnsTraslatedCoordinates(Movement m, Orientation o)
        {
            var rover = new Rover(0, 0, o);
            var map = new WorldMap(12, 6, new List<Coordinates> { });
            var actual = CoordinateService.Add(rover, m, map);

            actual.Should().NotBeNull().And.NotBeEquivalentTo(rover.Position);

            actual.X.Should().BeInRange(0, map.M);
            actual.Y.Should().BeInRange(0, map.P);
        }

        [TestMethod]
        [DataRow(Movement.F, Orientation.N)]
        [DataRow(Movement.B, Orientation.S)]
        public void OneNorthMove_ReturnsNorthTraslated(Movement m, Orientation o)
        {
            var rover = new Rover(4, 4, o);
            var map = new WorldMap(12, 6, new List<Coordinates> { });

            var actual = CoordinateService.Add(rover, m, map);
            var expected = new Coordinates(4, 5);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(Movement.B, Orientation.N)]
        [DataRow(Movement.F, Orientation.S)]
        public void OneSouthMove_ReturnsSouthTraslated(Movement m, Orientation o)
        {
            var rover = new Rover(4, 4, o);
            var map = new WorldMap(12, 6, new List<Coordinates> { });

            var actual = CoordinateService.Add(rover, m, map);
            var expected = new Coordinates(4, 3);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(Movement.B, Orientation.W)]
        [DataRow(Movement.F, Orientation.E)]
        public void OneWestMove_ReturnsWestTraslated(Movement m, Orientation o)
        {
            var rover = new Rover(4, 4, o);
            var map = new WorldMap(12, 6, new List<Coordinates> { });

            var actual = CoordinateService.Add(rover, m, map);
            var expected = new Coordinates(5, 4);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }

        [TestMethod]
        [DataRow(Movement.F, Orientation.W)]
        [DataRow(Movement.B, Orientation.E)]
        public void OneEastMove_ReturnsEastTraslated(Movement m, Orientation o)
        {
            var rover = new Rover(4, 4, o);
            var map = new WorldMap(12, 6, new List<Coordinates> { });

            var actual = CoordinateService.Add(rover, m, map);
            var expected = new Coordinates(3, 4);

            actual.Should().NotBeNull().And.BeEquivalentTo(expected);
        }
    }
}
