namespace MarsRover.Entities
{
    public class MarsMap {
        public int MaxX { get; }
        public int MaxY { get; }
        private HashSet<RobotLocation> lostRobots = [];
        public MarsMap(int maxX, int maxY)
        {
            this.MaxX = maxX;
            this.MaxY = maxY;
        }
        public bool IsLocationOnMap(RobotLocation location)
        {
            return !(this.MaxX < location.X || this.MaxY < location.Y || 0 > location.X || 0 > location.Y);
        }
        public void AddLostRobotLocation(RobotLocation location)
        {   
            this.lostRobots.Add(location);
        }
        public bool HasARobotFallenOffEdge(RobotLocation location)
        {
            return this.lostRobots.Any(lostRobot => lostRobot.X == location.X && lostRobot.Y == location.Y);
        }
    }
}
