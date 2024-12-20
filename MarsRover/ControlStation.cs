using MarsRover.Entities;
using MarsRover.Instructions;

namespace MarsRover
{
    public class ControlStation
    {
        private readonly MarsMap _mars;
        private readonly IDictionary<RobotInstruction, IInstructionStrategy> _instructionSet;

        public ControlStation(IDictionary<RobotInstruction, IInstructionStrategy> instructionSet, MarsMap mars)
        {
            this._instructionSet = instructionSet;
            this._mars = mars;
        }

        public String GetFinaLocationOfRobot(RobotLocation currentLocation, IList<RobotInstruction> instructions)
        {
            var robotLocation = currentLocation;
            var robotLost = false;

            Console.WriteLine("Moving robot.");

            foreach(var instruction in instructions)
            {
                IInstructionStrategy movementStrategy = _instructionSet[instruction];
                var newRobotLocation = movementStrategy.Execute(robotLocation);

                if (_mars.IsLocationOnMap(newRobotLocation))
                {
                    robotLocation = newRobotLocation;
                    continue;
                }

                if (_mars.HasARobotFallenOffEdge(robotLocation)) 
                {
                    Console.WriteLine($"Instruction will send robot off the edge at {robotLocation}, skipping.");
                    continue;
                }
                    
                Console.WriteLine($"Robot has now been lost at {robotLocation}.");
                _mars.AddLostRobotLocation(robotLocation);
                robotLost = true;
                break;
            }

            if (robotLost)
            {
                return $"{robotLocation} LOST";
            }
            return robotLocation.ToString();
        }
    }
}