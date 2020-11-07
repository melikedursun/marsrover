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

        public RoverPosition(int xCoordinate, int yCoordinate, Direction direction)
        {
            X = xCoordinate;
            Y = yCoordinate;
            _direction = DirectionHelper.GetDirection(direction);
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
    }
}