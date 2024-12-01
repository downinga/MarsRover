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

            StreamReader fileReader = new StreamReader(args[0]);
            InputFileParser validator = new InputFileParser(fileReader);

            var (map, instructions) = validator.parse();

            IDictionary<RobotInstruction, IInstructionStrategy> instructionSet = new Dictionary<RobotInstruction, IInstructionStrategy>()
            {
                { RobotInstruction.F, new ForwardInstruction() },
                { RobotInstruction.L, new TurnLeftInstruction() },
                { RobotInstruction.R, new TurnRightInstruction() }
            };
            
            foreach(var (location, robotInstructions) in instructions) 
            {
                var robotLocation = location;

                if (!map.IsLocationOnMap(robotLocation))
                {
                    Console.WriteLine("Robot already not on map, skipping.");
                    continue;
                }

                Console.WriteLine("Moving robot.");

                foreach(var instruction in robotInstructions)
                {
                    IInstructionStrategy movementStrategy = instructionSet[instruction];
                    var newRobotLocation = movementStrategy.Execute(robotLocation);

                    if (map.HasRobotBeenLost(robotLocation) && !map.IsLocationOnMap(newRobotLocation))
                    {
                        Console.WriteLine($"Instruction will send robot off the edge at {robotLocation}, skipping.");
                        continue;
                    }

                    if (!map.IsLocationOnMap(newRobotLocation))
                    {
                        map.AddLostRobotLocation(robotLocation);
                        Console.WriteLine($"Robot has now been lost at {robotLocation}.");
                        break;
                    }

                    robotLocation = newRobotLocation;
                }

                Console.WriteLine($"Finished moving robot, final position {robotLocation}");
            }
        }
    }
}