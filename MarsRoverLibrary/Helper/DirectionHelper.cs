using MarsRover.Core;
using MarsRover.DirectionOperation;

namespace MarsRoverProject.Helper
{
    public static class DirectionHelper
    {
        public static IDirection GetDirection(IRover rover, Direction direction)
        {
            return direction switch
            {
                Direction.N => new NorthDirection(rover),
                Direction.S => new SouthDirection(rover),
                Direction.E => new EastDirection(rover),
                Direction.W => new WestDirection(rover),
                _ => null,
            };
        }
    }
}
