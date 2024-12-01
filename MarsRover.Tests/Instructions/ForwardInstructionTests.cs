

using MarsRover.Entities;
using MarsRover.Instructions;

namespace MarsRover.Tests
{
    public class ForwardInstructionTests
    {
        [Fact]
        public void MovesLocationToEastIfEast()
        {
            ForwardInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.E);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(6, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.E, newLocation.Direction);
        }
        [Fact]
        public void MovesLocationToSouthIfSouth()
        {
            ForwardInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.S);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(4, newLocation.Y);
            Assert.Equal(RobotDirection.S, newLocation.Direction);
        }

        [Fact]
        public void MovesLocationToWestIfWest()
        {
            ForwardInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.W);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(4, newLocation.X);
            Assert.Equal(5, newLocation.Y);
            Assert.Equal(RobotDirection.W, newLocation.Direction);
        }

        [Fact]
        public void MovesLocationToNorthIfNorth()
        {
            ForwardInstruction strategy = new();
            RobotLocation robotLocation = new(5,5, RobotDirection.N);

            var newLocation = strategy.Execute(robotLocation);

            Assert.Equal(5, newLocation.X);
            Assert.Equal(6, newLocation.Y);
            Assert.Equal(RobotDirection.N, newLocation.Direction);
        }
    }
}