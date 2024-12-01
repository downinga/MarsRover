using MarsRover.Entities;

namespace MarsRover.Instructions
{
    public interface IInstructionStrategy
    {
        public RobotLocation Execute(RobotLocation location);
    }
}
