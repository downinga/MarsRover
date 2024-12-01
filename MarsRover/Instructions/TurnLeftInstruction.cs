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
            switch (location._direction)
            {
                case RobotDirection.N:
                    return new RobotLocation(location._x,location._y, RobotDirection.W);
                case RobotDirection.E:
                    return new RobotLocation(location._x,location._y, RobotDirection.N);
                case RobotDirection.S:
                    return new RobotLocation(location._x,location._y, RobotDirection.E);
                case RobotDirection.W:
                    return new RobotLocation(location._x,location._y, RobotDirection.S);
                default:
                    throw new Exception($"Unrecognised robot direction {location._direction}");
            }
        }
    }
}