

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

            Assert.Equal(5, newLocation._x);
            Assert.Equal(5, newLocation._y);
            Assert.Equal(RobotDirection.N, newLocation._direction);
        }
        [Fact]
        public void MovesDirectionToEastIfSouth()
        {
            TurnLeftInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.S);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation._x);
            Assert.Equal(5, newLocation._y);
            Assert.Equal(RobotDirection.E, newLocation._direction);
        }

        [Fact]
        public void MovesDirectionToSouthIfWest()
        {
            TurnLeftInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.W);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation._x);
            Assert.Equal(5, newLocation._y);
            Assert.Equal(RobotDirection.S, newLocation._direction);
        }

        [Fact]
        public void MovesDirectionToWestIfNorth()
        {
            TurnLeftInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.N);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation._x);
            Assert.Equal(5, newLocation._y);
            Assert.Equal(RobotDirection.W, newLocation._direction);
        }
    }
}