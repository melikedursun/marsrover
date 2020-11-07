using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class WestDirection : IDirection
    {
        public Direction DirectionName()
        {
            return Direction.W;
        }

        public void Move(IRover rover)
        {
            if (rover.GetPlateau().IsValidXCoordinate(rover.GetRoverPosition().X - 1))
            {
                rover.GetRoverPosition().X--;
            }
        }

        public IDirection TurnLeft()
        {
            return new SouthDirection();
        }

        public IDirection TurnRight()
        {
            return new NorthDirection();
        }
    }
}
