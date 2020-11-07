using MarsRover.Core;

namespace MarsRover.Command
{
    public class MoveCommand : ICommand
    {
        public void Execute(IRover rover)
        {
            rover.Move();
        }
    }
}