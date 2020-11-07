using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class NorthDirection : IDirection
    {
        public Direction DirectionName()
        {
            return Direction.N;
        }

        public void Move(IRover rover)
        {
            if (rover.GetPlateau().IsValidYCoordinate(rover.GetRoverPosition().Y + 1))
            {
                rover.GetRoverPosition().Y++;
            }
        }

        public IDirection TurnLeft()
        {
            return new WestDirection();
        }

        public IDirection TurnRight()
        {
            return new EastDirection();
        }
    }
}
