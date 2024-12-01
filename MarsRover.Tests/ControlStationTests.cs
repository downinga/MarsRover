using MarsRover.Entities;
using MarsRover.Instructions;

namespace MarsRover.Tests
{
    public class ControlStationTests
    {
        [Fact]
        public void RobotIgnoresInstructionsToGoOffMapWhenRobotLostAtSamePosition()
        {
            MarsMap mars = new(5,5);

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, new ForwardInstruction() }
            };

            mars.AddLostRobotLocation(new RobotLocation(5,4, RobotDirection.E));
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

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, new ForwardInstruction() }
            };

            mars.AddLostRobotLocation(new RobotLocation(5,3, RobotDirection.E));
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

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, new ForwardInstruction() }
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
            Assert.Equal("5 4 E LOST", robotStatus);
        }

        [Fact]
        public void RobotCanMoveWithinBoundsOfMap()
        {
            MarsMap mars = new(5,5);

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, new ForwardInstruction() }
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
    }
}