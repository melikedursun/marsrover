using MarsRover.DirectionOperation;

namespace MarsRoverProject.Helper
{
    public static class DirectionHelper
    {
        public static IDirection GetDirection(Direction direction)
        {
            return direction switch
            {
                Direction.N => new NorthDirection(),
                Direction.S => new SouthDirection(),
                Direction.E => new EastDirection(),
                Direction.W => new WestDirection(),
                _ => null,
            };
        }
    }
}
