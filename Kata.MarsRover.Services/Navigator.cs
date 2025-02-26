using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Services
{
    public class Navigator
    {
        private Rover? RoverOne { get; set; }
        private WorldMap? MarsMap { get; set; }

        private readonly IRoverService roverService;
        private readonly IMapGenService mapGenService;
        private readonly ICommandRetriever commandRetriever;

        public Navigator(IRoverService roverService, IMapGenService mapGenService, ICommandRetriever commandRetriever)
        {
            this.roverService = roverService;
            this.mapGenService = mapGenService;
            this.commandRetriever = commandRetriever;
        }

        public void SetUp()
        {
            MarsMap = mapGenService.Create(36,18, new List<Coordinates> {  });
            RoverOne = roverService.Land(0,0,Orientation.E);
        }

        public void SendCommandsToRover() 
        {
            var commands = commandRetriever.GetList();
            if (commands == null)
                return;

            foreach (CommandMR command in commands) {
                if(command.Movement.HasValue && RoverOne != null && MarsMap != null)
                    roverService.Move(RoverOne, MarsMap, command.Movement.Value);
                if(command.Rotation.HasValue && RoverOne != null)
                    roverService.Rotate(RoverOne, command.Rotation.Value);            
            }
        }
    }
}
