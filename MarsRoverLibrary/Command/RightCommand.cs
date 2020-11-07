using MarsRover.Core;

namespace MarsRover.Command
{
    public class RightCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.TurnRight();
        }
    }
}