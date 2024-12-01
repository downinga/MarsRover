using MarsRover.Entities;

namespace MarsRover.Instructions
{
    public class TurnRightInstruction : IInstructionStrategy
    {
        public TurnRightInstruction()
        {
        
        }
        public RobotLocation Execute(RobotLocation location)
        {
            switch (location.Direction)
            {
                case RobotDirection.N:
                    return new RobotLocation(location.X,location.Y, RobotDirection.E);
                case RobotDirection.E:
                    return new RobotLocation(location.X,location.Y, RobotDirection.S);
                case RobotDirection.S:
                    return new RobotLocation(location.X,location.Y, RobotDirection.W);
                case RobotDirection.W:
                    return new RobotLocation(location.X,location.Y, RobotDirection.N);
                default:
                    throw new Exception($"Unrecognised robot direction {location.Direction}");
            }
        }
    }
}