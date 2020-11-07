using System;

namespace MarsRoverProject.ExceptionHandler
{
    public class RoverException : Exception
    {
        public RoverException(string message) : base(message)
        {
        }

        public RoverException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}