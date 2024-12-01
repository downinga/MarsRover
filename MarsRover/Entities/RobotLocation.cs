namespace MarsRover.Entities
{
    public class RobotLocation
    {
        public int X;
        public int Y;
        public RobotDirection Direction;

        public RobotLocation(int x, int y, RobotDirection direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public override string ToString()
        {
            return $"{this.X} {this.Y} {this.Direction}";
        }
    }
}