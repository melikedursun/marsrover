using MarsRover.Entity;

namespace MarsRover.Core
{
    public interface IRover
    {
        void Move();
        void TurnLeft();
        void TurnRight();
        string GetCurrentLocation();
        Plateau GetPlateau();
        RoverPosition GetRoverPosition();
        void Run(string commands);
    }
}
