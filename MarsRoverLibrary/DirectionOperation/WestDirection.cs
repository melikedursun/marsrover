using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class WestDirection : IDirection
    {
        private IRover rover;

        public WestDirection(IRover rover)
        {
            this.rover = rover;
        }

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

        public void TurnLeft()
        {
            rover.GetRoverPosition()._direction = new SouthDirection(rover);
        }

        public void TurnRight()
        {
            rover.GetRoverPosition()._direction = new NorthDirection(rover);
        }
    }
}
