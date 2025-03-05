using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;
using Moq;
using System.Runtime.InteropServices;

namespace Kata.MarsRover.Services.Test.RoverService_Tests
{
    [TestClass]
    public class Navigator_SendCommandsToRover
    {
        private readonly Navigator sut;
        private readonly Mock<IRoverService> roverService;
        private readonly Mock<IMapGenService> mapGenService;
        private readonly Mock<ICommandRetriever> commandRetriever;

        public Navigator_SendCommandsToRover()
        {
            roverService = new Mock<IRoverService>();
            mapGenService = new Mock<IMapGenService>();
            commandRetriever = new Mock<ICommandRetriever>();
            sut = new Navigator(roverService.Object, mapGenService.Object, commandRetriever.Object);
        }


        [TestMethod]
        public void NoIteration_WhenCommandsIsEmptyList()
        {
            commandRetriever
                .Setup(_ => _.GetList())
                .Returns([]);
            sut.SendCommandsToRover();

            roverService.Verify(_ => _.Move(It.IsAny<Rover>(), It.IsAny<WorldMap>(), It.IsAny<Movement>()), Times.Never());
            roverService.Verify(_ => _.Rotate(It.IsAny<Rover>(), It.IsAny<Rotation>()), Times.Never());
        }

        //esempio igor nome metodo
        //start_shouldMoveAndRotateRoverBasedOnCommands

        //Redundant
        [TestMethod]
        public void ShouldMoveAndRotate_WhenCommandsAreDefined()
        {
            var commands = new List<CommandMR>() { 
                new(Movement.Front, null),
                new(Movement.Back, null),
                new(null, Rotation.Right),
                new(null, Rotation.Left)
            };

            commandRetriever
                .Setup(_ => _.GetList())
                .Returns(commands);

            mapGenService
                .Setup(_ => _.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<Coordinates>>()))
                .Returns(new WorldMap(10, 10, []));

            roverService.Setup(_ => _.Land(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()))
                .Returns(new Rover(0, 0, null));

            sut.SetUp();
            sut.SendCommandsToRover();

            roverService.Verify(_ => _.Move(It.IsAny<Rover>(), It.IsAny<WorldMap>(), It.IsAny<Movement>()), Times.Exactly(2));
            roverService.Verify(_ => _.Rotate(It.IsAny<Rover>(), It.IsAny<Rotation>()), Times.Exactly(2));
        }

        [DataRow(Rotation.Left)]
        [DataRow(Rotation.Right)]
        [TestMethod]
        public void ShouldRotate_WhenRotateCommandIsDefined(Rotation rotation)
        {
            var commands = new List<CommandMR>() { new(null, rotation) };

            commandRetriever
                .Setup(_ => _.GetList())
                .Returns(commands);

            mapGenService
                .Setup(_ => _.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<Coordinates>>()))
                .Returns(new WorldMap(10, 10, []));

            roverService.Setup(_ => _.Land(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()))
                .Returns(new Rover(0, 0, null));

            sut.SetUp();
            sut.SendCommandsToRover();

            roverService.Verify(_ => _.Move(It.IsAny<Rover>(), It.IsAny<WorldMap>(), It.IsAny<Movement>()), Times.Never);
            roverService.Verify(_ => _.Rotate(It.IsAny<Rover>(), It.IsAny<Rotation>()), Times.Exactly(1));
        }

        [DataRow(Movement.Front)]
        [DataRow(Movement.Back)]
        [TestMethod]
        public void ShouldMove_WhenMoveCommandIsDefined(Movement m)
        {
            var commands = new List<CommandMR>() { new(m, null) };

            commandRetriever
                .Setup(_ => _.GetList())
            .Returns(commands);

            mapGenService
                .Setup(_ => _.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<Coordinates>>()))
                .Returns(new WorldMap(10, 10, []));

            roverService.Setup(_ => _.Land(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()))
                .Returns(new Rover(0,0,null));

            sut.SetUp();
            sut.SendCommandsToRover();

            roverService.Verify(_ => _.Move(It.IsAny<Rover>(), It.IsAny<WorldMap>(), It.IsAny<Movement>()), Times.Exactly(1));
            roverService.Verify(_ => _.Rotate(It.IsAny<Rover>(), It.IsAny<Rotation>()), Times.Never);
        }
    }
}