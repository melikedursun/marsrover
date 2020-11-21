using MarsRover.Core;

namespace MarsRover.DirectionOperation
{
    public interface IDirection
    {
        Direction DirectionName();
        void Move(IRover rover);
        void TurnLeft();
        void TurnRight();
    }
}
