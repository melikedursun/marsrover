using System.Collections.Generic;
using MarsRover.Command;
using MarsRover.Helper;
using MarsRover.Entity;

namespace MarsRover.Core
{
    public class Rover : IRover
    {
        private Plateau _plateau;
        private RoverPosition _roverPosition;

        public Rover(Plateau plateau, RoverPosition roverPosition)
        {
            _plateau = plateau;
            _roverPosition = roverPosition.ValidateCoordinate(plateau);
        }

        public void Move()
        {
            _roverPosition._direction.Move(this);
        }

        public void TurnLeft()
        {
            _roverPosition._direction = _roverPosition._direction.TurnLeft();
        }

        public void TurnRight()
        {
            _roverPosition._direction = _roverPosition._direction.TurnRight();
        }

        public string GetCurrentLocation()
        {
            return _roverPosition.X + " " + _roverPosition.Y + " " + _roverPosition._direction.DirectionName();
        }

        public Plateau GetPlateau()
        {
            return _plateau;
        }

        public RoverPosition GetRoverPosition()
        {
            return _roverPosition;
        }

        public void Run(string commands)
        {
            CommandHelper commandHelper = new CommandHelper(commands);
            List<ICommand> _commands = commandHelper.CreateCommand();
            foreach (var command in _commands)
            {
                command.Execute(this);
            }
        }
    }
}
