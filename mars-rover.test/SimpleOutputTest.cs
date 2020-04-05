using mars_rover.Enums;
using mars_rover.Entities;
using mars_rover.Exceptions;
using mars_rover.Managers;
using Xunit;

namespace mars_rover.test
{
    public class SimpleOutputTest
    {

        [Theory]
        [InlineData(5, 5, 1, 2, RotationEnum.N, "LMLMLMLMM", "1 3 N")]
        [InlineData(5, 5, 3, 3, RotationEnum.E, "MMRMMRMRRM", "5 1 E")]
        public void get_expected_result(int width, int height, int pointX, int pointY, RotationEnum rotation, string command, string expectedResult)
        {
            var plateau = new Plateau(width, height);
            var location = new Location(pointX, pointY);
            var _rover = new MarsRover();
            _rover.SetPlateau(plateau);
            _rover.SetLocation(location, rotation);
            var _roverManager = new MarsRoverManager(_rover);
            _roverManager.ExecuteCommand(command);
            Assert.Equal(expectedResult, _roverManager.GetStatusText());
        }


        [Theory]
        [InlineData(5, 5, 3, 3, RotationEnum.E, "MMRMMRMRRMMMMMM")]
        public void get_out_of_border_exception(int width, int height, int pointX, int pointY, RotationEnum rotation, string command)
        {
            var plateau = new Plateau(width, height);
            var location = new Location(pointX, pointY);
            var _rover = new MarsRover();
            _rover.SetPlateau(plateau);
            _rover.SetLocation(location, rotation);
            var _roverManager = new MarsRoverManager(_rover);
            Assert.Throws<OutOfBorderException>(() => _roverManager.ExecuteCommand(command));
        }


        [Theory]
        [InlineData(5, 5, 3, 3, RotationEnum.E, "MMRMMRMRRMA")]
        public void get_invalid_command_exception(int width, int height, int pointX, int pointY, RotationEnum rotation, string command)
        {
            var plateau = new Plateau(width, height);
            var location = new Location(pointX, pointY);
            var _rover = new MarsRover();
            _rover.SetPlateau(plateau);
            _rover.SetLocation(location, rotation);
            var _roverManager = new MarsRoverManager(_rover);
            Assert.Throws<InvalidCommandException>(() => _roverManager.ExecuteCommand(command));
        }

    }
}
