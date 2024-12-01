using MarsRover.Entities;

namespace MarsRover.Instructions
{
    public class ForwardInstruction : IInstructionStrategy
    {
        public ForwardInstruction()
        {
        
        }
        public RobotLocation Execute(RobotLocation location)
        {
            switch (location.Direction)
            {
                case RobotDirection.N:
                    return new RobotLocation(location.X, location.Y + 1, location.Direction);
                case RobotDirection.E:
                    return new RobotLocation(location.X + 1,location.Y, location.Direction);
                case RobotDirection.S:
                    return new RobotLocation(location.X,location.Y - 1, location.Direction);
                case RobotDirection.W:
                    return new RobotLocation(location.X - 1,location.Y, location.Direction);
                default:
                    throw new Exception($"Unrecognised robot direction {location.Direction}");
            }
        }
    }
}