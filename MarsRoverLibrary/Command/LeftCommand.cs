using MarsRover.Core;

namespace MarsRover.Command
{
    public class LeftCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.TurnLeft();
        }
    }
}