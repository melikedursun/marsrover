using MarsRover.Core;

namespace MarsRover.Command
{
    public interface ICommand
    {
        void Execute(IRover rover);
    }
}