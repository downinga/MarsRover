namespace MarsRover.Entities
{
    public class MarsMap {
        public int maxX { get; }
        public int maxY { get; }
        private HashSet<RobotLocation> lostRobots = [];
        public MarsMap(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }
        public bool IsLocationOnMap(RobotLocation location)
        {
            return !(this.maxX < location._x || this.maxY < location._y || 0 > location._x || 0 > location._y);
        }
        public void AddLostRobotLocation(RobotLocation location)
        {
            this.lostRobots.Add(location);
        }
        public bool HasRobotBeenLost(RobotLocation location)
        {
            return this.lostRobots.Any(lostRobot => lostRobot.ToString() == location.ToString());
        }
    }
}
