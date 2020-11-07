using MarsRoverProject.ExceptionHandler;
using System;

namespace MarsRoverLibrary.ExceptionHandler
{
    public class InvalidInputException : RoverException
    {
        public InvalidInputException(string message) : base(message)
        {
        }

        public InvalidInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}