using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public class EastDirection : IDirection
    {
        private IRover rover;

        public EastDirection(IRover rover)
        {
            this.rover = rover;
        }

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

        public void TurnLeft()
        {
            rover.GetRoverPosition()._direction = new NorthDirection(rover);
        }

        public void TurnRight()
        {
            rover.GetRoverPosition()._direction = new SouthDirection(rover);
        }
    }
}
