using System;
using MarsRover.Entity;
using MarsRover.Core;
using System.Collections.Generic;
using MarsRoverLibrary.Helper;
using MarsRoverLibrary.ExceptionHandler;

namespace MarsRoverClient
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plateau Size (Example: 5 5)");
            var sizeInput = Console.ReadLine();
            Plateau plateau = InputHelper.GetPlateau(sizeInput);

            List<IRover> roverList = new List<IRover>();
            while (true)
            {
                Console.WriteLine("Rover Position (Example: 1 2 N)");
                var roverPositionInput = Console.ReadLine();

                Console.WriteLine("Rover Command (Example: LMLMLMLMM)");
                var roverCommandInput = Console.ReadLine();

                RoverPosition roverPosition = InputHelper.GetRoverPosition(roverPositionInput);

                bool isValidCommandInput = InputHelper.CheckInput(InputHelper.CommandRegexPattern, roverCommandInput);
                if (!isValidCommandInput)
                {
                    throw new InvalidInputException(string.Format("{0} is not valid command", roverCommandInput));
                }
                
                if (roverPosition != null && plateau != null)
                {
                    IRover rover = new Rover(plateau, roverPosition);
                    rover.Run(roverCommandInput);
                    roverList.Add(rover);
                }

                Console.WriteLine("Add another rover? (Y/N)");
                var addRoverInput = Console.ReadLine();

                if (!addRoverInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
            }

            foreach(var r in roverList)
            {
                Console.WriteLine(r.GetCurrentLocation());
            }
        }
    }
}
