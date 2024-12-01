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
            switch (location._direction)
            {
                case RobotDirection.N:
                    return new RobotLocation(location._x, location._y + 1, location._direction);
                case RobotDirection.E:
                    return new RobotLocation(location._x + 1,location._y, location._direction);
                case RobotDirection.S:
                    return new RobotLocation(location._x,location._y - 1, location._direction);
                case RobotDirection.W:
                    return new RobotLocation(location._x - 1,location._y, location._direction);
                default:
                    throw new Exception($"Unrecognised robot direction {location._direction}");
            }
        }
    }
}