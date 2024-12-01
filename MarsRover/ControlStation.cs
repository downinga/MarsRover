using MarsRover.Entities;
using MarsRover.Instructions;

namespace MarsRover
{
    public class ControlStation
    {
        private IDictionary<RobotInstruction, IInstructionStrategy> _instructionSet;

        public ControlStation(IDictionary<RobotInstruction, IInstructionStrategy> instructionSet)
        {
            this._instructionSet = instructionSet;
        }
        public List<String> MoveRobots(MarsMap mars, IDictionary<RobotLocation,IList<RobotInstruction>> robotInput)
        {
            List<String> robotFinalStatuses = [];

            foreach(var (location, instructions) in robotInput) 
            {
                var robotLocation = location;

                if (!mars.IsLocationOnMap(robotLocation))
                {
                    Console.WriteLine("Robot already not on map, skipping.");
                    continue;
                }

                Console.WriteLine("Moving robot.");

                var robotLost = false;

                foreach(var instruction in instructions)
                {
                    IInstructionStrategy movementStrategy = _instructionSet[instruction];
                    var newRobotLocation = movementStrategy.Execute(robotLocation);

                    if (mars.HasRobotBeenLost(robotLocation) && !mars.IsLocationOnMap(newRobotLocation))
                    {
                        Console.WriteLine($"Instruction will send robot off the edge at {robotLocation}, skipping.");
                        continue;
                    }

                    if (!mars.IsLocationOnMap(newRobotLocation))
                    {
                        mars.AddLostRobotLocation(robotLocation);
                        robotLost = true;
                        Console.WriteLine($"Robot has now been lost at {robotLocation}.");
                        break;
                    }

                    robotLocation = newRobotLocation;
                }

                if (robotLost)
                {
                    robotFinalStatuses.Add($"{robotLocation} LOST");
                }
                else {
                    robotFinalStatuses.Add(robotLocation.ToString());
                }
            }
            return robotFinalStatuses;
        }
    }
}