using FluentAssertions;
using Moq;
using Xunit;
using MarsRover.Command;
using MarsRover.Core;
using MarsRover.Helper;
using MarsRover.Entity;
using MarsRoverProject.Helper;
using System.Collections.Generic;
using System.Linq;
using MarsRoverLibrary.Helper;
using MarsRoverLibrary.ExceptionHandler;

namespace MarsRoverTest
{
    public class MarsRoverTest
    {
        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void Run_WithCorrectParameter_ReturnSuccess(string plateauSize, string roverPositionInput, string command, string expectedDirection)
        {
            //Arrange
            Plateau plateau = InputHelper.GetPlateau(plateauSize);
            RoverPosition roverPosition = InputHelper.GetRoverPosition(roverPositionInput);
            IRover rover = new Rover(plateau, roverPosition);
            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(x => x.Execute(rover));

            //Act
            rover.Run(command);

            //Assert
            rover.GetRoverPosition()._direction.DirectionName().ToString().Should().Be(expectedDirection.Last().ToString());
        }

        [Theory]
        [InlineData("1 2N")]
        [InlineData("12 E")]
        public void GetRoverPosition_WhenInvalidPosition_ShouldThrowException(string roverPositionInput)
        {
            //Arrange 
            string exceptionMessage = string.Format("{0} is not valid rover position", roverPositionInput);

            //Act
            var exception = Assert.Throws<InvalidInputException>(() => InputHelper.GetRoverPosition(roverPositionInput));

            //Assert
            exception.Should().NotBeNull();
            Assert.Equal(exceptionMessage, exception.Message);
        }

        [Theory]
        [InlineData("LM")]
        [InlineData("MR")]
        public void CreateCommand_WithCorrectParameter_ReturnSuccess(string commands)
        {
            //Arrange
            CommandHelper commandHelper = new CommandHelper(commands);
            var mockCommand = new Mock<ICommand>();
            var dictionary = new Dictionary<string, ICommand>()
            {
                { "M", new MoveCommand() },
                { "L", new LeftCommand() },
                { "R", new RightCommand() }
            };
            List<ICommand> testCommands = new List<ICommand>();
            var commandsArray = commands.ToCharArray();
            ICommand commands1 = dictionary[commandsArray[0].ToString()];
            ICommand commands2 = dictionary[commandsArray[1].ToString()];
            testCommands.Add(commands1);
            testCommands.Add(commands2);

            //Act
            List<ICommand> listCommand = commandHelper.CreateCommand();

            //Assert
            Assert.Collection(listCommand,
              elem1 => Assert.Equal(testCommands[0].GetType().Name, elem1.GetType().Name),
              elem2 => Assert.Equal(testCommands[1].GetType().Name, elem2.GetType().Name)
              );
        }

        [Theory]
        [InlineData(5, 5)]
        public void PlateauIsValidXCoordinate_WithWrongParameter_ReturnFalse(int xCoordinate, int yCoordinate)
        {
            //Arrange
            Plateau plateau = new Plateau(xCoordinate, yCoordinate);

            //Act
            var actalResult = plateau.IsValidXCoordinate(xCoordinate + 1);

            //Assert
            actalResult.Should().BeFalse();
        }

        [Theory]
        [InlineData(5, 5)]
        public void PlateauIsValidYCoordinate_WithCorrectParameter_ReturnSuccess(int xCoordinate, int yCoordinate)
        {
            //Arrange
            Plateau plateau = new Plateau(xCoordinate, yCoordinate);

            //Act
            var actalResult = plateau.IsValidYCoordinate(yCoordinate);

            //Assert
            actalResult.Should().BeTrue();
        }


        [Fact]
        public void LogHelperWriteLine_WhenInputData_ReturnSuccess()
        {

            //Act & Arrange
            var ex = Record.Exception(() => LogHelper.WriteLine(It.IsAny<string>()));

            //Assert
            ex.Should().BeNull();
        }

        [Fact]
        public void LogHelperWrite_WhenInputData_ReturnSuccess()
        {

            //Act & Arrange
            var ex = Record.Exception(() => LogHelper.Write(It.IsAny<string>()));

            //Assert
            ex.Should().BeNull();
        }
    }
}
