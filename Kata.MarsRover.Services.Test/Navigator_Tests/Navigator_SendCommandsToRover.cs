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
                .Returns(new List<CommandMR> { });
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
                new CommandMR(Movement.F, null),
                new CommandMR(Movement.B, null),
                new CommandMR(null, Rotation.R),
                new CommandMR(null, Rotation.L)
            };

            commandRetriever
                .Setup(_ => _.GetList())
                .Returns(commands);

            mapGenService
                .Setup(_ => _.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<Coordinates>>()))
                .Returns(new WorldMap(10, 10, new List<Coordinates> { }));

            roverService.Setup(_ => _.Land(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()))
                .Returns(new Rover(0, 0, null));

            sut.SetUp();
            sut.SendCommandsToRover();

            roverService.Verify(_ => _.Move(It.IsAny<Rover>(), It.IsAny<WorldMap>(), It.IsAny<Movement>()), Times.Exactly(2));
            roverService.Verify(_ => _.Rotate(It.IsAny<Rover>(), It.IsAny<Rotation>()), Times.Exactly(2));
        }

        [DataRow(Rotation.L)]
        [DataRow(Rotation.R)]
        [TestMethod]
        public void ShouldRotate_WhenRotateCommandIsDefined(Rotation r)
        {
            var commands = new List<CommandMR>() { new CommandMR(null, r) };

            commandRetriever
                .Setup(_ => _.GetList())
                .Returns(commands);

            mapGenService
                .Setup(_ => _.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<Coordinates>>()))
                .Returns(new WorldMap(10, 10, new List<Coordinates> { }));

            roverService.Setup(_ => _.Land(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()))
                .Returns(new Rover(0, 0, null));

            sut.SetUp();
            sut.SendCommandsToRover();

            roverService.Verify(_ => _.Move(It.IsAny<Rover>(), It.IsAny<WorldMap>(), It.IsAny<Movement>()), Times.Never);
            roverService.Verify(_ => _.Rotate(It.IsAny<Rover>(), It.IsAny<Rotation>()), Times.Exactly(1));
        }

        [DataRow(Movement.F)]
        [DataRow(Movement.B)]
        [TestMethod]
        public void ShouldMove_WhenMoveCommandIsDefined(Movement m)
        {
            var commands = new List<CommandMR>() { new CommandMR(m, null) };

            commandRetriever
                .Setup(_ => _.GetList())
            .Returns(commands);

            mapGenService
                .Setup(_ => _.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<IEnumerable<Coordinates>>()))
                .Returns(new WorldMap(10, 10, new List<Coordinates> { }));

            roverService.Setup(_ => _.Land(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Orientation>()))
                .Returns(new Rover(0,0,null));

            sut.SetUp();
            sut.SendCommandsToRover();

            roverService.Verify(_ => _.Move(It.IsAny<Rover>(), It.IsAny<WorldMap>(), It.IsAny<Movement>()), Times.Exactly(1));
            roverService.Verify(_ => _.Rotate(It.IsAny<Rover>(), It.IsAny<Rotation>()), Times.Never);
        }
    }
}