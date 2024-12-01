namespace MarsRover.Entities
{
    public class MarsMap {
        public int maxX { get; }
        public int maxY { get; }
        public MarsMap(int maxX, int maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }
    }
}
