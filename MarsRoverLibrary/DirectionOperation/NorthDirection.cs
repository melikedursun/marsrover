using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class NorthDirection : IDirection
    {
        private readonly IRover rover;

        public NorthDirection(IRover rover)
        {
            this.rover = rover;
        }

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

        public void TurnLeft()
        {
            rover.GetRoverPosition()._direction = new WestDirection(rover);
        }

        public void TurnRight()
        {
            rover.GetRoverPosition()._direction = new EastDirection(rover);
        }
    }
}