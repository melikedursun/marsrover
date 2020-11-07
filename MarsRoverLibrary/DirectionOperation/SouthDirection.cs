using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class SouthDirection : IDirection
    {
        public Direction DirectionName()
        {
            return Direction.S;
        }

        public void Move(IRover rover)
        {
            if (rover.GetPlateau().IsValidYCoordinate(rover.GetRoverPosition().Y - 1))
            {
                rover.GetRoverPosition().Y--;
            }
        }

        public IDirection TurnLeft()
        {
            return new EastDirection();
        }

        public IDirection TurnRight()
        {
            return new WestDirection();
        }
    }
}
