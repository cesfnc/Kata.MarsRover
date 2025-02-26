﻿using Kata.MarsRover.Common.Entities;
using Kata.MarsRover.Common.Enums;

namespace Kata.MarsRover.Services
{
    public interface IRoverService
    {
        Rover Land(int x, int y, Orientation o);
        void Move(Rover rover, WorldMap map, Movement movement);
        void Rotate(Rover rover, Rotation rotation);
    }
}