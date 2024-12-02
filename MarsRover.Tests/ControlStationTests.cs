using MarsRover.Entities;
using MarsRover.Instructions;
using Moq;

namespace MarsRover.Tests
{
    public class ControlStationTests
    {
        [Fact]
        public void RobotIgnoresInstructionsToGoOffMapWhenRobotLostAtSamePosition()
        {
            MarsMap mars = new(5,5);

            var mockForwardStrategy = new Mock<IInstructionStrategy>(MockBehavior.Strict);
            mockForwardStrategy.Setup(mock => mock.Execute(It.IsAny<RobotLocation>()))
                .Returns((RobotLocation location) => new RobotLocation(location.X + 1, location.Y, location.Direction));

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, mockForwardStrategy.Object }
            };

            var lostRobot = new RobotLocation(5,4, RobotDirection.E);
            mars.AddLostRobotLocation(lostRobot);
            ControlStation controlStation = new(instructionSet, mars);

            RobotLocation robot = new(4,4,RobotDirection.E);
            List<RobotInstruction> instructions = new()
            {
                RobotInstruction.F,
                RobotInstruction.F,
                RobotInstruction.F
            };

            var robotStatus = controlStation.GetFinaLocationOfRobot(robot, instructions);

            Assert.Equal("5 4 E", robotStatus);
        }

        [Fact]
        public void RobotWillFollowInstructionToOffMapWhenRobotLostAtDifferentPosition()
        {
            MarsMap mars = new(5,5);

            var mockForwardStrategy = new Mock<IInstructionStrategy>(MockBehavior.Strict);
            mockForwardStrategy.Setup(mock => mock.Execute(It.IsAny<RobotLocation>()))
                .Returns((RobotLocation location) => new RobotLocation(location.X + 1, location.Y, location.Direction));

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, mockForwardStrategy.Object }
            };
            var lostRobot = new RobotLocation(5,3, RobotDirection.E);
            mars.AddLostRobotLocation(lostRobot);
            ControlStation controlStation = new(instructionSet, mars);

            RobotLocation robot = new(4,4,RobotDirection.E);
            List<RobotInstruction> instructions = new()
            {
                RobotInstruction.F,
                RobotInstruction.F,
                RobotInstruction.F
            };

            var robotStatus = controlStation.GetFinaLocationOfRobot(robot, instructions);

            Assert.Equal("5 4 E LOST", robotStatus);
        }

        [Fact]
        public void RobotIsMarkedAsLostIfItGoesOffMap()
        {
            MarsMap mars = new(5,5);

            var mockForwardStrategy = new Mock<IInstructionStrategy>(MockBehavior.Strict);
            mockForwardStrategy.Setup(mock => mock.Execute(It.IsAny<RobotLocation>()))
                .Returns((RobotLocation location) => new RobotLocation(location.X + 1, location.Y, location.Direction));

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, mockForwardStrategy.Object }
            };
            ControlStation controlStation = new(instructionSet, mars);

            RobotLocation robot = new(4,4,RobotDirection.E);
            List<RobotInstruction> instructions = new()
            {
                RobotInstruction.F,
                RobotInstruction.F,
                RobotInstruction.F
            };

            var robotStatus = controlStation.GetFinaLocationOfRobot(robot, instructions);

            Assert.True(mars.HasARobotFallenOffEdge(new RobotLocation(5,4,RobotDirection.E)));
            Assert.Equal("5 4 E LOST", robotStatus);
        }

        [Fact]
        public void RobotCanMoveWithinBoundsOfMap()
        {
            MarsMap mars = new(5,5);

            var mockForwardStrategy = new Mock<IInstructionStrategy>(MockBehavior.Strict);
            mockForwardStrategy.Setup(mock => mock.Execute(It.IsAny<RobotLocation>()))
                .Returns((RobotLocation location) => new RobotLocation(location.X + 1, location.Y, location.Direction));

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, mockForwardStrategy.Object }
            };

            ControlStation controlStation = new(instructionSet, mars);

            RobotLocation robot = new(0,0,RobotDirection.E);
            List<RobotInstruction> instructions = new()
            {
                RobotInstruction.F,
                RobotInstruction.F,
                RobotInstruction.F
            };

            var robotStatus = controlStation.GetFinaLocationOfRobot(robot, instructions);
            Assert.Equal("3 0 E", robotStatus);
        }

        [Fact]
        public void RobotWillIgnoreToMoveOffCornerInDifferentDirectionWhereRobotWasLost()
        {
            MarsMap mars = new(5,5);

            var mockForwardStrategy = new Mock<IInstructionStrategy>(MockBehavior.Strict);
            mockForwardStrategy.Setup(mock => mock.Execute(It.IsAny<RobotLocation>()))
                .Returns((RobotLocation location) => new RobotLocation(location.X, location.Y + 1, location.Direction));

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, mockForwardStrategy.Object }
            };

            var lostRobot = new RobotLocation(5,5, RobotDirection.E);
            mars.AddLostRobotLocation(lostRobot);
            ControlStation controlStation = new(instructionSet, mars);

            RobotLocation robot = new(5,5,RobotDirection.N);
            List<RobotInstruction> instructions = new()
            {
                RobotInstruction.F,
                RobotInstruction.F,
                RobotInstruction.F
            };

            var robotStatus = controlStation.GetFinaLocationOfRobot(robot, instructions);
            Assert.Equal("5 5 N", robotStatus);
        }
    }
}