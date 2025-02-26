using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Services.Test.RoverService_Tests
{
    [TestClass]
    public class RoverService_Land
    {
        private readonly RoverService sut;

        public RoverService_Land()
        {
            sut = new RoverService();
        }


        [TestMethod]
        [DataRow(0, 0, null)]
        [DataRow(0, 1, Orientation.N)]
        [DataRow(1, 0, Orientation.S)]
        public void ThrowsArgumentNullException_WhenParamsAre0(int n, int m, Orientation o)
        {
            Assert.ThrowsException<ArgumentException>(
                () => sut.Land(n, m, o));
        }
    }
}