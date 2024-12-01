namespace MarsRover.Entities
{
    public class RobotLocation
    {
        public int _x;
        public int _y;
        public RobotDirection _direction;

        public RobotLocation(int x, int y, RobotDirection direction)
        {
            this._x = x;
            this._y = y;
            this._direction = direction;
        }

        public override string ToString()
        {
            return $"{this._x} {this._y} {this._direction}";
        }
    }
}