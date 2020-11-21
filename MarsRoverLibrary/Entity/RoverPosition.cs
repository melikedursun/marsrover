using MarsRover.Core;
using MarsRover.DirectionOperation;
using MarsRoverProject.ExceptionHandler;
using MarsRoverProject.Helper;

namespace MarsRover.Entity
{
    public class RoverPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public IDirection _direction { get; set; }
        private IRover _rover { get; set; }
        private readonly Direction directionValue;

        public IRover Rover
        {
            get { return _rover; }
            set
            {
                _rover = value;
                _direction = DirectionHelper.GetDirection(_rover, directionValue);
            }
        }

        public RoverPosition(int xCoordinate, int yCoordinate, Direction direction)
        {
            X = xCoordinate;
            Y = yCoordinate;
            directionValue = direction;
        }

        public RoverPosition ValidateCoordinate(Plateau plateau)
        {
            if (X <= plateau.Width && Y <= plateau.Height)
            {
                return this;
            }
            else
            {
                throw new RoverException("Is not valid coordinate");
            }
        }

        public void Move()
        {
            _direction.Move(_rover);
        }

        public void TurnLeft()
        {
            _direction.TurnLeft();
        }

        public void TurnRight()
        {
            _direction.TurnRight();
        }
    }
}