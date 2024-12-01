using MarsRover.Entities;

namespace MarsRover.Instructions
{
    public class TurnLeftInstruction : IInstructionStrategy
    {
        public TurnLeftInstruction()
        {
        
        }
        public RobotLocation Execute(RobotLocation location)
        {
            switch (location.Direction)
            {
                case RobotDirection.N:
                    return new RobotLocation(location.X,location.Y, RobotDirection.W);
                case RobotDirection.E:
                    return new RobotLocation(location.X,location.Y, RobotDirection.N);
                case RobotDirection.S:
                    return new RobotLocation(location.X,location.Y, RobotDirection.E);
                case RobotDirection.W:
                    return new RobotLocation(location.X,location.Y, RobotDirection.S);
                default:
                    throw new Exception($"Unrecognised robot direction {location.Direction}");
            }
        }
    }
}