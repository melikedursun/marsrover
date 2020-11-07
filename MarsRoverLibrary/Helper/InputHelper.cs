using MarsRover.DirectionOperation;
using MarsRover.Entity;
using MarsRoverLibrary.ExceptionHandler;
using System;
using System.Text.RegularExpressions;

namespace MarsRoverLibrary.Helper
{
    public class InputHelper
    {
        public static readonly string PlateauRegexPattern = @"(\d+)\s(\d+)";
        public static readonly string CoordinateRegexPattern = @"(\d+)\s(\d+)\s([N|E|S|W|n|e|s|w])";
        public static readonly string CommandRegexPattern = @"^[M|L|R|m|l|r]+$";

        public static bool CheckInput(string regexPattern, string input)
        {
            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(input);
        }

        public static Plateau GetPlateau(string input)
        {
            bool isValid = CheckInput(PlateauRegexPattern, input);
            if (isValid)
            {
                var inputArr = input.Split(" ");
                int x = Convert.ToInt32(inputArr[0]);
                int y = Convert.ToInt32(inputArr[1]);
                return new Plateau(x, y);

            }
            throw new InvalidInputException(string.Format("{0} is not valid plateau size", input));
        }

        public static RoverPosition GetRoverPosition(string input)
        {
            bool isValid = CheckInput(CoordinateRegexPattern, input);
            if (isValid)
            {
                var inputArr = input.Split(" ");
                int x = Convert.ToInt32(inputArr[0]);
                int y = Convert.ToInt32(inputArr[1]);
                Direction direction = (Direction)Enum.Parse(typeof(Direction), inputArr[2].ToUpper());
                return new RoverPosition(x, y, direction);
            }
            throw new InvalidInputException(string.Format("{0} is not valid rover position", input));
        }
    }
}