using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class EastDirection : IDirection
    {
        public Direction DirectionName()
        {
            return Direction.E;
        }

        public void Move(IRover rover)
        {
            if (rover.GetPlateau().IsValidXCoordinate(rover.GetRoverPosition().X + 1))
            {
                rover.GetRoverPosition().X++;
            }
        }

        public IDirection TurnLeft()
        {
            return new NorthDirection();
        }

        public IDirection TurnRight()
        {
            return new SouthDirection();
        }
    }
}
