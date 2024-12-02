using MarsRover.Entities;

namespace MarsRover.Tests
{
    public class MarsMapTests
    {
        [Fact]
        public void FalseIfRobotHasNotBeenPreviouslyLost()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(10, 10, RobotDirection.N);
            var anotherRobotLocation = new RobotLocation(9, 10, RobotDirection.N);

            marsMap.AddLostRobotLocation(robotLocation);
            var isRobotLost = marsMap.HasARobotFallenOffEdge(anotherRobotLocation);

            Assert.False(isRobotLost);
        }

        [Fact]
        public void TrueIfRobotHasBeenPreviouslyLost()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(10, 10, RobotDirection.N);
            var anotherRobotLocation = new RobotLocation(10, 10, RobotDirection.N);

            marsMap.AddLostRobotLocation(robotLocation);
            var isRobotLost = marsMap.HasARobotFallenOffEdge(anotherRobotLocation);

            Assert.True(isRobotLost);
        }

        [Fact]
        public void TrueIfRobotHasBeenPreviouslyLostInDifferentDirection()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(9, 10, RobotDirection.N);
            var anotherRobotLocation = new RobotLocation(9, 10, RobotDirection.E);

            marsMap.AddLostRobotLocation(robotLocation);
            var isRobotLost = marsMap.HasARobotFallenOffEdge(anotherRobotLocation);

            Assert.True(isRobotLost);
        }

        [Fact]
        public void RobotOnMap()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(5, 5, RobotDirection.N);

            var isRobotOnMap = marsMap.IsLocationOnMap(robotLocation);

            Assert.True(isRobotOnMap);
        }

        [Fact]
        public void RobotOffMapPositiveX()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(11, 10, RobotDirection.N);

            var isRobotOnMap = marsMap.IsLocationOnMap(robotLocation);

            Assert.False(isRobotOnMap);
        }

        [Fact]
        public void RobotOffMapPositiveY()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(10, 11, RobotDirection.N);

            var isRobotOnMap = marsMap.IsLocationOnMap(robotLocation);

            Assert.False(isRobotOnMap);
        }

        [Fact]
        public void RobotOffMapNegativeX()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(-1, 0, RobotDirection.N);

            var isRobotOnMap = marsMap.IsLocationOnMap(robotLocation);

            Assert.False(isRobotOnMap);
        }

        [Fact]
        public void RobotOffMapNegativeY()
        {
            var marsMap = new MarsMap(10, 10);
            var robotLocation = new RobotLocation(0, -1, RobotDirection.N);

            var isRobotOnMap = marsMap.IsLocationOnMap(robotLocation);

            Assert.False(isRobotOnMap);
        }
    }
}