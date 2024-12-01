

using MarsRover.Entities;
using MarsRover.Instructions;

namespace MarsRover.Tests
{
    public class TurnRightInstructionTests
    {
        [Fact]
        public void MovesDirectionToSouthIfEast()
        {
            TurnRightInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.E);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.S, newLocation.Direction);
        }
        [Fact]
        public void MovesDirectionToWestIfSouth()
        {
            TurnRightInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.S);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.W, newLocation.Direction);
        }

        [Fact]
        public void MovesDirectionToNorthIfWest()
        {
            TurnRightInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.W);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.N, newLocation.Direction);
        }

        [Fact]
        public void MovesDirectionToEastIfNorth()
        {
            TurnRightInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.N);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.E, newLocation.Direction);
        }
    }
}