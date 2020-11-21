using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class SouthDirection : IDirection
    {
        private IRover rover;

        public SouthDirection(IRover rover)
        {
            this.rover = rover;
        }

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

        public void TurnLeft()
        {
            rover.GetRoverPosition()._direction = new EastDirection(rover);
        }

        public void TurnRight()
        {
            rover.GetRoverPosition()._direction = new WestDirection(rover);
        }
    }
}
