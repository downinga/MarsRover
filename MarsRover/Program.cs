using MarsRover.Entities;
using MarsRover.Instructions;
using MarsRover.Utilities;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentOutOfRangeException("Incorrect number of arguments provided, please provide location of input file as argument only.");
            }

            StreamReader fileReader = new(args[0]);
            InputFileParser validator = new(fileReader);

            var (map, instructions) = validator.parse();

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, new ForwardInstruction() },
                { RobotInstruction.L, new TurnLeftInstruction() },
                { RobotInstruction.R, new TurnRightInstruction() }
            };

            ControlStation controlStation = new(instructionSet, map);
            StreamWriter fileWriter = new("output.txt");

            foreach (var (robotLocation, robotInstructions) in instructions)
            {
                var finalRobotLocation = controlStation.GetFinaLocationOfRobot(robotLocation, robotInstructions);
                fileWriter.WriteLine(finalRobotLocation);
            }

            fileWriter.Close();
        }
    }
}