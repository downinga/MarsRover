

using MarsRover.Entities;
using MarsRover.Instructions;

namespace MarsRover.Tests
{
    public class TurnLeftInstructionTests
    {
        [Fact]
        public void MovesDirectionToNorthIfEast()
        {
            TurnLeftInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.E);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.N, newLocation.Direction);
        }
        [Fact]
        public void MovesDirectionToEastIfSouth()
        {
            TurnLeftInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.S);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.E, newLocation.Direction);
        }

        [Fact]
        public void MovesDirectionToSouthIfWest()
        {
            TurnLeftInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.W);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.S, newLocation.Direction);
        }

        [Fact]
        public void MovesDirectionToWestIfNorth()
        {
            TurnLeftInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.N);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.W, newLocation.Direction);
        }
    }
}