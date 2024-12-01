using MarsRover.Entities;
using MarsRover.Instructions;

namespace MarsRover.Tests
{
    public class ControlStationTests
    {
        [Fact]
        public void MovesRobotsAndReturnsTheirPosition()
        {
            MarsMap mars = new(5,3);

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, new ForwardInstruction() },
                { RobotInstruction.L, new TurnLeftInstruction() },
                { RobotInstruction.R, new TurnRightInstruction() }
            };

            IDictionary<RobotLocation,IList<RobotInstruction>> instructions = new Dictionary<RobotLocation,IList<RobotInstruction>>()
            {
                { 
                    new RobotLocation(1,1,RobotDirection.E), 
                    new List<RobotInstruction>() { 
                        RobotInstruction.R,
                        RobotInstruction.F,
                        RobotInstruction.R,
                        RobotInstruction.F,
                        RobotInstruction.R,
                        RobotInstruction.F,
                        RobotInstruction.R,
                        RobotInstruction.F,
                    }
                },
                { 
                    new RobotLocation(3,2,RobotDirection.N), 
                    new List<RobotInstruction>() { 
                        RobotInstruction.F,
                        RobotInstruction.R,
                        RobotInstruction.R,
                        RobotInstruction.F,
                        RobotInstruction.L,
                        RobotInstruction.L,
                        RobotInstruction.F,
                        RobotInstruction.F,
                        RobotInstruction.R,
                        RobotInstruction.R, 
                        RobotInstruction.F,
                        RobotInstruction.L,
                        RobotInstruction.L,                                               
                    }
                },
                { 
                    new RobotLocation(0,3,RobotDirection.W), 
                    new List<RobotInstruction>() { 
                        RobotInstruction.L,
                        RobotInstruction.L,
                        RobotInstruction.F,
                        RobotInstruction.F,
                        RobotInstruction.F,
                        RobotInstruction.L,
                        RobotInstruction.F,
                        RobotInstruction.L,
                        RobotInstruction.F,
                        RobotInstruction.L                                              
                    }
                },
            };

            ControlStation controlStation = new(instructionSet);

            var output = controlStation.MoveRobots(mars, instructions);

            Assert.Equal(3, output.Count());

            var firstRobot = output.First();
            var secondRobot = output.Skip(1).First();
            var thirdRobot = output.Skip(2).First();

            Assert.Equal("1 1 E", firstRobot);
            Assert.Equal("3 3 N LOST", secondRobot);
            Assert.Equal("2 3 S", thirdRobot);
        }
    }
}