using Kata.MarsRover.Common.Entities;
using Moq;

namespace Kata.MarsRover.Services.Test.MapGenService_Tests
{
    [TestClass]
    public class MapGenService_Create
    {
        private readonly MapGenService sut;

        public MapGenService_Create()
        {
            sut = new MapGenService();
        }


        [TestMethod]
        [DataRow(0,0)]
        [DataRow(0,1)]
        [DataRow(1,0)]
        public void ThrowsArgumentException_WhenParamsAre0(int n, int m)
        {
            Assert.ThrowsException<ArgumentException>(
                () => sut.Create(n, m, It.IsAny<IEnumerable<Coordinates>>()));
        }
    }
}